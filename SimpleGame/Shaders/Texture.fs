#version 330

layout(location=0) out vec4 FragColor;

uniform sampler2D u_TexID;
uniform float u_Time;

in vec2 v_Tex; 


// --- 상수 및 유틸리티 함수 정의 ---
const float PI = 3.14159265359;

// 난수 생성 함수 (의사 난수)
float rand(vec2 co) {
    return fract(sin(dot(co.xy ,vec2(12.9898,78.233))) * 43758.5453);
}

// 2D 랜덤 벡터 생성 함수
vec2 rand2(vec2 p) {
    return fract(sin(vec2(dot(p,vec2(127.1,311.7)),dot(p,vec2(269.5,183.3))))*43758.5453);
}

// --- 물방울 효과 함수 ---
vec4 Lens()
{
    vec2 uv = v_Tex;
    
    // 1. 설정값 조절
    float gridSize = 8.0;           // 화면을 몇 개의 격자로 나눌 것인가 (클수록 물방울이 많고 작아짐)
    float refractionStrength = 0.03; // 굴절 강도 (물방울이 얼마나 볼록한지)
    float specularStrength = 2.0;   // 반사광 강도 (물방울의 윤기)
    float timeScale = 0.0;          // 시간 값 (u_Time이 연결되어 있다면 u_Time 사용)
    // float timeScale = u_Time * 0.1; // 시간이 흐르면 물방울 위치가 조금씩 변하게 하고 싶을 때 사용

    // Y축 보정 (필요한 경우 주석 해제)
    // uv.y = 1.0 - uv.y;

    // 2. 격자 공간 계산
    vec2 scaledUV = uv * gridSize;
    vec2 gridID = floor(scaledUV);        // 각 격자의 고유 ID (0,0), (0,1)...
    vec2 gridUV = fract(scaledUV) - 0.5;  // 격자 내부 좌표 (-0.5 ~ 0.5)

    // 3. 랜덤성 부여 (위치 및 크기)
    vec2 randomVal = rand2(gridID + floor(timeScale)); // 격자 ID 기반 랜덤값 생성
    
    // 물방울 중심점 랜덤 오프셋 (-0.25 ~ 0.25 범위로 치우치게)
    vec2 offset = (randomVal - 0.5) * 0.5; 
    
    // 현재 픽셀에서 물방울 중심까지의 벡터 및 거리
    vec2 vecToCenter = gridUV - offset;
    float dist = length(vecToCenter);

    // 물방울 반지름 랜덤 설정 (0.15 ~ 0.4)
    float radius = 0.15 + randomVal.x * 0.25;

    // 4. 물방울 모양 마스크 생성 (중심일수록 1, 가장자리로 갈수록 0)
    // smoothstep을 사용하여 부드러운 경계면 생성
    float mask = smoothstep(radius, radius - 0.05, dist);

    // 물방울 영역이 아니라면 원래 텍스처 출력
    if (mask < 0.01) {
        return texture(u_TexID, uv);
    }

    // 5. 굴절(Refraction) 계산
    // 물방울 표면의 기울기(Normal)를 근사 계산
    vec2 normal = normalize(vecToCenter) * sin(dist / radius * PI * 0.5);
    
    // 기울기에 따라 텍스처 좌표를 왜곡시킴 (마스크를 곱해 물방울 내부에만 적용)
    vec2 refractedUV = uv - normal * refractionStrength * mask;
    vec4 baseColor = texture(u_TexID, refractedUV);

    // 6. 반사광(Specular Highlight) 계산 (옵션)
    vec2 lightDir = normalize(vec2(-0.5, 0.5)); // 빛이 들어오는 방향 (좌상단)
    // 표면 법선 벡터와 빛 방향 벡터의 내적을 이용해 하이라이트 계산
    float specular = pow(max(0.0, dot(normal, lightDir)), 20.0) * specularStrength;
    specular *= mask; // 마스크 적용하여 물방울 위에만 맺히게 함
     
    // 최종 색상: 굴절된 텍스처 + 반사광 (반사광은 흰색으로 더함)
    return baseColor + vec4(specular);
}


vec4 Pixel()
{   
    float resolution = (sin(u_Time)+1) * 100.0;
    float tx = floor(v_Tex.x * resolution)/resolution;
    float ty = floor(v_Tex.y * resolution)/resolution; 
    return texture(u_TexID, vec2(tx, ty));
}


void main()
{
	//FragColor = texture(u_TexID, vec2(v_Tex.x, 1-v_Tex.y));
	//FragColor = texture(u_TexID, vec2( 0, 1 ) );
    FragColor =Pixel();
}
