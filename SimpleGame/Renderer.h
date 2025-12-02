#pragma once

#include <string>
#include <cstdlib>
#include <fstream>
#include <iostream>
#include <cassert>

#include "Dependencies\glew.h"
#include "LoadPng.h"

class Renderer
{
public:
	Renderer(int windowSizeX, int windowSizeY);
	~Renderer();

	bool IsInitialized();
	void RealoadAllShaderPrograms();
	void DrawSolidRect(float x, float y, float z, float size, float r, float g, float b, float a);
	void DrawTest();
	void DrawParticles();
	void DrawMySelf();
	void DrawGridMesh();
	void DrawFullScreenColor(float r, float g, float b, float a);
	void DrawFS();
	void DrawTexture(float x, float y, float sx, float sy, GLuint TexID, GLuint TexID1, GLuint method);
	void DrawDebugTextures();
	void DrawFBOs();
	void DrawBloomParicle();

private:
	void Initialize(int windowSizeX, int windowSizeY);
	void CompileAllShaderPrograms();
	void DeleteAllShaderPrograms();
	bool ReadFile(char* filename, std::string *target);
	void CreateGridMesh(int x, int y);
	void AddShader(GLuint ShaderProgram, const char* pShaderText, GLenum ShaderType);
	GLuint CompileShaders(char* filenameVS, char* filenameFS);
	void CreateVertexBufferObjects();
	void GetGLPosition(float x, float y, float *newX, float *newY);
	//
	void GenerateParticles(int numParticle);
	GLuint CreatePngTexture(char* filePath, GLuint samplingMethod);
	void CreateFBOS();


	bool m_Initialized = false;
	
	unsigned int m_WindowSizeX = 0;
	unsigned int m_WindowSizeY = 0;

	GLuint m_VBORect = 0;
	GLuint m_SolidRectShader = 0;

	//lecture 2
	GLuint m_VBOTestPos = 0;
	GLuint m_VBOTestColor = 0;

	//lecture 3
	GLuint m_TestShader = 0;

	//Time
	float m_Time = 0;

	// Particle
	GLuint m_particleShader = 0;
	GLuint m_VBOParticle = 0;
	GLuint m_VBOParticleVertexCount = 0;

	//Grid Mesh
	GLuint m_GridMeshShader = 0;
	GLuint m_GridMeshVertexCount = 0;
	GLuint m_GridMeshVBO = 0;

	//Full screen 
	GLuint m_VBOFullScreen = 0;
	GLuint m_FullSceenShader = 0;

	//For rainDrop effect
	float m_Points[100 * 4];


	//For Fragment shader
	GLuint m_VBOFS = 0;
	GLuint m_FSShader = 0;

	//Textures
	GLuint m_RGBTexture = 0; 
	GLuint m_ParticleTexture = 0;

	//num
	GLuint m_0Texture = 0;
	GLuint m_1Texture = 0;
	GLuint m_2Texture = 0;
	GLuint m_3Texture = 0;
	GLuint m_4Texture = 0;
	GLuint m_5Texture = 0;
	GLuint m_6Texture = 0;
	GLuint m_7Texture = 0;
	GLuint m_8Texture = 0;
	GLuint m_9Texture = 0;
	GLuint m_AllTexture = 0;


	//Texture
	GLuint m_TexVBO = 0;
	GLuint m_TexShader = 0;

	//FBO Color Buffers
	GLuint m_RT0_0 = 0;
	GLuint m_RT0_1 = 0;
	GLuint m_RT1_0 = 0;
	GLuint m_RT1_1 = 0;
	GLuint m_RT2 = 0;
	GLuint m_RT3 = 0;
	GLuint m_RT4 = 0;
	GLuint m_HDRRT0_0 = 0;
	GLuint m_HDRRT0_1 = 0;


	//FBO
	GLuint m_FBO0 = 0;
	GLuint m_FBO1 = 0;
	GLuint m_FBO2 = 0;
	GLuint m_FBO3 = 0;
	GLuint m_FBO4 = 0;
	GLuint m_HDRFBO0 = 0;

	//Blur
	GLuint m_PingpongFBO[2];
	GLuint	m_PingpongTexture[2];

	GLuint m_DrawMyself = 0;

};

