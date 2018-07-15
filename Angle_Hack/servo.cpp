#include <Servo.h>

#define SERVO_PIN A1
#define SENSOR_PIN 4


Servo myservo;  // khởi tạo đối tượng Servo với tên gọi là myservo
// bạn có thể tạo tối đa 8 đối tượng Servo
bool state;

void setup ()
{
    pinMode(SENSOR_PIN, INPUT);
    myservo.attach (SERVO_PIN);
    Serial.begin (9600);
    myservo.write (100);
    state = 1;

}

void loop ()
{
    char temp;
    delay(1000);
    if (state != (bool)(digitalRead(SENSOR_PIN)))
    {
        Serial.print(state);
        state = !state;
    }

    while (Serial.available () > 0)
    {
        temp = Serial.read();
        if (temp == '1')
        {
            myservo.write (100);
            delay (1500);
        }
        else if (temp == '0')
        {
            myservo.write (0);
            delay (5000);
            myservo.write (100);
            delay (1500);
        }
    }
}
