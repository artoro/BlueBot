#include "BlueBoard.h"

void BlueBoard::Init()
{
  BlueBot = AlphaBot();
  Serial.begin(9600);
  pinMode(ECHO, INPUT);
  pinMode(TRIG, OUTPUT);
  IR_DL = analogRead(IR_L_PIN);
  delay(1);
  IR_DR = analogRead(IR_R_PIN);

  pinMode(SERVO_PIN, OUTPUT);
  pinMode(LMOT_SPEED_PIN, OUTPUT);
  pinMode(LMOT_FORW_PIN, OUTPUT);
  pinMode(LMOT_BACK_PIN, OUTPUT);
  pinMode(RMOT_SPEED_PIN, OUTPUT);
  pinMode(RMOT_FORW_PIN, OUTPUT);
  pinMode(RMOT_BACK_PIN, OUTPUT);
  
  program[0] = 0;
  command[0] = 0;
  programLength = 0;
  commandLength = 0;
  timer[0] = 0;
  
  for (byte i = 0; i < NUM_OF_PARAMS; i++) param[i] = 0;
  LOOP_TICK = 64;
  MOT_SPEED = 180;
  RMOT_SPEED = MOT_SPEED;
  LMOT_BALANCE = 227; // >>8
  LMOT_SPEED = 160;
  rotR = 0;
  rotL = 0;
  RMOT_DIRECTION = 255;
  LMOT_DIRECTION = 255;
  MOT_MIN_SPEED = 60;
  SERVO_ANGLE = 90;
  
  function[0]  = FUN_0;
  function[1]  = FUN_1;
  function[2]  = FUN_2;
  function[3]  = FUN_3;
  function[4]  = FUN_4;
  function[5]  = FUN_5;
  function[6]  = FUN_6;
  function[7]  = FUN_7;
  function[8]  = FUN_8;
  function[9]  = FUN_9;
  function[10] = FUN_10;
  function[11] = FUN_11;
  function[12] = FUN_12;
  function[13] = FUN_13;
  function[14] = FUN_14;
  function[15] = FUN_15;
  function[16] = FUN_16;
  function[17] = FUN_17;
  function[18] = FUN_18;
  function[19] = FUN_19;
  function[20] = FUN_20;
  function[21] = FUN_21;
  function[22] = FUN_22;
  function[23] = FUN_23;
  function[24] = FUN_24;
  function[25] = FUN_25;
  function[26] = FUN_26;
  function[27] = FUN_27;
  function[28] = FUN_28;
}

void BlueBoard::SerialRead()
{
  byte timeout = 255;
  while (Serial.available() && timeout-- > 0)
  {
    command[commandLength] = Serial.read();
    if (command[commandLength++] == 0) { DoProgram(commandLength, command); commandLength = 0, command[0] = 0; }
  }
}

void BlueBoard::LoopCommands()
{
  if (STATE & DO_PROGRAM) DoProgram(programLength, program);
}

void BlueBoard::DoProgram(unsigned int length, byte *data)
{
  unsigned int i = 0, *iterator = &i;
  while (i < length)
  {
    (FUNCTION[data[i]])(iterator, data);
	if (data[++i] != 0)
	{
	  Error(iterator, data);
    Serial.print(data[i]);
    Serial.print("!=0");
	  break;
	}
	else i++;
  }
}

void BlueBoard::Error(unsigned int *iterator, byte *data)
{
  Serial.print("Err_");
  Serial.print((data == program) ? 'p' : 'c');
  StopProgram(iterator, data);
}

void BlueBoard::StopProgram(unsigned int *iterator, byte *data)
{
  STATE &= !DO_PROGRAM;
  if (data == program) *iterator = programLength - 2;
}

void BlueBoard::StartProgram(unsigned int *iterator, byte *data)
{
  STATE |= DO_PROGRAM;
}

void BlueBoard::GetProgram(unsigned int *iterator, byte *data)
{
  Serial.write(program, programLength);
}

void BlueBoard::AddProgram(unsigned int *iterator, byte *data)
{
  BUFFER_LENGTH = ReadInt((*iterator) + 1, (*iterator) + 2);
  if (BUFFER_LENGTH + programLength > MAX_PROGRAM_LENGTH)
  {
	Error(iterator, data);
	(*iterator) += BUFFER_LENGTH + 2;
  }
  else
  {
	unsigned int i = programLength;
	programLength += BUFFER_LENGTH;
	for ((*iterator) += 2; i < programLength; i++) program[i] = data[++(*iterator)] - 1;
  }
}

void BlueBoard::WriteProgram(unsigned int *iterator, byte *data)
{
  programLength = 0;
  program[0] = 0;
  AddProgram(iterator, data);
}

