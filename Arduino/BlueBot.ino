#include "BlueBoard.h"

BlueBoard BlueBot;
volatile int BlueBoard::rotR = 0, BlueBoard::rotL = 0;

void setup()
{
  BlueBot.Init();           // inicjalizacja
}

void loop()
{
  BlueBot.Timer();          // pomiar czasu
  BlueBot.SerialRead();     // jednorazowe komendy
  BlueBot.LoopCommands();   // uruchamia zaprogramowane komendy
  BlueBot.Delay();          // koncowe opoznienie
}
