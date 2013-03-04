//=====================================================================================================
// main.c
// S.O.H. Madgwick
// 27th June 2010
//=====================================================================================================
//
// DAQ32 firmware
//
// Required COM port settings:
//	- 921.6 kbps
//	- RTS/CTS hardware flow control
//
// Interrupt priority (nesting disabled):
//	7 - Timer 1 (sample timer)
//	6 - UART TX
//
//====================================================================================================

//---------------------------------------------------------------------------------------------------
// Header files

#include <p33FJ256GP710.h>

//---------------------------------------------------------------------------------------------------
// Configuration Bits

_FOSCSEL(FNOSC_FRCPLL)			// Fast RC oscillator
_FOSC(OSCIOFNC_ON)				// OSCO pin has digital I/O function
_FWDT(FWDTEN_OFF)				// Watchdog Timer: Disabled

//---------------------------------------------------------------------------------------------------
// Variable declaration and definitions

const char nib2dec[10] = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
__attribute__((far)) volatile unsigned char serialBuf [256];
volatile unsigned char serialBufInPos = 0, serialBufOutPos = 0;
unsigned int numChan = 0, chanSel = 0;
const char nextChanSel[32] = {22, 23, 24, 25, 26, 27 ,28, 29, 30, 31, 16, 17, 18, 19, 20, 21, 5, 4, 3, 2, 1, 0, 6, 7, 8, 9, 10, 11 ,12, 13, 14 ,15};
volatile unsigned int ADC1buf[16] __attribute__((space(dma)));
unsigned long sum;
unsigned int mean;

//---------------------------------------------------------------------------------------------------
// Macros

#define printChar(data) {					\
	serialBuf[serialBufInPos] = data;		\
	asm volatile("INC.B _serialBufInPos");	\
	if (!_U1TXIE) {							\
		_U1TXIF = 1;						\
		_U1TXIE = 1;						\
	}										\
}

//====================================================================================================
// Functions
//====================================================================================================

//---------------------------------------------------------------------------------------------------
// Main routine

