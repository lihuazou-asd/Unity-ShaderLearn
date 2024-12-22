Shader "Unlit/Lesson50Test"
{
    Properties
    {
        _MainTex("MainTex",2D) = ""{}
        _MainColor("MainColor",Color) = (1,1,1,1)
        _SpecularColor("SpecularColor",Color) = (1,1,1,1)
        _SpecularNum("SpecularNum",Range(0,20)) = 15

    }
    SubShader
    {
        Pass
        {
            Tags { "LightMode" = "ForwardBase" }

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "Lighting.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;

            fixed4 _MainColor;
            fixed4 _SpecularColor;

            float _SpecularNum;

            struct v2f
            {
                float4 pos:SV_POSITION;
                float3 normal:NORMAL;
                float3 Wpos:TEXCOORD1;
                float2 uv:TEXCOORD0;
            };

            v2f vert(appdata_base data)
            {
                v2f v2fData;
                v2fData.pos = UnityObjectToClipPos(data.vertex);
                v2fData.normal = UnityObjectToWorldNormal(data.normal);

                v2fData.Wpos = mul(UNITY_MATRIX_M,data.vertex);

                v2fData.uv = data.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                return v2fData;

            }

            fixed4 frag(v2f i):SV_Target
            {
                fixed3 albedo = tex2D(_MainTex,i.uv).rgb * _MainColor.rgb;
                float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
                fixed3 lanbertColor = albedo * _LightColor0.rgb * max(0,dot(lightDir,i.normal));

                float3 viewDir = normalize(_WorldSpaceCameraPos-i.Wpos);
                float3 halfA = normalize(lightDir+viewDir);
                fixed3 blinnPhongSpecularColor =  _LightColor0.rgb*_SpecularColor.rgb * pow(max(0,dot(halfA,i.normal)),_SpecularNum);

                fixed3 color = UNITY_LIGHTMODEL_AMBIENT.rgb * albedo + lanbertColor + blinnPhongSpecularColor;

                return fixed4(color,1);
            }


            ENDCG
        }
    }
}
