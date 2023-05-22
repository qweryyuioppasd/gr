/**
	************************************************************
	* @file					RS485_Send.c
	* @brief				To send a RS485 signal
	* @param				TxByte Data to send
	* @return				None
	* @author				C
	* @date					2022-8-14 16:27
	************************************************************
**/

#include "gpio.h"
#include "usart.h"

void RS485_Send(uint8_t TxByte)
{
	HAL_GPIO_WritePin(GPIOA,GPIO_PIN_11,GPIO_PIN_SET);//set to send mode
	HAL_UART_Transmit(&huart1,(uint8_t *)&TxByte,1,0xff);
	HAL_GPIO_WritePin(GPIOA,GPIO_PIN_11,GPIO_PIN_RESET);
}