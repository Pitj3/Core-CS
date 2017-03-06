#version 330 core

// Input vertex data, different for all executions of this shader.
layout (location = 0) in vec3 position;
layout (location = 1) in vec2 texcoord;
layout (location = 2) in vec3 normal;
layout (location = 3) in vec3 bitangent;
layout (location = 4) in vec3 tangent;
layout (location = 5) in vec4 color;

uniform mat4 projection;
uniform mat4 view;
uniform mat4 model;

uniform vec3 lightPos;
uniform vec3 viewPos;

out DATA
{
	vec3 FragPos;
	vec2 TexCoords;
	vec3 TangentLightPos;
	vec3 TangentViewPos;
	vec3 TangentFragPos;
	vec3 Normal;
	vec3 LightPos;
} vs_out;

void main(){

    gl_Position = projection * view * model * vec4(position, 1.0);

	vs_out.FragPos = vec3(model * vec4(position, 1.0));
	vs_out.TexCoords = texcoord;

	mat3 normalMatrix = transpose(inverse(mat3(model)));
	vec3 T = normalize(normalMatrix * tangent);
	vec3 B = normalize(normalMatrix * bitangent);
	vec3 N = normalize(normalMatrix * normal);

	mat3 TBN = transpose(mat3(T, B, N));
	vs_out.TangentLightPos = TBN * lightPos;
	vs_out.TangentViewPos = TBN * viewPos;
	vs_out.TangentFragPos = TBN * vs_out.FragPos;

	vs_out.Normal = normalize((model * vec4(normal, 0.0f)).xyz);
	vs_out.LightPos = lightPos;
}