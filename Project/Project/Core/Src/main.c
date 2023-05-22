/* USER CODE BEGIN Header */
/**
  ******************************************************************************
  * @file           main.c
  * @brief          Main program body
	* @version				primer
	* @author					C
	* @date						2022-08-29 11:04
	* @note           no lamp signal for stand by
  ******************************************************************************
  * @attention
  *
  * Copyright (c) 2022 STMicroelectronics.
  * All rights reserved.
  *
  * This software is licensed under terms that can be found in the LICENSE file
  * in the root directory of this software component.
  * If no LICENSE file comes with this software, it is provided AS-IS.
  *
  ******************************************************************************
  */
/* USER CODE END Header */
/* Includes ------------------------------------------------------------------*/
#include "main.h"
#include "usart.h"
#include "gpio.h"

/* Private includes ----------------------------------------------------------*/
/* USER CODE BEGIN Includes */
#include <Function.h>
#include <Table.h>
/* USER CODE END Includes */

/* Private typedef -----------------------------------------------------------*/
/* USER CODE BEGIN PTD */
/* USER CODE END PTD */

/* Private define ------------------------------------------------------------*/
/* USER CODE BEGIN PD */
/*register address*/
#define T1 0x40
#define T2 0x42
#define T5 0x44
/* USER CODE END PD */

/* Private macro -------------------------------------------------------------*/
/* USER CODE BEGIN PM */
/* USER CODE END PM */

/* Private variables ---------------------------------------------------------*/

/* USER CODE BEGIN PV */
unsigned char Wrong_Wh[3],Signal_Lost[3];//feature
uint16_t Counter=0x0000;//counter
uint8_t RxData[27];//Receive data
uint16_t LED_C;//Light signal
uint16_t Light;//Intermediate variables
unsigned char State;//condition
unsigned char Wrong_Num;//Number of fualt
unsigned char Strobe;//Blink mode
/* USER CODE END PV */

/* Private function prototypes -----------------------------------------------*/
void SystemClock_Config(void);
/* USER CODE BEGIN PFP */
/*interrupt callback*/
void HAL_UART_RxCpltCallback(UART_HandleTypeDef *huart)
{
	HAL_UART_Receive_IT(&huart1,(uint8_t *)&RxData,27);
}
/* USER CODE END PFP */

/* Private user code ---------------------------------------------------------*/
/* USER CODE BEGIN 0 */
/* USER CODE END 0 */

/**
  * @brief  The application entry point.
  * @retval int
  */
