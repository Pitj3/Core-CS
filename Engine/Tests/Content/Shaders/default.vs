#version 330 core

// Input vertex data, different for all executions of this shader.
layout (location = 0) in vec3 position;
layout (location = 1) in vec2 texcoord;
layout (location = 2) in vec4 color;

uniform mat4 projection;
uniform mat4 view;
uniform mat4 model;

out DATA
{
	vec2 uv;
	vec4 color;
} vs_out;

void main(){

	mat4 mvp =  projection * view * model;
	//mat4 mvp = model * view * projection;

    gl_Position = mvp * vec4(position, 1.0);
	vs_out.uv = texcoord;
	vs_out.color = color;
}