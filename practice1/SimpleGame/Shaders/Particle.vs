#version 330

in vec3 a_Position;
in float a_Radius;
in vec4 a_Color; 
in float a_STime;
in vec3 Velocity;
in float a_lifeTime;
in float a_mass; 

out vec4 v_Color;

uniform float u_Time;
uniform vec3 u_Force;

const float c_PI = 3.141592;
const vec2 c_Gravity = vec2(0, -9.8);

void main()
{
	float lifeTime = a_lifeTime;
	float newAlpha = 1.0;
	vec4 newPosition = vec4(a_Position, 1);
	float newTime = u_Time - a_STime; 
	

	if (newTime > 0)
	{
	float t = fract(newTime/lifeTime)*lifeTime;				// t: 0 ~ lifeTime
	float tt = t*t;
	
	float forceX = u_Force.x *30 + c_Gravity.x*a_mass;
	float forceY = u_Force.y + c_Gravity.y*a_mass;

	float aX = forceX/a_mass;
	float aY = forceY/a_mass;

	float x_value = Velocity.x * t + 0.5*aX*tt;								
	float y_value = Velocity.y * t + 0.5*aY*tt;	

	newPosition.xy += vec2(x_value , y_value);
	newAlpha = 1.0 - t/lifeTime;
	}

	else
	{
		newPosition.xy += vec2(-10000,0);
	}
	

	gl_Position = newPosition;

	v_Color = vec4(a_Color.rgb, newAlpha); 
	}

