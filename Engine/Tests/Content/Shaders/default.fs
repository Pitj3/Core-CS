#version 330 core

layout (location = 0) out vec4 FragColor;

uniform sampler2D diffuseMap;
uniform sampler2D normalMap;

uniform bool normalMapping;

in DATA
{
	vec3 FragPos;
	vec2 TexCoords;
	vec3 TangentLightPos;
	vec3 TangentViewPos;
	vec3 TangentFragPos;
	vec3 Normal;
	vec3 LightPos;
} fs_in;

void main()
{
	vec3 color = texture(diffuseMap, fs_in.TexCoords).rgb;

	if(normalMapping)
	{
		vec3 normal = texture(normalMap, fs_in.TexCoords).rgb;
		normal = normalize(normal * 2.0f - 1.0);

		vec3 ambient = 0.1 * color;

		vec3 lightDir = normalize(fs_in.LightPos - fs_in.FragPos);
		float diff = max(dot(lightDir, fs_in.Normal), 0.0);
		vec3 diffuse = diff * color;

		FragColor = vec4(ambient + diffuse, 1.0f);
	}
	else
		FragColor = vec4(color, 1);
}