#version 330

layout(location=0) out vec4 FragColor;

in vec4 v_Color; 

uniform vec4 u_Color;

void main()
{
	FragColor = v_Color;
}
