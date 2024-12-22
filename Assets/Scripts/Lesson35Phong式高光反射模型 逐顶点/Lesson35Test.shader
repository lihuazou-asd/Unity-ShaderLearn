Shader "Unlit/Lesson35Test"
{
    Properties
    {
        _MyColor("MyColor",Color) = (1,1,1,1)
        _MyGloss("MyGloss",Range(0,20)) = 1
    }
    SubShader
    {
        Tags { "LightMode" = "ForwardBase" }

        pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "Lighting.cginc"


            fixed4 _MyColor;

            fixed _MyGloss;



            struct v2f
            {
                float4 pos:SV_POSITION;
                fixed3 color:COLOR;
            };

            v2f vert(appdata_base data)
            {
                v2f v2fData;
                v2fData.pos = UnityObjectToClipPos(data.vertex);

                float3 normal = UnityObjectToWorldNormal(data.normal);

                float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);

                float3 reflectDir = reflect(-lightDir,normal);

                float3 WorldPoint = mul(UNITY_MATRIX_M,data.vertex);

                float3 ViewDir = normalize(_WorldSpaceCameraPos - WorldPoint);

                fixed3 color = _MyColor.rgb * _LightColor0.rgb * pow(max(0,dot(ViewDir,reflectDir)),_MyGloss);

                v2fData.color = color;
                return v2fData;
            }

            float4 frag(v2f i):SV_Target
            {
                return fixed4(i.color,1);
            }

            ENDCG
        }
        
    }
}
