/**
	************************************************
	* @file					Function.h
	* @brief				Declare function
	* @param				None
	* @return       None
	*	@author       C
	* @date         2022-8-14 16:39
	************************************************
**/

#ifndef _FUNCTION_H_
#define _FUNCTION_H_

#include "main.h"

void RS485_Send(uint8_t TxByte);
void Query(uint8_t Add,uint16_t Counter);
void I2C_Send(uint8_t Add,uint16_t Data);
int Change(int i,int j);
int Check(uint8_t Add,uint8_t Arry[27]);

#endif