#ifndef BLUEBOARD_h
#define BLUEBOARD_h

#include "BlueBoard.h"
#include "AlphaBot.h"
#include "Names.h"

class BlueBoard
{
  private:
    AlphaBot BlueBot;
    byte program[MAX_PROGRAM_LENGTH]; // { funkcja, dane ..., /0 }
    byte command[MAX_PROGRAM_LENGTH];
    unsigned int programLength; // dlugosc zapisanego programu
    unsigned int commandLength;
    unsigned long timer[NUM_OF_TIMERS]; // zegar czasu rzeczywistego
    int param[NUM_OF_PARAMS]; // zmienne
    void (BlueBoard::*function[NUM_OF_FUNCTIONS])(unsigned int*, byte*); // (iterator, dane)

    void Error(unsigned int*, byte*);
	void StopProgram(unsigned int*, byte*);
	void StartProgram(unsigned int*, byte*);
    void GetProgram(unsigned int*, byte*);
	void AddProgram(unsigned int*, byte*);
    void WriteProgram(unsigned int*, byte*);
	void GetMemory(unsigned int*, byte*);
    void GetParam(unsigned int*, byte*);
    void SetParam(unsigned int*, byte*);
	void CalcParams(unsigned int*, byte*);
    void If(unsigned int*, byte*);
	void For(unsigned int*, byte*);
	void NextFun(unsigned int*, byte*);
	void Break(unsigned int*, byte*);
    void Delay(unsigned int*, byte*);
	void Timer(unsigned int*, byte*);
	void GetTime(unsigned int*, byte*);
	void MotorRun(unsigned int*, byte*);
	void MotorBrake(unsigned int*, byte*);
    void SetSpeed(unsigned int*, byte*);
    void SetDirection(unsigned int*, byte*);
    void TestWheelsRotation(unsigned int*, byte*);
	void MeasureSpeed(unsigned int*, byte*);
    void MeasureDistance(unsigned int*, byte*);
	void StopMeasureDist(unsigned int*, byte*);
	void CalcPosition(unsigned int*, byte*);
    void UpdateServo(unsigned int*, byte*);
    void EchoDistanceTest(unsigned int*, byte*);
    void IR_DistanceTest(unsigned int*, byte*);

	void DoProgram(unsigned int, byte*);
	int ReadInt(byte, byte);
	static void InterTestR() { rotR++; detachInterrupt(INTER_R); }
	static void InterTestL() { rotL++; detachInterrupt(INTER_L); }
	static void InterMeasDistR() { rotR++; }
	static void InterMeasDistL() { rotL++; }
	void SetMotor(int, int, int, int);
    
  public:
    void Init();
	volatile static int rotR, rotL;
    inline void Timer() { timer[0] = millis(); }
    void SerialRead();
    void LoopCommands();
    inline void Delay()
    {
      int timeToDelay = LOOP_TICK + timer[0] - millis();
      if (timeToDelay>0) delay(timeToDelay);
    }
};

#endif
