/**
	*******************************************************
	* @file					I2C.h
	*	@brief				Main part of I2C_Send
	* @param				None
	* @return       None
	* @author       C
	* @date         2022-8-15 15:22
	*******************************************************
**/

#ifndef _I2C_H_
#define _I2C_H_

#include "main.h"
#include "gpio.h"

void I2C_Start()
{
	HAL_GPIO_WritePin(GPIOH,GPIO_PIN_8,GPIO_PIN_SET);
	HAL_GPIO_WritePin(GPIOH,GPIO_PIN_7,GPIO_PIN_SET);
	__NOP();
	__NOP();
	__NOP();
	__NOP();
	__NOP();
	HAL_GPIO_WritePin(GPIOH,GPIO_PIN_8,GPIO_PIN_RESET);
	__NOP();
	__NOP();
	__NOP();
	__NOP();
	__NOP();
	HAL_GPIO_WritePin(GPIOH,GPIO_PIN_7,GPIO_PIN_RESET);
}

void I2C_Stop()
{
	HAL_GPIO_WritePin(GPIOH,GPIO_PIN_8,GPIO_PIN_RESET);
	HAL_GPIO_WritePin(GPIOH,GPIO_PIN_7,GPIO_PIN_SET);
	__NOP();
	__NOP();
	__NOP();
	__NOP();
	__NOP();
	HAL_GPIO_WritePin(GPIOH,GPIO_PIN_8,GPIO_PIN_SET);
	__NOP();
	__NOP();
	__NOP();
	__NOP();
	__NOP();
	HAL_GPIO_WritePin(GPIOH,GPIO_PIN_7,GPIO_PIN_RESET);
}

int I2C_Ack()
{
	int ack_bit;
	HAL_GPIO_WritePin(GPIOH,GPIO_PIN_8,GPIO_PIN_SET);
	__NOP();
	__NOP();
	HAL_GPIO_WritePin(GPIOH,GPIO_PIN_7,GPIO_PIN_SET);
	__NOP();
	__NOP();
	__NOP();
	__NOP();
	__NOP();
	ack_bit=HAL_GPIO_ReadPin(GPIOH,GPIO_PIN_8);
	__NOP();
	HAL_GPIO_WritePin(GPIOH,GPIO_PIN_7,GPIO_PIN_RESET);
	return ack_bit;
}

void I2C_Write(uint8_t x)
{
	unsigned char i;
	for(i=0;i<8;i++)
	{
		if((x&0x80)!=0)
		{
			HAL_GPIO_WritePin(GPIOH,GPIO_PIN_8,GPIO_PIN_SET);
		}
		else
		{
			HAL_GPIO_WritePin(GPIOH,GPIO_PIN_8,GPIO_PIN_RESET);
		}
		HAL_GPIO_WritePin(GPIOH,GPIO_PIN_7,GPIO_PIN_SET);
		__NOP();
		__NOP();
		__NOP();
		__NOP();
		__NOP();
		HAL_GPIO_WritePin(GPIOH,GPIO_PIN_7,GPIO_PIN_RESET);
		x<<=1;
	}
}
#endif