int main(void)
{
  /* USER CODE BEGIN 1 */
  /* USER CODE END 1 */

  /* MCU Configuration--------------------------------------------------------*/

  /* Reset of all peripherals, Initializes the Flash interface and the Systick. */
  HAL_Init();

  /* USER CODE BEGIN Init */
  /* USER CODE END Init */

  /* Configure the system clock */
  SystemClock_Config();

  /* USER CODE BEGIN SysInit */
  /* USER CODE END SysInit */

  /* Initialize all configured peripherals */
  MX_GPIO_Init();
  MX_USART1_UART_Init();
  /* USER CODE BEGIN 2 */
  /* USER CODE END 2 */

  /* Infinite loop */
	State=0;
	I2C_Send(T1,Switch[State]);
	I2C_Send(T2,Switch[State]);

	HAL_UART_Receive_IT(&huart1,(uint8_t *)&RxData,27);
  /* USER CODE BEGIN WHILE */
  while(1)
  {
		LED_C=0xcbf2;
		Strobe=0;
		Wrong_Num=0;
		//1//
		{
			if(Signal_Lost[0]==1)
			{
				LED_C=LED_C&0xcbf2;
			}
			else if(Wrong_Wh[0]==1)
			{
				LED_C=LED_C&0xcbd2;
			}
			else
			{
				switch (State)
				{
					case 0:
					case 1:LED_C=LED_C&0xcbe2;Strobe=0;break;
					case 2:
					case 4:LED_C=LED_C&0xcbc2;Strobe=0;break;
					case 3:
					case 5:Strobe=1;break;
				}
			}
		}
		
		//2//
		{
			if(Signal_Lost[1]==1)
			{
				LED_C=LED_C&0xcbf2;
			}
			else if(Wrong_Wh[1]==1)
			{	
				LED_C=LED_C&0xcb72;
			}
			else
			{
				switch (State)
				{
					case 0:
					case 5:LED_C=LED_C&0xcbf2;Strobe=0;break;
					case 2:
					case 3:LED_C=LED_C&0xcbb2;Strobe=0;break;
					case 1:
					case 4:Strobe=2;break;
				}
			}
		}
		
		//3//
		{
			if(Signal_Lost[2]==1)
			{
				LED_C=LED_C&0xcbf2;
			}
			else if(Wrong_Wh[2]==1)
			{
				LED_C=LED_C&0xc9f2;
			}
			else
			{
				switch (State)
				{
					case 4:
					case 5:LED_C=LED_C&0xcaf2;Strobe=0;break;
					case 1:
					case 3:LED_C=LED_C&0xcbf2;Strobe=0;break;
					case 0:
					case 2:Strobe=3;break;
				}
			}
		}
		Light=LED_C;
		for(int i=0;i<3;i++)
		{
			Wrong_Wh[i]=0;
			Signal_Lost[i]=0;
		}
		
		/*1*/
		switch (Strobe)
		{
			case 0:
			case 1:
			case 2:
			case 3:I2C_Send(T5,Light);break;
		}
		
		for(int i=0;i<27;i++)
		{
			RxData[i]=0x00;
		}
		Query(0x01,Counter);
		HAL_Delay(1000);
		switch (Check(0x01,RxData))
		{
			case 0:Wrong_Wh[0]=0;Signal_Lost[0]=0;break;
			case 1:Signal_Lost[0]=1;Wrong_Num++;break;
			case 2:Wrong_Wh[0]=1;Wrong_Num++;break;
		}
		/*2*/
		switch (Strobe)
		{
			case 0:I2C_Send(T5,Light);break;
			case 1:Light=Light&0x37dd;I2C_Send(T5,Light);break;
			case 2:Light=Light&0x377d ;I2C_Send(T5,Light);break;
			case 3:Light=Light&0x35fd;I2C_Send(T5,Light);break;
		}
		
		for(int i=0;i<27;i++)
		{
			RxData[i]=0x00;
		}
		Query(0x02,Counter);
		HAL_Delay(1000);
		switch (Check(0x02,RxData))
		{
			case 0:Wrong_Wh[1]=0;Signal_Lost[1]=0;break;
			case 1:Signal_Lost[1]=1;Wrong_Num++;break;
			case 2:Wrong_Wh[1]=1;Wrong_Num++;break;
		}
		/*3*/
		switch (Strobe)
		{
			case 0:
			case 1:
			case 2:
			case 3:I2C_Send(T5,LED_C);break;
		}
		for(int i=0;i<27;i++)
		RxData[i]=0x00;
		Query(0x03,Counter);
		HAL_Delay(1000);
		switch (Check(0x03,RxData))
		{
			case 0:Wrong_Wh[2]=0;Signal_Lost[2]=0;break;
			case 1:Signal_Lost[2]=1;Wrong_Num++;break;
			case 2:Wrong_Wh[2]=1;Wrong_Num++;break;
		}
		
		switch (Strobe)
		{
			case 0:
			case 1:
			case 2:
			case 3:I2C_Send(T5,Light);break;
		}
		
		/*decide*/
		if(Wrong_Num==1)
		{
			for(int i=0;i<3;i++)
			{
				if((Wrong_Wh[i]==1)||(Signal_Lost[i]==1))
				{
					if(State==0)
					{
						if(i==0)
						{
							State=5;
						}
						else if(i==1)
						{
							State=1;
						}
					}
					else if(State==1)
					{
						if(i==0)
						{
							State=3;
						}
						else if(i==2)
						{
							State=0;
						}
					}
					else if(State==2)
					{
						if(i==1)
						{
							State=4;
						}
						else if(i==0)
						{
							State=3;
						}
					}
					else if(State==3)
					{
						if(i==1)
						{
							State=1;
						}
						else if(i==2)
						{
							State=2;
						}
					}
					else if(State==4)
					{
						if(i==2)
						{
							State=2;
						}
						else if(i==0)
						{
							State=5;
						}
					}
					else if(State==5)
					{
						if(i==2)
						{
							State=0;
						}
						else if(i==1)
						{
							State=4;
						}
					}
				}
			}
			I2C_Send(T1,Switch[State]);
			I2C_Send(T2,Switch[State]);
		}
		HAL_Delay(1000);
		//
		Counter++;
		if(Counter>0xffff)
			Counter=0;
    /* USER CODE BEGIN 3 */
  }
  /* USER CODE END 3 */
}

