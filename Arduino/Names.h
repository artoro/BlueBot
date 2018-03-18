#ifndef NAMES_h
#define NAMES_h

// Piny
#define ECHO 7
#define TRIG 8
#define IR_L_PIN A4
#define IR_R_PIN A5
#define SERVO_PIN 9
#define INTER_R 1
#define INTER_L 0
#define LMOT_SPEED_PIN 5
#define LMOT_FORW_PIN A0
#define LMOT_BACK_PIN A1
#define RMOT_SPEED_PIN 6
#define RMOT_FORW_PIN A3
#define RMOT_BACK_PIN A2

// OpLib

// Parametry
#define MAX_PROGRAM_LENGTH 100

#define ZERO param[0]
#define STATE param[1]
#define DO_PROGRAM 1
#define INTERRUPTS_IS_ATTACHED 2
#define MOT_IS_RUNNING 4
#define MOT_ISNT_WORKING 8
#define STATE5 16
#define STATE6 32
#define STATE7 64
#define STATE8 128

#define BUFFER_LENGTH param[2]
#define LOOP_TICK param[3]
#define MOT_SPEED param[4]
#define RMOT_SPEED param[5]
#define LMOT_SPEED param[6]
#define LMOT_BALANCE param[7]
#define MOT_MIN_SPEED param[8]
#define MOT_DIRECTION param[9]
#define RMOT_DIRECTION param[10]
#define LMOT_DIRECTION param[11]
#define WHEELS_ROT_R param[12]
#define WHEELS_ROT_L param[13]
#define SERVO_ANGLE param[14]
#define SERVO_UPDATE param[15]
#define DISTANCE param[16]
#define IR_DL param[17]
#define IR_DR param[18]
#define VECTOR_RAY param[19]
#define VECTOR_ANGLE param[20]

#define NUM_OF_FIRST_FREE_PARAM 21
#define NUM_OF_PARAMS 50

#define TIMER_1 timer[1]
#define TIMER_2 timer[2]
#define TIMER_3 timer[3]
#define NUM_OF_TIMERS 4

// Funkcje
#define FUN_0  &BlueBoard::Error //0
#define FUN_1  &BlueBoard::StopProgram //0
#define FUN_2  &BlueBoard::StartProgram //0
#define FUN_3  &BlueBoard::GetProgram //0
#define FUN_4  &BlueBoard::AddProgram //i d 0
#define FUN_5  &BlueBoard::WriteProgram //i d 0
#define FUN_6  &BlueBoard::GetMemory //0
#define FUN_7  &BlueBoard::GetParam //p 0
#define FUN_8  &BlueBoard::SetParam //p i 0
#define FUN_9  &BlueBoard::CalcParams //p p b p 0
#define FUN_10 &BlueBoard::If //p b p c e c 0
#define FUN_11 &BlueBoard::For //p c 0
#define FUN_12 &BlueBoard::NextFun //0
#define FUN_13 &BlueBoard::Break //0
#define FUN_14 &BlueBoard::Delay //p 0
#define FUN_15 &BlueBoard::Timer //t p c 0
#define FUN_16 &BlueBoard::GetTime //0
#define FUN_17 &BlueBoard::MotorRun //0
#define FUN_18 &BlueBoard::MotorBrake //0
#define FUN_19 &BlueBoard::SetSpeed //0
#define FUN_20 &BlueBoard::SetDirection //0
#define FUN_21 &BlueBoard::TestWheelsRotation //0
#define FUN_22 &BlueBoard::MeasureSpeed //0
#define FUN_23 &BlueBoard::MeasureDistance //0
#define FUN_24 &BlueBoard::StopMeasureDist //0
#define FUN_25 &BlueBoard::CalcPosition //0
#define FUN_26 &BlueBoard::UpdateServo //0
#define FUN_27 &BlueBoard::EchoDistanceTest //0
#define FUN_28 &BlueBoard::IR_DistanceTest //0

#define NUM_OF_FUNCTIONS 29
#define FUNCTION this->*function

// EndLib

#endif
