#version 330

in vec3 a_Position;
in float a_Radius;
in vec4 a_Color; 

out vec4 v_Color;

uniform float u_Time;

const float PI = 3.14159265359;

void main()
{
	float value = fract(u_Time)*2 -1 ;
	float rad = (value + 1) * PI;

	float x_value = cos(rad) * a_Radius;
	float y_value = sin(rad) * a_Radius;	

	vec4 newPosition = vec4(a_Position, 1);

	newPosition.xy = newPosition.xy + vec2(x_value, y_value);

	gl_Position = newPosition;

	v_Color = a_Color; 
}