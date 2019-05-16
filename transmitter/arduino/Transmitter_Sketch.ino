
/*
 * Transmitter_Sketch - скетч, который будет запущен на модуле-передатчике (Arduino Nano).
 * Цель: обеспечение передачи данных по беспроводному каналу с помощью nRFl01P в роли передатчика к приемнику с тем же чипом.
 * Дата создания: 27.10.2016
 * 
 * 28.10.2016 - обеспечение возможности передачи 1 байта
 * 01.11.2016 - передача данных, полученных из последовательного порта, по радио
 * 21.11.2016 - синхронизация с ПК по COM порту, отправка управляющих сообщений о готовности к работе и получении данных
*/

#include <nRF24L01.h>
#include <printf.h>
#include <RF24.h>
#include <RF24_config.h>

RF24 radio (7, 8);
const char* transmitter_address = "1Node"; // Create address for 1 pipe.

const short MAX_PACKET_SIZE = 291; // because of packet format
const byte MAX_BUFFER = 64; // buffer of Nano Serial Port
const byte NUMBER_OF_BUFFERS = MAX_PACKET_SIZE / MAX_BUFFER + 1;
byte data[NUMBER_OF_BUFFERS][MAX_BUFFER];
byte buffer_size[NUMBER_OF_BUFFERS]; // in bytes
byte transmitted_data[MAX_PACKET_SIZE];
byte real_number_of_buffers;

void setup() {
  Serial.begin(115200);
  delay(1000);
  radio.begin();  // Start up the physical nRF24L01 Radio
  radio.setPayloadSize(MAX_PACKET_SIZE); // set packet size
  radio.setChannel(108);  // Above most Wifi Channels
  //radio.setPALevel(RF24_PA_MIN);
  radio.setPALevel(RF24_PA_MAX);  // Uncomment for more power
  radio.openWritingPipe(*transmitter_address);
}

void loop() {
  while (Serial.available() > 0) {
    byte i=0;
    for ( ; i < NUMBER_OF_BUFFERS; i++) {
      buffer_size[i] = Serial.readBytes(data[i], MAX_BUFFER);
      String incoming = data[i];
      if (incoming == "Who is ready?") Serial.println("I am ready");
    }
    real_number_of_buffers = i;
  }
  
  if (buffer_size[0]) { // if there`s at least 1 byte
    short k = 0;
    for (byte i = 0; i < real_number_of_buffers; i++) {
      for (byte j = 0; j < buffer_size[i]; j++) {
        transmitted_data[k] = data[i][j];
        k++;
      }      
    }
  }
  
  radio.write(&transmitted_data, sizeof(transmitted_data)); // transmit the data
  
  for (int i = 0; i < NUMBER_OF_BUFFERS; i++) {
    buffer_size[i] = 0;
  }
}

