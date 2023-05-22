/**
	*****************************************************************
	* @file					Query.c
	* @brief				To send query message
	* @param				Add Upconverter address   
	* @param        Counter Serial number
	* @return				None
	*	@author				C
	* @date					2022-8-14 16:54
	*****************************************************************
**/

#include "main.h"
#include <Function.h>

void Query(uint8_t Add,uint16_t Counter)
{
	uint8_t i,j;
	i=Counter;
	j=Counter>>8;
	//Swap the order of high and low bytes
	RS485_Send(0x7e);
	RS485_Send(0x7e);
	RS485_Send(0x0e);
	RS485_Send(0x00);
	RS485_Send(0xff);
	RS485_Send(0xff);
	RS485_Send(Add);
	RS485_Send(0x00);
	RS485_Send(0x01);
	RS485_Send(0x00);
	RS485_Send(i);
	RS485_Send(j);
	RS485_Send(0x0c);
	RS485_Send(0x00);
	RS485_Send(0x0d);
	RS485_Send(0x0a);
}