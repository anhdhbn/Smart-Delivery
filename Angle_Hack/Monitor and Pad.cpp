#include <Keypad.h>
#include <Wire.h>
#include <LiquidCrystal_I2C.h>
#include "HX711.h"
#include "math.h"


// Define pin number
#define ROW1 4
#define ROW2 5
#define ROW3 6
#define ROW4 7
#define COL1 8
#define COL2 9
#define COL3 10
#define COL4 11

#define SCL A4
#define SDA A5


const byte ROWS = 4; //four rows
const byte COLS = 4; //four columns
//define the cymbols on the buttons of the keypads
/*char hexaKeys[ROWS][COLS] =
{
	{'1', '2', '3', 'A'},
	{'4', '5', '6', 'B'},
	{'7', '8', '9', 'C'},
	{'*', '0', '#', 'D'}
};
*/
char hexaKeys[ROWS][COLS] =
{
	{'A', 'B', 'C', 'D'},
	{'3', '6', '9', '#'},
	{'2', '5', '8', '0'},
	{'1', '4', '7', '*'}
};


HX711 scale;
byte rowPins[ROWS] = {ROW1, ROW2, ROW3, ROW4}; //connect to the row pinouts of the keypad
byte colPins[COLS] = {COL1, COL2, COL3, COL4}; //connect to the column pinouts of the keypad
LiquidCrystal_I2C lcd(0x3F, 16, 2);
unsigned long previousMillis = 0;
Keypad customKeypad = Keypad(makeKeymap(hexaKeys), rowPins, colPins, ROWS, COLS);

void setup()
{

	Serial.begin(9600);
	//lcd.begin();
	scale.begin(A3, A2);
	lcd.init();
	// Print a message to the LCD.
	lcd.backlight();
	scale.set_scale(2280.f);
	scale.tare();
}

void loop()
{

	int cursorPosition = 0;
	int fullKey = 0;
	int confirm = 0;
	int gram = 0;
	char serialNumber[5] = {'0', '0', '0', '0', '\0'};
	char customKey;
	lcd.clear();
	lcd.setCursor(0, 0);
	lcd.print("Weight [g]:");
	while (1)
	{

		unsigned long currentMillis = millis();
		if (currentMillis - previousMillis >= 2000)
		{
			lcd.clear();
			lcd.setCursor(0, 0);
			lcd.print("Weight [g]:");
			lcd.setCursor(0, 1);
			lcd.print(abs(10.625 * scale.get_units(10)));
			previousMillis = millis();
		}
		customKey = customKeypad.getKey();
		if (customKey == '*')
		{
			gram = abs(10.625 * scale.get_units(10));
			break;
		}
	}

	lcd.clear();
	lcd.setCursor(0, 0);
	lcd.print("Enter serial");
	while (1)
	{
		customKey = customKeypad.getKey();
		if (customKey != '*' && customKey != '#' && customKey != 0 && fullKey != 1)
		{
			lcd.setCursor(5 + cursorPosition, 1);
			lcd.print(customKey);
			serialNumber[cursorPosition] = customKey;
			cursorPosition++;
			if (5 + cursorPosition >= 9)
			{
				cursorPosition = 3;
				fullKey = 1;
			}
		}
		else if (customKey == '*')
		{
			break;
		}
		else if (customKey == '#')
		{
			serialNumber[cursorPosition] = '0';
			lcd.setCursor(5 + cursorPosition, 1);
			lcd.print(' ');
			cursorPosition--;
			fullKey = 0;
			if (cursorPosition <= 0)
			{
				cursorPosition = 0;
			}
		}
	}

	lcd.clear();
	lcd.setCursor(0, 0);
	lcd.print("Sending ...");
	Serial.print(serialNumber);
	Serial.print(gram);
	delay(1000);
	lcd.clear();
	lcd.setCursor(0, 0);
	lcd.print("Done!");
	delay(200);

	/*lcd.clear();
	lcd.setCursor(0, 0);
	lcd.print("Validating ...");
	while (1)
	{
		if (Serial.available() > 0)
		{
			if (Serial.read() == 1)
			{
				confirm = 1;
			}
			else
			{
				confirm = 0;
			}
		}
		if (confirm == 1)
		{
			Serial.print(gram);
			break;
		}
		else
		{
			lcd.setCursor(0, 1);
			lcd.print("Try again? Press *");
			customKey = customKeypad.getKey();
			if (customKey == '*')
			{
				break;
			}

		}
	}*/
}
