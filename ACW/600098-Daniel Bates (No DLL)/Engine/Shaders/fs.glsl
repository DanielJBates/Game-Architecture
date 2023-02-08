#version 330
 
in vec2 v_TexCoord;
in vec3 v_Normal;
in vec3 v_FragPos;
uniform sampler2D s_texture;
uniform vec3 v_diffuse;	// OBJ NEW

out vec4 Color;

void main()
{
	vec3 lightColor = vec3(1,1,1);
	vec4 lightAmbient = vec4(0.1, 0.1, 0.1, 1.0);

	vec3 lightPos1 = vec3(0,10,40);
	vec3 lightPos2 = vec3(40,10,-40);	
	vec3 lightPos3 = vec3(-40,10,-40);	

	vec3 norm = normalize(v_Normal);

	vec3 lightDir1 = normalize(lightPos1 - v_FragPos);
	vec3 lightDir2 = normalize(lightPos2 - v_FragPos); 
	vec3 lightDir3 = normalize(lightPos3 - v_FragPos); 

	float diff = 0;
	diff += max(dot(norm, lightDir1), 0.0);
	diff += max(dot(norm, lightDir2), 0.0);
	diff += max(dot(norm, lightDir3), 0.0);

	vec3 diffuse = diff * lightColor;

    Color = lightAmbient + (vec4(v_diffuse, 1) * texture2D(s_texture, v_TexCoord) * vec4(diffuse, 0));  // OBJ CHANGED
}