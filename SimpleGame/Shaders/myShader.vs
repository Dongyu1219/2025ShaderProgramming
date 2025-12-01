#version 330

in vec3 a_Position;
in float a_Value;
in vec4 a_Color; 
in float a_STime;
in vec3 Velocity;

out vec4 v_Color;

uniform float u_Time;
uniform vec3 u_Force;

const float c_PI = 3.141592;

void Q1 ()
{
	vec4 newPosition = vec4(a_Position, 1);

	//a_Value : 0~1 까지의 랜덤한 값
	// [1단계] X축 좌표 결정 (가로로 펼치기)
    // a_Value (0.0 ~ 1.0)  -->  X좌표 (-1.0 ~ 1.0)
	newPosition.x += 2*(a_Value - 0.5 );

	// [2단계] Y축 좌표 결정 (높이 계산하기)
    // X좌표에 파이(PI)를 곱해 각도로 만든 뒤 sin 값 구하기
	newPosition.y += sin( 2*(a_Value -0.5) * c_PI );
	
	gl_Position = newPosition;
	v_Color = a_Color;
}


void Q2()
{
	vec4 newPosition = vec4(a_Position, 1);

	newPosition.x += 2*(a_Value -0.5);
	// 옆으로 흐르는 파도 u_Time을 더한다. 
	newPosition.y += sin( 2*(a_Value -0.5) * c_PI + u_Time );

	gl_Position = newPosition;
	v_Color = a_Color;
}


void Q3()
{
	vec4 newPosition = vec4(a_Position, 1);

	newPosition.x += cos( 2*(a_Value -0.5) * c_PI + u_Time );
	newPosition.y += sin( 2*(a_Value -0.5) * c_PI + u_Time );

	gl_Position = newPosition;
	v_Color = a_Color;
}


void Q4()
{
	vec4 newPosition = vec4(a_Position, 1);

	newPosition.x += sin( 2*a_Value * c_PI ) * fract( u_Time );
	newPosition.y += cos( 2*a_Value * c_PI );

	gl_Position = newPosition;
	v_Color = a_Color;
}


void Q5()
{
	vec4 newPosition = vec4(a_Position, 1);

	newPosition.x += a_Value * sin( 2*a_Value * c_PI * 4 - u_Time);
	newPosition.y += a_Value * cos( 2*a_Value * c_PI * 4 - u_Time);

	gl_Position = newPosition;
	v_Color = a_Color;
}


void Q7()
{
	vec4 newPosition = vec4(a_Position, 1);

	float valueX = newPosition.x + 0.5;
	float valueY = newPosition.y + 0.5; 
	float greyScale = sin(2*c_PI*valueX * 4);
	greyScale += sin(2*c_PI*valueY * 4);

	v_Color - vec4(greyScale);
	v_Color.a = 0;

	gl_Position = newPosition;
}

void main()
{
	//Q1();
	//Q2();
	//Q3();
	//Q4();
	//Q5();
	Q7();
}