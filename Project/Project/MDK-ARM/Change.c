/**
	**********************************************************
	* @file					Change.c
	*	@brief				The decision making
	* @param				i Which consition  
  * @param       	j Which was broken
	* @return       State to change
	* @author       C
	* @date         2022-8-16 17:42
	**********************************************************
**/

int Change(int i,int j)
{
	unsigned char r;
	
		if(i==0)
		{
			if(j==0)
			{
				r=5;
				return r;
			}
			else if(j==1)
			{
				r=1;
				return r;
			}
		}
		else if(i==1)
		{
			if(j==0)
			{
				r=3;
				return r;
			}
			else if(j==2)
			{
				r=0;
				return r;
			}
		}
		else if(i==2)
		{
			if(j==1)
			{
				r=4;
				return r;
			}
			else if(j==0)
			{
				r=3;
				return r;
			}
		}
		else if(i==3)
		{
			if(j==1)
			{
				r=1;
				return r;
			}
			else if(j==2)
			{
				r=2;
				return r;
			}
		}
		else if(i==4)
		{
			if(j==2)
			{
				r=2;
				return r;
			}
			else if(j==0)
			{
				r=5;
				return r;
			}
		}
		else if(i==5)
		{
			if(j==2)
			{
				r=0;
				return r;
			}
			else if(j==1)
			{
				r=4;
				return r;
			}
		}
		return 0;
}