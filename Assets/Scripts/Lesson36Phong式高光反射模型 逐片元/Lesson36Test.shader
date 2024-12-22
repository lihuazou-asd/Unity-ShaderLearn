Shader "Unlit/Lesson36Test"
{
    Properties
    {
        _MyColor("MyColor",Color) = (1,1,1,1)
        _MyGloss("MyGloss",Range(0,20)) = 1

    }
    SubShader
    {
        Tags { "LightMode"="forwardBase" }

        Pass
        {
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "Lighting.cginc"

            fixed4 _MyColor;
            float _MyGloss;
            
            struct v2f
            {
                float4 pos:SV_POSITION;


                float3 WorldPos:TEXCOORD0;
                float3 normal:NORMAL;

            };

            v2f vert (appdata_base v)
            {
                v2f v2fData;
                v2fData.pos = UnityObjectToClipPos(v.vertex);
                v2fData.normal = UnityObjectToWorldNormal(v.normal);
                float3 WorldPos = mul(UNITY_MATRIX_M,v.vertex);
                v2fData.WorldPos =WorldPos;
                return v2fData;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
                float3 reflectDir = reflect(-lightDir,i.normal);
                float3 ViewDir = normalize(_WorldSpaceCameraPos-i.WorldPos);
                fixed3 color = _LightColor0.rgb * _MyColor.rgb * pow(max(0,dot(reflectDir,ViewDir)),_MyGloss);

                return fixed4(color,1);
            }
            ENDCG
        }
    }
}
