	#version 330

	layout(location=0) out vec4 FragColor;

	in vec2 v_UV;

	const float C_PI = 3.14159265359;

	uniform sampler2D u_RGBTexture;

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


	void main()
	{
		//Test();
		//Circles();
		//Flag();
		//Q1();
		//Q2();
		Q3();
	}
	