/**
  * @brief System Clock Configuration
  * @retval None
  */
void SystemClock_Config(void)
{
  RCC_OscInitTypeDef RCC_OscInitStruct = {0};
  RCC_ClkInitTypeDef RCC_ClkInitStruct = {0};

  /** Configure the main internal regulator output voltage
  */
  __HAL_RCC_PWR_CLK_ENABLE();
  __HAL_PWR_VOLTAGESCALING_CONFIG(PWR_REGULATOR_VOLTAGE_SCALE3);

  /** Initializes the RCC Oscillators according to the specified parameters
  * in the RCC_OscInitTypeDef structure.
  */
  RCC_OscInitStruct.OscillatorType = RCC_OSCILLATORTYPE_HSE;
  RCC_OscInitStruct.HSEState = RCC_HSE_ON;
  RCC_OscInitStruct.PLL.PLLState = RCC_PLL_ON;
  RCC_OscInitStruct.PLL.PLLSource = RCC_PLLSOURCE_HSE;
  RCC_OscInitStruct.PLL.PLLM = 25;
  RCC_OscInitStruct.PLL.PLLN = 144;
  RCC_OscInitStruct.PLL.PLLP = RCC_PLLP_DIV2;
  RCC_OscInitStruct.PLL.PLLQ = 4;
  if (HAL_RCC_OscConfig(&RCC_OscInitStruct) != HAL_OK)
  {
    Error_Handler();
  }

  /** Initializes the CPU, AHB and APB buses clocks
  */
  RCC_ClkInitStruct.ClockType = RCC_CLOCKTYPE_HCLK|RCC_CLOCKTYPE_SYSCLK
                              |RCC_CLOCKTYPE_PCLK1|RCC_CLOCKTYPE_PCLK2;
  RCC_ClkInitStruct.SYSCLKSource = RCC_SYSCLKSOURCE_PLLCLK;
  RCC_ClkInitStruct.AHBCLKDivider = RCC_SYSCLK_DIV16;
  RCC_ClkInitStruct.APB1CLKDivider = RCC_HCLK_DIV1;
  RCC_ClkInitStruct.APB2CLKDivider = RCC_HCLK_DIV1;

  if (HAL_RCC_ClockConfig(&RCC_ClkInitStruct, FLASH_LATENCY_0) != HAL_OK)
  {
    Error_Handler();
  }
}

/* USER CODE BEGIN 4 */

/* USER CODE END 4 */

/**
  * @brief  This function is executed in case of error occurrence.
  * @retval None
  */
void Error_Handler(void)
{
  /* USER CODE BEGIN Error_Handler_Debug */
  /* User can add his own implementation to report the HAL error return state */
  __disable_irq();
  while (1)
  {
		
  }
  /* USER CODE END Error_Handler_Debug */
}

#ifdef  USE_FULL_ASSERT
/**
  * @brief  Reports the name of the source file and the source line number
  *         where the assert_param error has occurred.
  * @param  file: pointer to the source file name
  * @param  line: assert_param error line source number
  * @retval None
  */
void assert_failed(uint8_t *file, uint32_t line)
{
  /* USER CODE BEGIN 6 */
  /* User can add his own implementation to report the file name and line number,
     ex: printf("Wrong parameters value: file %s on line %d\r\n", file, line) */
  /* USER CODE END 6 */
}
#endif /* USE_FULL_ASSERT */
