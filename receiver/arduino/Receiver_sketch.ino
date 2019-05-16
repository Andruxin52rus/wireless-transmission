#include "matrix.h"
#include <nRF24L01.h>
#include <printf.h>
#include <RF24.h>
#include <RF24_config.h>

char num_of_previous_command = 0;
unsigned short delaytime=1000;
LedControl lc = initializeDisplay();

RF24 radio (7, 8); 
char* transmitter_address = "1Node"; // Create address for 1 pipe.
const byte MAX_PACKET_SIZE = 291; // because of packet format
char received_data[MAX_PACKET_SIZE];

void setup() {
  Serial.begin(9600);
  radio.begin();  // Start up the physical nRF24L01 Radio
  radio.setPayloadSize(MAX_PACKET_SIZE); // set packet size
  radio.setChannel(108);  // Above most Wifi Channels
  //radio.setPALevel(RF24_PA_MIN);
  radio.setPALevel(RF24_PA_MAX);  // Uncomment for more power
  radio.openReadingPipe(1, *transmitter_address);
  radio.startListening(); 
}

void loop() {  
  if (radio.available()) {        
    while (radio.available()) {
      radio.read(&received_data, sizeof(received_data));
    }
  }
  char num_of_command = (char)received_data[0];
  //проверяем, надо ли очистить дисплэй перед
  //выполнением другой команды
  if (num_of_command != num_of_previous_command)
  {
    ClearDisplay(lc);
    delay(delaytime);
  }
  num_of_previous_command = num_of_command;
  //очистка дисплея если была дана третья команда
  if (num_of_command==3)
  {
    ClearDisplay(lc);
    delay(delaytime);
  }
  
  //если была дана команда 1 - вывести текст
  if (num_of_command==1)
  {
    byte* data = received_data + 3; // cutoff header and get to the text data
    char size_of_data = (char)received_data[2];
    DisplayText(lc, (char*)data, (uint8_t)size_of_data);
    delay(delaytime);
  }
  
  //если была дана команда 2 - вывести рисунок
  if (num_of_command==2)
  {
   byte* data = received_data + 3;
   char size_of_data = (char)received_data[1]*256+(char)received_data[2]; // 256 is 2^8 which means that received_data[1] continues received_data[2] from 8th bit
   char quantity_of_matrix = size_of_data/9; 
   DisplayPicture(lc, (char*)data, quantity_of_matrix);
   delay(delaytime);
  }
}
