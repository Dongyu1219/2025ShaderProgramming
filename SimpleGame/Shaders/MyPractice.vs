#version 330

in vec3 a_Position;

uniform float u_Time = 0;

const vec3 StartPos = vec3(-1, 0, 0);
const vec3 Velocity = vec3(2, 0, 0);
const float c_PI = 3.14159;

void line()
{
	float newTime =  abs (fract(u_Time) - 0.5) *2 ;
	vec4 newPosition;
	newPosition.xyz = (StartPos + a_Position) + Velocity * newTime ;
	newPosition.w = 1.0;

	gl_Position = newPosition;
}

void circle()
{
	float newTime = fract(u_Time) * c_PI * 2;
	vec2 trans = vec2(cos(newTime), sin(newTime));

	vec4 newPosition;
	newPosition.xy = a_Position.xy + trans;
	newPosition.zw = vec2(0.0, 1.0);

	gl_Position = newPosition;
}

void Basic()
{
	vec4 newPosition = vec4(a_Position, 1.0);
	gl_Position = newPosition;
}

void main()
{
	//line();
	circle();
	//Basic();

}	