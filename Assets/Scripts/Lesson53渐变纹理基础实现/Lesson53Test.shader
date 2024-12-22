Shader "Unlit/Lesson53Test"
{
    Properties
    {
        _MainColor("MainColor", Color) = (1,1,1,1)
        _RampTex("RampTex", 2D) = ""{}
        _SpecularColor("SpecularColor", Color) = (1,1,1,1)
        _SpecularNum("SpecularNum", Range(8, 256)) = 18
    }
    SubShader
    {
        Tags { "LightMode"="ForwardBase" }


        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag


            #include "UnityCG.cginc"
            #include "Lighting.cginc"


            sampler2D _RampTex;
            fixed4 _MainColor;
            fixed4 _SpecularColor;
            float _SpecularNum;
            

            struct v2f
            {
                float4 pos:SV_POSITION;

                float3 wPos:TEXCOORD0;
                float3 normal:TEXCOORD1;
            };


            v2f vert (appdata_base v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.wPos = mul(UNITY_MATRIX_M,v.vertex);
                o.normal = UnityObjectToWorldNormal(v.normal);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {

                float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
                float3 viewDir = normalize(_WorldSpaceCameraPos - i.wPos);
                float lambertNum = dot(lightDir,i.normal)*0.5 + 0.5;

                fixed3 diffuseColor = _MainColor * _LightColor0.rgb* tex2D(_RampTex, fixed2(lambertNum,lambertNum));

                float3 halfA = normalize(lightDir+viewDir);

                fixed3 speculatColor = _SpecularColor.rgb * _LightColor0.rgb * pow(max(0,dot(i.normal,halfA)),_SpecularNum);

                fixed3 color= UNITY_LIGHTMODEL_AMBIENT.rgb + diffuseColor + speculatColor;



                return fixed4(color,1);
            }
            ENDCG
        }
    }
}
