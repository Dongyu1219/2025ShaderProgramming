#version 330

layout(location=0) out vec4 FragColor;

in vec4 v_Color; 

uniform vec4 u_Color;
uniform float u_Time;

const float c_PI = 3.14;

void FullCircle()
{
	vec4 newColor = vec4(1.0, 1.0, 1.0, 1.0);
	float r = 0.5;
	float dist = distance(v_Color.xy, vec2(0.5, 0.5));
	if (dist < r)
	{
		newColor = vec4(1.0, 1.0, 1.0, 1.0);
	}
	else{
		newColor = vec4(0,0.5,0,0);
	}
	FragColor = newColor;
}

void EmptyCircle()
{
	vec4 newColor = vec4(1.0, 1.0, 1.0, 1.0);
	float r = 0.5;
	float width = 0.05;
	vec2 center = vec2(0.5, 0.5);
	float dist = distance(v_Color.xy, center);
	if(dist > r - width && dist < r)
	{
		newColor = vec4(1.0, 1.0, 1.0, 1.0);
	}
	else{
		newColor = vec4(0,0.5,0,0);
	}
		FragColor = newColor;
}

//Áß¿ä
void ManyCircles()
{
	float circleCount = 3; 
	vec2 center = vec2(0.5, 0.5);

	float dist = distance (v_Color.xy, center);
	float input1 = circleCount * c_PI * 4 * dist - u_Time;
		
	float sinValue = pow(sin(input1), 16) ;
	FragColor = vec4(sinValue);

}

void sinGraph()
{
	vec2 newPosition = vec2(v_Color.x * 2 * c_PI, v_Color.y * 2 -1 ) ;
	float sinValue = sin(newPosition.x);
	float width = 0.02;
	if (sinValue < newPosition.y + width && sinValue > newPosition.y)
		FragColor = vec4(1.0, 1.0, 1.0, 1.0);
	else
		FragColor = vec4(0,0,0,0);
}


void Flag()
{
	vec2 newPosition = vec2(v_Color.x * 2 * c_PI, v_Color.y * 2 -1 ) ;
	float amp = 0.2;
	//float sinValue = 0.2 * sin(newPosition.x - u_Time) - 0.2 * sin(-u_Time);
	float sinValue = v_Color.x* amp * sin(newPosition.x * 3 - u_Time * 3);
	float width = 0.4;
	width = width * (1 - v_Color.x);
	if (sinValue < newPosition.y + width && sinValue > newPosition.y - width)
		FragColor = vec4((sinValue+1)/2);
	else
		discard;
		//FragColor = vec4(0,0,0,0);
}

void main()
{
	//FullCircle();
	//EmptyCircle();
	//ManyCircles();
	//sinGraph();
	Flag();
}
