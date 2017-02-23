#version 330 core

layout (location = 0) out vec4 color;

uniform sampler2D diffuse;

in DATA
{
	vec2 uv;
	vec4 color;
} fs_in;

void main()
{
	vec4 texColor = texture2D(diffuse, fs_in.uv);

	color = fs_in.color;
}