void BlueBoard::GetMemory(unsigned int *iterator, byte *data)
{
  for (int i=0; i<NUM_OF_PARAMS; i++)
  {
  Serial.print(i);
	Serial.print('=');
	Serial.println(param[i]);
  }
}

void BlueBoard::GetParam(unsigned int *iterator, byte *data)
{
  Serial.print('=');
  Serial.println(param[data[++(*iterator)]]);
}

void BlueBoard::SetParam(unsigned int *iterator, byte *data)
{
  param[data[*iterator + 1]] = ReadInt(data[*iterator + 2], data[*iterator + 3]);
  (*iterator) += 3;
}

int BlueBoard::ReadInt(byte dat1, byte dat0)
{
  int read = dat0 + (dat1 & 127) * 255 - 256;
  return (dat1 & 128) ? -read : read;
}

void BlueBoard::CalcParams(unsigned int *iterator, byte *data)
{
	int result, a = param[data[*iterator + 2]], b = param[data[*iterator + 4]];
	switch (data[*iterator + 3])
	{
	case 1: result = a + b; break;
	case 2: result = a - b; break;
	case 3: result = a * b; break;
	case 4: result = a / b; break;
	case 5: result = a | b; break;
	case 6: result = a & b; break;
	default: result = param[data[*iterator + 1]];
	}
	param[data[*iterator + 1]] = result;
	(*iterator) += 4;
}

void BlueBoard::If(unsigned int *iterator, byte *data) // param1 tryb(1= 2< 3<= 4> 5>= 8else) param2 funkcja dane... (0 elsefunkcja dane) koniec:0
{
  int a = param[data[*iterator+1]],
      s = data[*iterator+2],
      b = param[data[*iterator+3]];
  (*iterator) += 3;
  if (((s&1) && a==b) || ((s&2) && a<b) || ((s&4) && a>b))
  {
	while (data[(*iterator) + 1] != 255) (FUNCTION[++(*iterator)])(iterator, data);
    NextFun(iterator, data);
  }
  else if (s & 8) {
	while (data[(*iterator)++] != 255);
	while (data[(*iterator) + 1] != 0) (FUNCTION[++(*iterator)])(iterator, data);
  }
}

void BlueBoard::For(unsigned int *iterator, byte *data)
{
  int repeat = param[data[*iterator + 1]];
  unsigned int startFun = *iterator + 1;
  for (*iterator = startFun; repeat > 0; *iterator = startFun, repeat--)
	while (data[(*iterator)++] != 0) (FUNCTION[data[*iterator]])(iterator, data);
  NextFun(iterator, data);
}

void BlueBoard::NextFun(unsigned int *iterator, byte *data)
{
  while (data[*iterator + 1] != 0) (*iterator)++;
}

void BlueBoard::Break(unsigned int *iterator, byte *data)
{
  (*iterator) = programLength - 2;
}

void BlueBoard::Delay(unsigned int *iterator, byte *data)
{
  delay(param[data[++(*iterator)]]);
}

void BlueBoard::Timer(unsigned int *iterator, byte *data) // fun, numer timera, parametr okresu, ...
{
  int dt = timer[0] - timer[data[*iterator + 1]];
  if (dt > param[data[*iterator + 2]])
  {
    timer[data[*iterator + 1]] = timer[0];
	(*iterator) += 3;
	(FUNCTION[data[*iterator]])(iterator, data);
  }
  else NextFun(iterator, data);
}

void BlueBoard::GetTime(unsigned int *iterator, byte *data)
{
  Serial.write('=');
  Serial.println(timer[0]);
}

void BlueBoard::MotorRun(unsigned int *iterator, byte *data) 
{
  SetMotor(LMOT_SPEED_PIN, LMOT_FORW_PIN, LMOT_BACK_PIN, long(long(LMOT_SPEED) * long(LMOT_DIRECTION)) >> 8);
  SetMotor(RMOT_SPEED_PIN, RMOT_FORW_PIN, RMOT_BACK_PIN, long(long(RMOT_SPEED) * long(RMOT_DIRECTION)) >> 8);
  Serial.println(MOT_DIRECTION);
  Serial.println(long(long(LMOT_SPEED) * long(LMOT_DIRECTION)) >> 8);
  Serial.println(long(long(RMOT_SPEED) * long(RMOT_DIRECTION)) >> 8);
}

void BlueBoard::SetMotor(int pin, int fpin, int bpin, int speed)
{
  analogWrite(pin, abs(speed));
  digitalWrite(fpin, speed > MOT_MIN_SPEED);
  digitalWrite(bpin, speed < -MOT_MIN_SPEED);
}

void BlueBoard::MotorBrake(unsigned int *iterator, byte *data)
{
  digitalWrite(LMOT_SPEED_PIN, LOW);
  digitalWrite(RMOT_SPEED_PIN, LOW);
}

