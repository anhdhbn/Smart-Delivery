#include <ESP8266WiFi.h>
#include <PubSubClient.h>

#define SEND_TIME 1

const char* ssid = "Maker Hanoi";
const char* password = "makerhanoi@123456";
const char* mqtt_server = "18.188.242.150";


WiFiClient espClient;
PubSubClient client(espClient);
unsigned long lastSend = millis();
String weightChar;
char id[] = "0000";
String idChar;

void callback(char* topic, byte* payload, unsigned int length)
{

}

void setup_wifi() {

	delay(10);
	// We start by connecting to a WiFi network
	Serial.println();
	Serial.print("Connecting to ");
	Serial.println(ssid);

	WiFi.begin(ssid, password);

	while (WiFi.status() != WL_CONNECTED) {
		delay(500);
		Serial.print(".");
	}

	Serial.println("");
	Serial.println("WiFi connected");
	Serial.println("IP address: ");
	Serial.println(WiFi.localIP());
}

void sendMQTT()
{
	unsigned long nowSend = millis();
	if (nowSend -  lastSend > SEND_TIME * 1000)
	{
		String input = "{\"weight\":\"" + weightChar + "\",\"ID\":" + (String)id + "}";
		char json[100];
		input.toCharArray( json, 100 );
		client.publish("scale", json);
	}
}

void reconnect()
{
	// Loop until we're reconnected
	while (!client.connected())
	{
		Serial.print("Attempting MQTT connection...");
		// Attempt to connect
		if (client.connect("ESP8266Client"))
		{
			Serial.println("connected");
		}
		else
		{
			Serial.print("failed, rc=");
			Serial.print(client.state());
			Serial.println(" try again in 5 seconds");
			delay(5000);
		}
	}
}
void setup()
{
	Serial.begin(9600);
	setup_wifi();
	client.setServer(mqtt_server, 1883);
	client.setCallback(callback);
}

void loop()
{
	if (!client.connected())
	{
		reconnect();
	}
	client.loop();
	if (Serial.available() > 4)
	{
		weightChar = "";
		id[0] = Serial.read();
		id[1] = Serial.read();
		id[2] = Serial.read();
		id[3] = Serial.read();
		while (Serial.available() > 0)
		{
			char temp = Serial.read();
			weightChar += (String)temp;
		}
		sendMQTT();
	}
}