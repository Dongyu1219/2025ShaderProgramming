	#version 330

	layout(location=0) out vec4 FragColor;

	in vec2 v_UV;

	const float C_PI = 3.14159265359;

	uniform float u_time;

	void main()
	{
		vec4 newColor = vec4(0);
		float xValue = pow ( abs(sin( v_UV.x * 2 * C_PI *4)), 10 ) ;
		float yValue = pow ( abs(sin( v_UV.y * 2 * C_PI *4)), 10 ) ;

		//newColor= vec4(xValue, yValue, 0, 0);
		newColor= vec4(xValue + yValue);
	
		FragColor = newColor;
	}
	
