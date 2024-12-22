Shader "Unlit/LambertTest"
{
    Properties
    {
        _MyColor ("MyColor", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "LightMode" = "ForwardBase" }
        

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
                float3 color:COLOR;
            };
            v2f vert(appdata_base data)
            {
                v2f tmp;
                tmp.pos = UnityObjectToClipPos(data.vertex);

                float3 normal = UnityObjectToWorldNormal(data.normal);
                float3 lightDir = normalize(_WorldSpaceLightPos0);

                float3 color = _MyColor*_LightColor0*max(0,dot(normal,lightDir));

                tmp.color = UNITY_LIGHTMODEL_AMBIENT.rgb + color;
                
                return tmp;
            }

            float4 frag(v2f test):SV_Target
            {
                return float4(test.color,1);
            }
            
            ENDCG
        }
    }
}
