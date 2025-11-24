#version 330

	layout(location=0) out vec4 FragColor;

	in vec2 v_UV;

	const float C_PI = 3.14159265359;

	uniform sampler2D u_RGBTexture;
	uniform sampler2D u_DigitTexture;
	uniform sampler2D u_NumTexture;

	uniform float u_Time;


	void Test()
	{
		vec2 newUV = v_UV;
		float dx = 0.1 * sin(v_UV.y*2 * C_PI + u_Time ); 
		float dy = 0.1 * sin(v_UV.x*2 * C_PI + u_Time ); 

		newUV += vec2(dx, dy);

		vec4 sampledColor = texture(u_RGBTexture, newUV);

		FragColor = sampledColor;
	}


	void Circles()
	{
		vec2 newUV = v_UV;				//0 ~ 1 , left top = (0, 0)
		vec2 center = vec2(0.5, 0.5);
		vec4 newColor = vec4(0);

		float d = distance(newUV, center);
		
		float value = sin(d*4 * C_PI * 4 + u_Time);
		newColor = vec4(value);
		
		FragColor = newColor;
	}


	void Flag()
	{
		vec2 newUV = vec2(v_UV.x, 1- v_UV.y -0.5 ) ;			//가운데가 0 0 
		vec4 newColor = vec4(0);

		float width = 0.2 * ( 1 - newUV.x ) ;

		float sinValue = v_UV.x * 0.2 * sin(newUV.x * 2 * C_PI - u_Time);

		//가로줄
		if(newUV.y < sinValue + width  && newUV.y > sinValue - width)
		{
			newColor = vec4(1);
		}
		else
		{
			discard;
		}

		FragColor = newColor;
	}


	void Q1() 
	{
		vec2 newUV = vec2(v_UV.x, v_UV.y) ;	//0~1, left bottom ( 0 0 )

		float x = newUV.x;		//0~1
		float y = 1 - abs(2 * (newUV.y - 0.5)) ;	//-0.5 ~ 0.5  -1~ 1 	0~1~0

		vec4 newColor = texture(u_RGBTexture, vec2(x, y));

		FragColor = newColor;
	}


	void Q2() 
	{
		vec2 newUV = vec2(v_UV.x, v_UV.y) ;		//0~1, left bottom ( 0 0 )

		float x = fract(3 * newUV.x);			//0~3	0~1,0~1,0~1
		float y = (2-floor(newUV.x*3))/3 + v_UV.y/3;			

		vec4 newColor = texture(u_RGBTexture, vec2(x, y));

		FragColor = newColor;
	}


	void Q3() 
	{
		vec2 newUV = vec2(v_UV.x, v_UV.y) ;		//0~1, left bottom ( 0 0 )

		float x = fract(3 * newUV.x);			//0~3	0~1,0~1,0~1
		float y = (floor(newUV.x*3))/3 + 1 + v_UV.y/3;			

		vec4 newColor = texture(u_RGBTexture, vec2(x, y));

		FragColor = newColor;
	}


	void myexample() 
	{
		vec2 newUV = vec2(v_UV.x, v_UV.y) ;		//0~1, left bottom ( 0 0 )

		float x = fract(3 * newUV.x);			//0~3	0~1,0~1,0~1
		float y = (floor(newUV.x*3))/3 + 1 + v_UV.y;			

		vec4 newColor = texture(u_RGBTexture, vec2(x, y));

		FragColor = newColor;
	}


	void Brick_Horizontal() 
	{
		vec2 newUV = vec2(v_UV.x, v_UV.y) ;		//0~1, left bottom ( 0 0 )
		float rCount = 3;			//row Count
		float sAmount = 0.5;		//shift Amount
		float x = fract(rCount * newUV.x) + floor( newUV.y* rCount) * sAmount;	// + floor( newUV.y* 2+ 1) * 0.5		//괄호안 공부하기 
		float y = fract(rCount * newUV.y);			//0~1,0~1

		vec4 newColor = texture(u_RGBTexture, vec2(x, y));

		FragColor = newColor;
	}


	void Brick_Vertical() 
	{
		vec2 newUV = vec2(v_UV.x, v_UV.y) ;		//0~1, left bottom ( 0 0 )

		float x = fract(2 * newUV.x);
		float y = fract(2 * newUV.y) +  floor( newUV.x* 2) * 0.5 ;			//0~1,0~1

		vec4 newColor = texture(u_RGBTexture, vec2(x, y));

		FragColor = newColor;
	}


void Digit()
{
	FragColor = texture(u_DigitTexture, v_UV);
}


void Digit_Num()
{
	int digit = int(u_Time) % 10;

	int tileIndex = (digit + 9) % 10;

	float offsetX = float(tileIndex % 5 ) / 5;
	float offsetY = floor(tileIndex / 5 )/2 ;

	float tx = v_UV.x/5 + offsetX;
	float ty = v_UV.y/2 + offsetY;
	FragColor = texture(u_NumTexture, vec2(tx, ty));
}


void Digit_Num_AI()
{
	// 1. 몇 자리 숫자로 만들지 설정 (5자리)
	float digitCount = 5.0;

	// 2. 현재 픽셀이 몇 번째 자릿수 칸에 있는지 계산 (0 ~ 4)
	// 예: v_UV.x가 0.1이면 0번째(만 단위), 0.9면 4번째(일 단위)
	float colIndex = floor(v_UV.x * digitCount);

	// 3. 자릿수에 맞는 나누기 값 계산 (10000, 1000, 100, 10, 1)
	// colIndex 0 -> 10^4 (10000)
	// colIndex 4 -> 10^0 (1)
	float power = (digitCount - 1.0) - colIndex;
	float divisor = pow(10.0, power);

	// 4. 해당 자릿수의 숫자 추출
	// (전체시간 / 나누기값) % 10
	// int 변환 시 부동소수점 오차 방지를 위해 + 0.001 추가
	int currentNum = int(u_Time / divisor + 0.001) % 10;

	// 5. 텍스처 아틀라스 매핑 (기존 로직 유지)
	int tileIndex = (currentNum + 9) % 10;

	// 6. UV 좌표 보정 (5등분 된 칸을 다시 0~1로 늘려줌)
	vec2 localUV = v_UV;
	localUV.x = fract(v_UV.x * digitCount); 

	// 7. 아틀라스 내 좌표 계산 (5x2 구조)
	float offsetX = float(tileIndex % 5) / 5.0;
	float offsetY = floor(float(tileIndex) / 5.0) / 2.0;

	float tx = localUV.x / 5.0 + offsetX;
	float ty = localUV.y / 2.0 + offsetY;

	FragColor = texture(u_NumTexture, vec2(tx, ty));
}

	void main()
	{
		//Test();
		//Circles();
		//Flag();
		//Q1();
		//Q2();
		//Q3();
		//Brick_Horizontal();
		//Brick_Vertical();
		//Digit();
		//Digit_Num();
		Digit_Num_AI();
	}
	
