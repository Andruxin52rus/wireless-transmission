#include "LedControl.h"

LedControl initializeDisplay();
void DisplayPicture(LedControl, char*, char);
void DisplayMatrix(LedControl, char, char*);
void ClearDisplay(LedControl);
void DisplayText(LedControl, char*, uint8_t);
void DisplayAlpha(LedControl, uint8_t, uint8_t);
