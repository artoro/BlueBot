using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;

namespace Serial_Port
{
    class BlueBotCompiler
    {
        private class Code
        {
            public char CodeType { get; }
            public string Name { get; }
            public string Data { get; }
            public byte Num { get; }

            public static int NUM_OF_PARAMS { get; set; }
            public static int NUM_OF_TIMERS { get; set; }

            private static string FUN_NUM = "FUN_";
            private static string FUN_NAME = "&BlueBoard::";
            private static string FUN_DATA = "//";
            private static string PARAM_NUM = "param[";
            private static string DEFINE = "#define ";
            private static string TIMER_NUM = "timer[ ";

            public Code(string def)
            {
                int index;
                if ((index = def.IndexOf(FUN_NUM)) > 0)
                {
                    CodeType = 'f';
                    index += FUN_NUM.Length;
                    Num = Byte.Parse(def.Substring(index, 2));

                    index = def.IndexOf(FUN_NAME, index) + FUN_NAME.Length;
                    Name = def.Substring(index, def.IndexOf(' ', index) - index);

                    index = def.IndexOf(FUN_DATA, index) + 2;
                    Data = def.Substring(index);
                }
                else if ((index = def.IndexOf(PARAM_NUM)) > 0)
                {
                    CodeType = 'p';
                    index += PARAM_NUM.Length;
                    Num = Byte.Parse(def.Substring(index, def.IndexOf(']', index) - index));

                    index = DEFINE.Length;
                    Name = def.Substring(index, def.IndexOf(" ", index) - index);

                    Data = String.Empty;
                }
                else if ((index = def.IndexOf(TIMER_NUM)) > 0)
                {
                    CodeType = 't';
                    index += TIMER_NUM.Length;
                    Num = Byte.Parse(def.Substring(index, def.IndexOf(']', index) - index));

                    index = def.IndexOf(DEFINE) + DEFINE.Length;
                    Name = def.Substring(index, index - def.IndexOf(' ', index));

                    Data = String.Empty;
                }
                else CodeType = '\0';
            }

            public static object[] ToArray(ArrayList list)
            {
                ArrayList stringList = new ArrayList();
                foreach (Code c in list)
                {
                    StringBuilder s = new StringBuilder(c.Name);
                    if (c.CodeType == 'f')
                    {
                        if (c.Data != String.Empty) s.Append(" " + c.Data.Substring(0, c.Data.Length - 1));
                        s.Append(";");
                    }
                    s.Replace(" e c", " { e }");
                    s.Replace(" c", " { c }");
                    stringList.Add(s);
                }
                return stringList.ToArray();
            }
        }

        private static Dictionary<string, string> definitions = new Dictionary<string, string>();
        private static ArrayList functions = new ArrayList();
        private static ArrayList variables = new ArrayList();
        private static int NUM_OF_PARAMS = 0;
        private static int NUM_OF_FIRST_FREE_PARAM = 0;
        private static int NUM_OF_TIMERS = 0;

        public static object[] GetFunctions() { return Code.ToArray(functions); }
        public static object[] GetVariables() { return Code.ToArray(variables); }

        public static void LoadLibrary(string path)
        {
            string[] names = System.IO.File.ReadAllLines(path);

            if (names == null) return;
            bool start = false;

            foreach (string name in names)
            {
                if (name.Length < 5) continue;
                else if (!start) { start = (name.LastIndexOf("OpLib") > 0); continue; }
                else if (name.LastIndexOf("EndLib") > 0) break;
                Code c = new Code(name);
                if (c.CodeType == 'f') functions.Add(c);
                else if (c.CodeType != '\0') variables.Add(c);
                else
                {
                    if (NUM_OF_PARAMS == 0 && name.LastIndexOf("NUM_OF_PARAMS") > 0)
                        int.TryParse(name.Substring(name.Length - 3), out NUM_OF_PARAMS);
                    else if (NUM_OF_FIRST_FREE_PARAM == 0 && name.LastIndexOf("NUM_OF_FIRST_FREE_PARAM") > 0)
                        int.TryParse(name.Substring(name.Length - 3), out NUM_OF_FIRST_FREE_PARAM);
                    else if (NUM_OF_TIMERS == 0 && name.LastIndexOf("NUM_OF_TIMERS") > 0)
                        int.TryParse(name.Substring(name.Length - 3), out NUM_OF_TIMERS);
                }
            }
            definitions.Add("{", " _START ");
            definitions.Add("}", " _END ");
            definitions.Add("+", " 1 ");
            definitions.Add("-", " 2 ");
            definitions.Add("*", " 3 ");
            definitions.Add("/", " 4 ");
            definitions.Add("|", " 5 ");
            definitions.Add("&", " 6 ");
        }

        public static byte[] Compile(string source, out int correct)
        {
            string[] substrings = Preprocessor(source);
            correct = 0;
            byte[] code = Build(substrings, ref correct);
            if (code == null) return Error(source, substrings, ref correct);
            else return code;
        }

        private static string[] Preprocessor(string source)
        {
            StringBuilder sb = new StringBuilder(source);
            foreach (KeyValuePair<string, string> def in definitions) sb.Replace(def.Key, def.Value);
            Regex regex = new Regex(@"[\s,;=()]+");
            return regex.Split(sb.ToString());
        }

