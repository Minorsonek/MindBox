#include <FastLED.h>
#include <SoftwareSerial.h>

#define WIFI_RX_PIN 4
#define WIFI_TX_PIN 5
#define LED_DATA_PIN 6

#define NUMBER_OF_LEDS 26

SoftwareSerial wifiSerial(WIFI_TX_PIN, WIFI_RX_PIN);

CRGB leds[NUMBER_OF_LEDS];

void setup()
{
  FastLED.addLeds<WS2812B, LED_DATA_PIN, GRB>(leds, NUMBER_OF_LEDS);

  Serial.begin(9600);
  wifiSerial.begin(9600);

  wifiSerial.println("AT");
  delay(500);
  Serial.println(wifiSerial.readString());
}

void loop()
{
  for (int i = 0; i < NUMBER_OF_LEDS; i++)
  {
    leds[i] = CRGB::Red;
    FastLED.show();
    delay(500);
  }
 }
