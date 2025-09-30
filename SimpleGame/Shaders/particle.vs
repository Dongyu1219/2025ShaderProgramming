#version 330

in vec3 a_Position;
in float a_Value;
in vec4 a_Color; 
in float a_STime;
in vec3 Velocity;
in float a_lifeTime;
in float a_mass; 
in float a_period;

out vec4 v_Color;

uniform float u_Time;
uniform vec3 u_Force;

const float c_PI = 3.141592;
const vec2 c_Gravity = vec2(0, -9.8);

void raining()
{
	float lifeTime = a_lifeTime;
	float newAlpha = 1.0;
	vec4 newPosition = vec4(a_Position, 1);
	float newTime = u_Time - a_STime; 

	if (newTime > 0)
	{
	float t = fract(newTime/lifeTime)*lifeTime;				// t: 0 ~ lifeTime
	float tt = t*t;
	
	float forceX = u_Force.x *10 + c_Gravity.x*a_mass;
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


void sinParticle()
{
	vec4 centerC = vec4(1.0, 0.0, 0.0, 1.0);
	vec4 borderC = vec4(1.0, 1.0, 1.0, 0.0);
	

	float newTime = u_Time - a_STime ;
	float lifeTime = a_lifeTime;
	vec4 newPosition = vec4(a_Position, 1);
	float newAlpha = 1.0;
	vec4 newColor = a_Color;

	if (newTime >0) 
	{
	float period = a_period * 10;
	float t = fract(newTime/lifeTime) * lifeTime ;
	float tt = t*t;  
	float x = 2*t-1 ;
	float y = t * sin(2*t*c_PI * period) * ((a_Value-0.5) * 2) ; 
	y *= sin(fract(newTime/lifeTime)* c_PI );			
	newPosition.xy += vec2(x, y);
	newAlpha = 1.0 - t/lifeTime;

	newColor = mix(centerC, borderC, abs(y*4));
	}
	else 
	{
		newPosition.xy += vec2(-10000,0);
	}

	gl_Position = newPosition;
	v_Color = vec4(newColor.rgb, newAlpha); 

}


void circleParticle()
{
	vec4 centerC = vec4(1.0, 0.0, 0.0, 1.0);
	vec4 borderC = vec4(1.0, 1.0, 1.0, 0.0);
	

	float newTime = u_Time - a_STime ;
	float lifeTime = a_lifeTime;
	vec4 newPosition = vec4(a_Position, 1);
	float newAlpha = 1.0;

	if (newTime >0) 
	{
	float t = fract(newTime/lifeTime) * lifeTime ;
	float tt = t*t;
	
	float x = sin(a_Value * 2 * c_PI);
	float y = cos(a_Value * 2 * c_PI); 

	float newX = x + 0.5*c_Gravity.x*tt;
	float newy = y + 0.5*c_Gravity.y*tt;

	newPosition.xy += vec2(newX, newy);
	newAlpha = 1.0 - t/lifeTime;


	}

	else 
	{
		newPosition.xy += vec2(-10000,0);
	}

	gl_Position = newPosition;
	v_Color = vec4(a_Color.rgb, newAlpha); 

}




void main()
{
	//raining();
	//sinParticle();
	circleParticle();
}