        private static byte[] Build(string[] substrings, ref int correct)
        {
            Queue<byte> code = new Queue<byte>();
            bool found = false;
            bool error = false;
            for (; correct < substrings.Length; correct++, found = false) // sprawdza wyraz po wyrazie
            {
                if (substrings[correct] == string.Empty) continue;
                else if (substrings[correct] == definitions["}"]) { return code.ToArray(); }
                foreach (Code f in functions)
                {
                    if (f.Name.Equals(substrings[correct])) // sprawdza argumenty znalezionej funkcji
                    {
                        code.Enqueue(f.Num);
                        found = true;
                        Parse(f, code, substrings, ref correct, out error);
                        break;
                    }
                }
                if (!found || error) return null;
            }
            return code.ToArray();
        }

        private static void Parse(Code fun, Queue<byte> code, string[] substrings, ref int correct, out bool error)
        {
            error = false;
            foreach (char arg in fun.Data)
            {
                switch (arg)
                {
                    case ' ': break;
                    case '0': code.Enqueue(0); break;
                    case 'i': IntToQueue(code, substrings[++correct], out error); break;
                    case 'b': ByteToQueue(code, substrings[++correct], out error); break;
                    case 'p': ParamToQueue(code, substrings[++correct], NUM_OF_PARAMS, out error); break;
                    case 't': ParamToQueue(code, substrings[++correct], NUM_OF_TIMERS, out error); break;
                    case 'e':
                        if (substrings[correct + 1].Equals(definitions["{"])) code.Enqueue(255);
                        else error = true; break;
                    case 'c': ++correct; CodeToQueue(code, ref correct, substrings, out error); break;
                    case 'd': ++correct; DataToQueue(code, ref correct, substrings, out error); break;
                    default: error = true; break;
                }
                if (error) return;
            }
        }

        private static void IntToQueue(Queue<byte> code, string substring, out bool error)
        {
            Int16 num;
            error = !Int16.TryParse(substring, out num);
            if (!error)
            {
                UInt16 NUM = (num < 0) ? (UInt16)(-num) : (UInt16)num; // wartość bezwzględna z liczby
                if (NUM > 32384) error = true; // wartość spoza zakresu
                byte N1 = (byte)(NUM % 255 + 1), N2 = (byte)(NUM / 255 + 1); // szyfrowanie
                if (num < 0) N2 |= 128; // bit znaku
                else N2 &= 127;
                if (!error) { code.Enqueue(N2); code.Enqueue(N1); }
            }
        }

        private static void ByteToQueue(Queue<byte> code, string substring, out bool error)
        {
            byte num;
            error = !Byte.TryParse(substring, out num) || num == 0;
            if (error)
            {
                num = 0;
                if (substring.Contains('=')) num += 1;
                if (substring.Contains('<')) num += 2;
                if (substring.Contains('>')) num += 4;
                if (num > 0)
                {
                    if (substring.Contains('e')) num += 8;
                    error = false;
                    code.Enqueue(num);
                    return;
                }
            }
            else code.Enqueue(num);
        }

        private static void ParamToQueue(Queue<byte> code, string substring, int max, out bool error)
        {
            byte num;
            error = !Byte.TryParse(substring, out num) || num > max;
            if (error)
            {
                foreach (Code var in variables) if (substring.Equals(var.Name))
                    {
                        error = false;
                        code.Enqueue(var.Num);
                        return;
                    }
            }
            else code.Enqueue(num);
        }

        private static void CodeToQueue(Queue<byte> code, ref int correct, string[] substrings, out bool error)
        {
            if (!substrings[correct].Equals(definitions["{"])) { error = true; return; }
            else error = false;
            byte[] codeToQueue = Build(substrings, ref correct);
            if (codeToQueue == null) { error = true; return; }
            else foreach (byte b in codeToQueue) if (b != 0) code.Enqueue(b);
            code.Enqueue(0);
        }

        private static void DataToQueue(Queue<byte> code, ref int correct, string[] substrings, out bool error)
        {
            if (!substrings[correct].Equals(definitions["{"])) { error = true; return; }
            else error = false;
            byte[] codeToQueue = Build(substrings, ref correct);
            if (codeToQueue == null) { error = true; return; }
            else foreach (byte b in codeToQueue) code.Enqueue((byte)(b + 1));
            code.Enqueue(0);
        }

        private static byte[] Error(string source, string[] substrings, ref int correct)
        {
            int good = 0;
            for (int x = 0; x <= correct; x++) good = Math.Max(source.IndexOf(substrings[x], good), good);
            correct = good;
            return null;
        }

        public static string Decompile(byte[] code, bool loop = false)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in code) sb.Append(b + " ");
            /*for (int i = 0, j = 0; i < code.Length; i++)
            {
                Function fun;
                if (code[i] > dictionary.Length) fun = dictionary[0];
                else fun = dictionary[code[i]];
                s += fun.Name + " ";
                for (++i, j = i + fun.DataSize; i < j; i++) s += code[i] + " ";
                if (fun.HasCode) while (i < code.Length && code[i] != 0) s += code[i++] + " ";
                if (i+2 < code.Length) s += '\n';
                if (code[i] == 0) i++;
            }
            if (loop) s += "\n\n" + Decompile(loopCode);*/
            return sb.ToString();
        }
    }
}
