#include "RadioHandling.h"

/*RF24 initializeRadio() {
  RF24 radio = RF24(7, 8);
  const char* transmitter_address = "1Node"; // Create address for 1 pipe.  
  radio.begin();  // Start up the physical nRF24L01 Radio
  radio.setPayloadSize(MAX_PACKET_SIZE); // set packet size
  radio.setChannel(108);  // Above most Wifi Channels
  radio.setPALevel(RF24_PA_MIN);
  //  radio.setPALevel(RF24_PA_MAX);  // Uncomment for more power
  radio.openWritingPipe(*transmitter_address);
  return radio;
}
*/
