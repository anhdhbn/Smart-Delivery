#include <ESP8266WiFi.h>
#include <PubSubClient.h>

#define SEND_TIME 1

const char* ssid = "nakedhub";
const char* password = "Nakedhub";
const char* mqtt_server = "18.188.242.150";


WiFiClient espClient;
PubSubClient client(espClient);
unsigned long lastSend = millis();
char state[2] = "3";
char command[2] = "3";

void callback(char* topic, byte* payload, unsigned int length)
{
    payload[length] = '\0';
    if(strcmp(topic,"command/locker1") == 0)
    {
    	command[0] = payload[0];
        Serial.print(command[0]);
    }
}

void setup_wifi() {

	delay(10);
	// We start by connecting to a WiFi network
	//Serial.println();
	//Serial.print("Connecting to ");
	//Serial.println(ssid);

	WiFi.begin(ssid, password);

	while (WiFi.status() != WL_CONNECTED) {
		delay(500);
		//Serial.print(".");
	}

	//Serial.println("");
	//Serial.println("WiFi connected");
	//Serial.println("IP address: ");
	//Serial.println(WiFi.localIP());
}

void sendMQTT()
{
	unsigned long nowSend = millis();
	if (nowSend -  lastSend > SEND_TIME * 1000)
	{
		client.publish("state/locker1", state);
	}
}

void reconnect()
{
	// Loop until we're reconnected
	while (!client.connected())
	{
		//Serial.print("Attempting MQTT connection...");
		// Attempt to connect
		if (client.connect("ESP8266Client1"))
		{
			//Serial.println("connected");
			client.subscribe("command/locker1");
		}
		else
		{
			//Serial.print("failed, rc=");
			//Serial.print(client.state());
			//Serial.println(" try again in 5 seconds");
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
	
	if (Serial.available() > 0)
	{
		state[0] = Serial.read();
		sendMQTT();
	}
	client.loop();
}