/**
	*******************************************************
	* @file					Check.c
	*	@brief				To check if it is normal
	* @param				Add: Object address   
	* @param        Data: Data need to check
	* @return       0: No Problem
	* @return       1: Lost Signal
	* @return       2: Wrong
	* @author       C
	* @date         2022-8-28 21:03
	*******************************************************
**/

#include "main.h"

int Check(uint8_t Add,uint8_t Arry[27])
{
	if((Arry[0]!=0x7e)||(Arry[1]!=0x7e)||(Arry[25]!=0x0d)||(Arry[26]!=0x0a)||(Arry[4]!=Add))
		return 1;
	else if((Arry[20]&Arry[21]&Arry[22])!=0x01)
		return 2;
	else
		return 0;
}