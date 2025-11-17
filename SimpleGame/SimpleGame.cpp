/*
Copyright 2022 Lee Taek Hee (Tech University of Korea)

This program is free software: you can redistribute it and/or modify
it under the terms of the What The Hell License. Do it plz.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY.
*/

#include "stdafx.h"
#include <iostream>
#include "Dependencies\glew.h"
#include "Dependencies\freeglut.h"
#include "Renderer.h"


Renderer *g_Renderer = NULL;
bool g_bNeedReloadShaderPrograms = false;


void RenderScene(void)
{
	if (g_bNeedReloadShaderPrograms)
	{
		g_Renderer->RealoadAllShaderPrograms();
		g_bNeedReloadShaderPrograms = false;
	}

<<<<<<< HEAD
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
=======
	//glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
>>>>>>> f32f011 (add fs factory)
	//g_Renderer->DrawFullScreenColor(0, 0, 0, 0.5);
	glClearColor(0.0f, 0.0f, 0.0f, 0.0f);

	// Renderer Test
	//g_Renderer->DrawSolidRect(0, 0, 0, 4, 1, 0, 1, 1);
	//g_Renderer->DrawTest();	
//g_Renderer->DrawParticles();
	//g_Renderer->DrawGridMesh();
	g_Renderer->DrawFS();

	glutSwapBuffers();
}

void Idle(void)
{
	RenderScene();
}

void MouseInput(int button, int state, int x, int y)
{

}

void KeyInput(unsigned char key, int x, int y)
{
	switch (key)
	{
	case '1':
		g_bNeedReloadShaderPrograms = true;
		break;

	default:
		break;
	}
}

void SpecialKeyInput(int key, int x, int y)
{
	
}

int main(int argc, char **argv)
{
	int winX = 1000;
	int winY = 1000;
	// Initialize GL things
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_DEPTH | GLUT_DOUBLE | GLUT_RGBA);
	glutInitWindowPosition(0, 0);
	glutInitWindowSize(winX, winY);
	glutCreateWindow("Game Software Engineering KPU");

	glewInit();
	if (glewIsSupported("GL_VERSION_3_0"))
	{
		std::cout << " GLEW Version is 3.0\n ";
	}
	else
	{
		std::cout << "GLEW 3.0 not supported\n ";
	}

	// Initialize Renderer
	g_Renderer = new Renderer(winX, winY);

	if (!g_Renderer->IsInitialized())
	{
		std::cout << "Renderer could not be initialized.. \n";
	}

	glutDisplayFunc(RenderScene);
	glutIdleFunc(Idle);
	glutKeyboardFunc(KeyInput);
	glutMouseFunc(MouseInput);
	glutSpecialFunc(SpecialKeyInput);

	glutMainLoop();

	delete g_Renderer;

    return 0;
}

