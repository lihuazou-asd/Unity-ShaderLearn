Shader "Unlit/Lesson30Test"
{
    Properties
    {
        _MyColor("MyColor",Color) = (1,1,1,1)
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


            float4 _MyColor;

            struct v2f
            {
                float4 pos:SV_POSITION;
                float3 normal:NORMAL;
            };

            v2f vert (appdata_base v)
            {
                v2f v2fData;
                v2fData.pos = UnityObjectToClipPos(v.vertex);
                v2fData.normal = UnityObjectToWorldNormal(v.normal);
                return v2fData;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
                fixed3 lightColor = _LightColor0.rgb;

                fixed3 color= _MyColor*lightColor*max(0,dot(i.normal,lightDir)) + UNITY_LIGHTMODEL_AMBIENT.rgb;

                return fixed4(color,1);

            }
            ENDCG
        }
    }
}
