/**
	*****************************************************************************************
	* @file					I2C_Send.c
	* @brief				To send a I2C signal
	* @param				Add Object address    
	* @param        Data1 Data to send high 
  * @param        Data2 Data to send low
	* @return				None
	* @author			  C
	* @date					2022-8-15 15:27
	*****************************************************************************************
**/

#include <I2C.h>

void I2C_Send(uint8_t Add,uint16_t Data)
{
	uint8_t Data1,Data2;
	Data1=(Data&0xff);
	Data2=((Data>>8)&0xff);
	I2C_Start();
	I2C_Write(Add);
	I2C_Ack();
	I2C_Write(0x06);
	I2C_Ack();
	I2C_Write(0x00);
	I2C_Ack();
	I2C_Stop();
	
	I2C_Start();
	I2C_Write(Add);
	I2C_Ack();
	I2C_Write(0x07);
	I2C_Ack();
	I2C_Write(0x00);
	I2C_Ack();
	I2C_Stop();
	
	I2C_Start();
	I2C_Write(Add);
	I2C_Ack();
	I2C_Write(0x02);
	I2C_Ack();
	I2C_Write(Data1);
	I2C_Ack();
	I2C_Stop();
	
	I2C_Start();
	I2C_Write(Add);
	I2C_Ack();
	I2C_Write(0x03);
	I2C_Ack();
	I2C_Write(Data2);
	I2C_Ack();
	I2C_Stop();
}
