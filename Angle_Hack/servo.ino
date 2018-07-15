#include <Servo.h> 

Servo myservo;  // khởi tạo đối tượng Servo với tên gọi là myservo 
                // bạn có thể tạo tối đa 8 đối tượng Servo 

void setup ()
{
    myservo.attach (A1);
    Serial.begin (9600);
    myservo.write (0);
} 

void loop ()
{
    char temp;

    while (Serial.available () > 0)
    {
        temp = Serial.read ();
        if (temp == '1')
        {
            Serial.println ("Open door.");
            myservo.write (100);
            delay (1500);
        }
        else if (temp == '0')
        {
            Serial.println ("Close door.");
            myservo.write (0);
            delay (1500);
        }
    }
}
