#pragma once

#include <string>
#include <cstdlib>
#include <fstream>
#include <iostream>

#include "Dependencies\glew.h"

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
	void DrawGridMesh();
	void DrawFullScreenColor(float r, float g, float b, float a);

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

};