void BlueBoard::SetSpeed(unsigned int *iterator, byte *data)
{
  RMOT_SPEED = MOT_SPEED;
  LMOT_SPEED = long(long(RMOT_SPEED) * long(LMOT_BALANCE)) >> 8;
  MotorRun(iterator, data);
}

void BlueBoard::SetDirection(unsigned int *iterator, byte *data)
{
  int direction = long(long(MOT_DIRECTION) << 8) / 360;
  int angleOfQuarter = direction & 63;
  switch (direction & 192)
  {
  case 0: LMOT_DIRECTION = 256 - angleOfQuarter * 7; RMOT_DIRECTION = 256 - angleOfQuarter; break;
  case 64: LMOT_DIRECTION = -192 - angleOfQuarter; RMOT_DIRECTION = 192 - angleOfQuarter * 7; break;
  case 128: LMOT_DIRECTION = -256 + angleOfQuarter * 7; RMOT_DIRECTION = -256 + angleOfQuarter; break;
  case 192: LMOT_DIRECTION = 192 + angleOfQuarter; RMOT_DIRECTION = -192 + angleOfQuarter * 7; break;
  }
  MotorRun(iterator, data);
}

void BlueBoard::TestWheelsRotation(unsigned int *iterator, byte *data)
{
  bool mem = (STATE & INTERRUPTS_IS_ATTACHED);
  STATE = (STATE | INTERRUPTS_IS_ATTACHED) & ~MOT_ISNT_WORKING;
  if (mem) WHEELS_ROT_R += rotR, WHEELS_ROT_L += rotL;
  rotR = 0, rotL = 0;

  attachInterrupt(INTER_R, InterTestR, RISING);
  attachInterrupt(INTER_L, InterTestL, RISING);
  for (byte i = 0; (rotR == 0 || rotL == 0) && i < 10; i++) delay(20);
  detachInterrupt(INTER_R);
  detachInterrupt(INTER_L);

  if (rotR == 0 || rotL == 0) STATE |= MOT_ISNT_WORKING;
  WHEELS_ROT_R += rotR, WHEELS_ROT_L += rotL;
  rotR = 0, rotL = 0;

  if (mem) MeasureDistance(iterator, data);
  else STATE &= ~INTERRUPTS_IS_ATTACHED;
}

void BlueBoard::MeasureSpeed(unsigned int *iterator, byte *data)
{
  
}

void BlueBoard::MeasureDistance(unsigned int *iterator, byte *data)
{
  if (STATE & INTERRUPTS_IS_ATTACHED) WHEELS_ROT_R += rotR, WHEELS_ROT_L += rotL;
  else
  {
	attachInterrupt(INTER_R, InterMeasDistR, RISING);
    attachInterrupt(INTER_L, InterMeasDistL, RISING);
	STATE |= INTERRUPTS_IS_ATTACHED;
  }
  rotR = rotL = 0;
}

void BlueBoard::StopMeasureDist(unsigned int *iterator, byte *data)
{
  WHEELS_ROT_R += rotR, WHEELS_ROT_L += rotL;
  detachInterrupt(INTER_R);
  detachInterrupt(INTER_L);
  STATE &= INTERRUPTS_IS_ATTACHED;
  rotR = rotL = 0;
}

void BlueBoard::CalcPosition(unsigned int *iterator, byte *data)
{
  VECTOR_RAY += (WHEELS_ROT_R + WHEELS_ROT_L) >> 1;
  VECTOR_ANGLE += 0;
  WHEELS_ROT_R = 0, WHEELS_ROT_L = 0;
}

void BlueBoard::UpdateServo(unsigned int *iterator, byte *data)
{
  if (SERVO_ANGLE < 0) SERVO_ANGLE = 0;
  else if (SERVO_ANGLE > 180) SERVO_ANGLE = 180;
  do
  {
    digitalWrite(SERVO_PIN,HIGH);              //Set the servo Pin level high
    delayMicroseconds(SERVO_ANGLE * 11 + 500);    //The angle is converted to a pulse width value of 500-2480
    digitalWrite(SERVO_PIN,LOW);
    delay(20);
  } while (SERVO_UPDATE-- > 0);
  SERVO_UPDATE = 0;
}

void BlueBoard::EchoDistanceTest(unsigned int *iterator, byte *data)
{
  digitalWrite(TRIG, LOW);                   // set trig pin low 2μs
  delayMicroseconds(2);
  digitalWrite(TRIG, HIGH);                  // set trig pin 10μs , at last 10us 
  delayMicroseconds(10);
  digitalWrite(TRIG, LOW);                   // set trig pin low
  DISTANCE = pulseIn(ECHO, HIGH) / 58;
}

void BlueBoard::IR_DistanceTest(unsigned int *iterator, byte *data)
{
  IR_DL = analogRead(IR_L_PIN);
  delay(1);
  IR_DR = analogRead(IR_R_PIN);
}
