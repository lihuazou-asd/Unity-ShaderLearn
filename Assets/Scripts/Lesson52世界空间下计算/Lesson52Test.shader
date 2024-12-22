Shader "Unlit/Lesson52Test"
{
    Properties
    {
        _MainTex("MainTex",2D) = ""{}
        _MainColor("MainColor",Color) = (1,1,1,1)
        _BumpTex("BumpTex",2D) = ""{}
        _BumpNum("BumpNum",Range(0,1)) = 1
        _SpecularColor("SpecularColor",Color) = (1,1,1,1)
        _SpecularNum("_SpecularNum",Range(0,20)) = 1
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

            struct v2f
            {
                float4 pos:SV_POSITION;
                float4 uv:TEXCOORD0;


                float4 worldMatrix0:TEXCOORD1;
                float4 worldMatrix1:TEXCOORD2;
                float4 worldMatrix2:TEXCOORD3;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _MainColor;
            sampler2D _BumpTex;
            float4 _BumpTex_ST;
            float _BumpNum;
            fixed4 _SpecularColor;
            float _SpecularNum;



            v2f vert (appdata_full v)
            {
                v2f v2fData;
                v2fData.pos = UnityObjectToClipPos(v.vertex);

                v2fData.uv.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                v2fData.uv.zw = v.texcoord.xy * _BumpTex_ST.xy + _BumpTex_ST.zw;

                float3 wTangent= UnityObjectToWorldDir(v.tangent.xyz);
                float3 wNormal = UnityObjectToWorldNormal(v.normal);

                float3 binormal = cross(v.tangent.xyz,v.normal) * v.tangent.w;
                float3 wBinormal = UnityObjectToWorldDir(binormal);


                float3 wPos = mul(UNITY_MATRIX_M,v.vertex);

                v2fData.worldMatrix0 = float4(wTangent.x,wBinormal.x,wNormal.x,wPos.x);
                v2fData.worldMatrix1 = float4(wTangent.y,wBinormal.y,wNormal.y,wPos.y);
                v2fData.worldMatrix2 = float4(wTangent.z,wBinormal.z,wNormal.z,wPos.z);

                return v2fData;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float3 wPos = float3(i.worldMatrix0.w,i.worldMatrix1.w,i.worldMatrix2.w);

                float3 BumpNormal = UnpackNormal(tex2D(_BumpTex,i.uv.zw));

                BumpNormal.xy *= _BumpNum;

                BumpNormal.z = sqrt(1 - saturate(dot(BumpNormal.xy,BumpNormal.xy)));
                
                float3 wBumpNormal = float3(dot(i.worldMatrix0.xyz,BumpNormal),dot(i.worldMatrix1.xyz,BumpNormal),dot(i.worldMatrix2.xyz,BumpNormal));

                fixed3 albedo = tex2D(_MainTex,i.uv.xy) * _MainColor.rgb;

                float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
                float3 viewDir = normalize(_WorldSpaceCameraPos - wPos);

                fixed3 lambertColor = albedo * _LightColor0.rgb * max(0,dot(lightDir,wBumpNormal));

                float3 halfA = normalize(lightDir + viewDir);

                fixed3 specularColor = _SpecularColor.rgb * _LightColor0.rgb * pow(max(0,dot(wBumpNormal,halfA)),_SpecularNum);

                fixed3 color= UNITY_LIGHTMODEL_AMBIENT.rgb * albedo + lambertColor + specularColor;

                return fixed4(color,1);


            }
            ENDCG
        }
    }
}
