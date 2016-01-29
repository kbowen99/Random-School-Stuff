#include <Servo.h> 

Servo Jaguar;
float JagPos = 0;

void setup()
{
  // put your setup code here, to run once:
  Jaguar.attach(9);
  Serial.begin(9600);  
}

void loop()
{
  // put your main code here, to run repeatedly:
  float JoyHallValue = analogRead(A3);
  float HallVoltage = JoyHallValue * (3.0 / 1023.0);
  
  if (HallVoltage < 7) {
   JagPos = ((1.0 / 6.0) * (HallVoltage - 3.0) * 49.0);
   //JagPos = (49 * ((HallVoltage - 3.0) * (1/6)));
  } else if (HallVoltage > 9) {
   JagPos =  (30.0 * ( HallVoltage - 10.0 ) + 120.0) - 1;
  } else {
   JagPos = 90.0; 
  }
  
  Serial.println(JagPos);
  Serial.println(HallVoltage);
  
  
  Jaguar.write(JagPos);
}