int main(void) {

/* init IOs */
	PORTA = 0x0000; 							// clear all PORT
	PORTB = 0x0000;
	PORTC = 0x0000;
	PORTD = 0x0000;
	PORTE = 0x0000;
	PORTF = 0x0000;
	PORTG = 0x0000;
	LATA = 0x0000;								// clear all LAT
	LATB = 0x0000;
	LATC = 0x0000;
	LATD = 0x0000;
	LATE = 0x0000;
	LATF = 0x0000;
	TRISA = 0xFFFF;								// setup all TRIS (all input except U1TX and U1RTS)
	TRISB = 0xFFFF;
	TRISC = 0xFFFF;
	TRISD = 0x7FFF;
	TRISE = 0xFFFF;
	TRISF = 0xFFF7;
	AD1PCFGH = 0x0000;							// configure all ANx pins to be analogue
	AD1PCFGL = 0x0000;

/* init misc */
	__builtin_write_OSCCONL(OSCCON | 0x0002);	// enable secondary 32.768 kHz oscillator
	_NSTDIS = 1;								// interrupt nesting disabled

/* init Oscillator */
	_PLLPRE = 0;								// setup PLL for at 29.4912 MIPs
	_PLLDIV = 30;
	_PLLPOST = 0;

/* init UART */
	U1MODE = 0x0000;							// clear register effects
	U1BRG = 1;									// set baud rate for 921600
	U1MODEbits.UEN = 0b10;						// UxTX, UxRX, UxCTS and UxRTS pins are enabled and used	
	U1MODEbits.UARTEN = 1;						// UART enabled
	U1STAbits.UTXEN = 1;						// transmit enabled
	_U1TXIP = 6;								// set TX interrupt priority
	_U1RXIP = 1;								// set RX interrupt priority
	_U1RXIE = 1;								// RX interrupt enabled

/* init ADC1 */
	AD1CON1 = 0x0000;							// clear settings
	AD1CON2 = 0x0000;							// clear settings
	AD1CON3 = 0x0000;							// clear settings
	AD1CON1bits.ADDMABM	= 1;					// DMA buffers are written in the order of conversion
	AD1CON1bits.AD12B = 1;						// 12-bit, 1-channel ADC operation
	AD1CON1bits.SSRC = 0b111;					// internal counter ends sampling and starts conversion (auto-convert)
	AD1CON1bits.ASAM = 1;						// sampling begins immediately after last conversion. SAMP bit is auto-set
	AD1CON2bits.SMPI = 15; 						// increments the DMA address after completion of every 15th sample/conversion operation
	AD1CON3bits.ADCS = 3;						// ADC Conversion Clock = 29.4912 MHz / (3+1) = 7.3728 MHz
	AD1CON3bits.SAMC = 6;						// Auto Sample Time (min 3 for 12-bit).  Sample rate = 7.3728 MHz / (14 + 6) = 368.64 kHz
	AD1CHS0bits.CH0SA = 22;						// Start on PCB channel 0 (AN22)
	AD1CON1bits.ADON = 1;						// ADC module is operating

/* init DMA0 */
	DMA0CON = 0x0000;							// clear settings
	DMA0PAD = 0x0300;							// point DMA to ADC1BUF0
	DMA0CNT = 15; 								// transfer count = 15 + 1 = 16
	DMA0REQ = 0b0001101;						// IRQ select = 'ADC1 – ADC1 Convert done'
	DMA0STA = __builtin_dmaoffset(&ADC1buf);	// DPSRAM Start Address Offset
	DMA0CONbits.CHEN = 1;						// enable DMA0

/* Timer 0 */
	T1CON = 0x0000;								// clear settings
	T1CONbits.TCS = 1;							// external clock from pin T1CK
	PR1 = 1;									// set period register for 16.834 kHz
	TMR1 = 0;									// zero timer
	_T1IF = 0;									// clear interrupt flag
	T1CONbits.TON = 1;							// start timer

/* main loop */
	while(1) {

	/* fetch number of selected channels */
		asm volatile("CLR _numChan");
		asm volatile("BTSS _PORTD, #8");
		asm volatile("BSET _numChan, #0");
		asm volatile("BTSS _PORTD, #9");
		asm volatile("BSET _numChan, #1");
		asm volatile("BTSS _PORTD, #10");
		asm volatile("BSET _numChan, #2");
		asm volatile("BTSS _PORTD, #11");
		asm volatile("BSET _numChan, #3");
		asm volatile("BTSS _PORTD, #0");
		asm volatile("BSET _numChan, #4");

	/* wait for sample period to elapse */
		while(!_T1IF);
		_T1IF = 0;

	/* print mean of last 16 samples */
		sum = (unsigned long)ADC1buf[0] + (unsigned long)ADC1buf[1] + (unsigned long)ADC1buf[2] + (unsigned long)ADC1buf[3] +
			  (unsigned long)ADC1buf[4] + (unsigned long)ADC1buf[5] + (unsigned long)ADC1buf[6] + (unsigned long)ADC1buf[7] +
			  (unsigned long)ADC1buf[8] + (unsigned long)ADC1buf[9] + (unsigned long)ADC1buf[10] + (unsigned long)ADC1buf[11] +
			  (unsigned long)ADC1buf[12] + (unsigned long)ADC1buf[13] + (unsigned long)ADC1buf[14] + (unsigned long)ADC1buf[15];
		mean = (unsigned int)(sum >> 4);
		printChar(nib2dec[(mean % 10000) / 1000]);
		printChar(nib2dec[(mean % 1000) / 100]);
		printChar(nib2dec[(mean % 100) / 10]);
		printChar(nib2dec[mean % 10]);
	
	/* print comma or new-line character, and select next channel */
		if(chanSel++ >= numChan) {
			printChar('\r');
			chanSel = 0;
		}
		else printChar(',');
		AD1CHS0bits.CH0SA = nextChanSel[chanSel];
	}
}

//---------------------------------------------------------------------------------------------------
// Interrupts

void __attribute__((interrupt, auto_psv))_U1TXInterrupt(void) {
	_U1TXIF = 0; 									// clear interrupt flag
	if (serialBufOutPos != serialBufInPos) {		// if data pending
		U1TXREG = serialBuf[serialBufOutPos];		// send data at output pointer
		asm volatile("INC.B _serialBufOutPos");		// increment index (overflow at 256)
	}	
	else _U1TXIE = 0;								// else if all data sent, prevent further interrupts
}

void __attribute__((interrupt, auto_psv))_U1RXInterrupt(void) {
	asm volatile("MOV _U1RXREG, WREG");				// disregard RX data else UART may be disabled
	_U1RXIF = 0;
}

//====================================================================================================
// END OF CODE
//====================================================================================================
