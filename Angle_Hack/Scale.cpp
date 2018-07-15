#include "HX711.h"

HX711 scale(A4, A5);

void setup() {
  Serial.begin(38400);
  calibrate();
}

void loop() 
{

}
void calibrate()
{
  scale.set_scale();
  scale.tare();
  long b = scale.read_average();
  Serial.print("read average: \t\t");
  Serial.print(b);
  Serial.println("You have 5 seconds to place 350g weigh");
  delay(5000);
  long x = scale.read_average();
  long y = 350;
  double m = (double)(y - b) / x;
  Serial.print("b: ");
  Serial.println(b);
  Serial.print("x: ");
  Serial.println(x);
  Serial.print("y: ");
  Serial.println(y);
  Serial.print("m: ");
  Serial.println(m);
}

