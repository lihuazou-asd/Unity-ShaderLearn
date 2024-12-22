Shader "Unlit/Lesson51Test"
{
    Properties
    {
        _MainTex("MainTex",2D) = ""{}
        _MainColor("MainColor",Color) = (1,1,1,1)
        _BumpTex("BumpTex" ,2D) = ""{}
        _BumpNum("BumpNum",Range(0,1)) =1
        _SpecularColor("SpecularColor",Color) = (1,1,1,1)
        _SpecularNum("SpecularNum",Range(0,20)) = 18

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
            sampler2D _BumpTex;
            float4 _BumpTex_ST;

            fixed4 _MainColor;
            fixed4 _SpecularColor;

            float _BumpNum;
            float _SpecularNum;
            
            struct v2f
            {
                float4 pos:SV_POSITION;

                float4 uv:TEXCOORD0;

                float3 lightDir:TEXCOORD1;

                float3 viewDir:TEXCOORD2;
            };

            v2f vert(appdata_full data)
            {
                v2f v2fData;

                v2fData.pos = UnityObjectToClipPos(data.vertex);

                v2fData.uv.xy = data.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                v2fData.uv.zw = data.texcoord.xy * _BumpTex_ST.xy + _BumpTex_ST.zw;

                float3 biTangent = cross(data.tangent.xyz,data.normal)*data.tangent.w;

                float3x3 rotation = float3x3(normalize(data.tangent.xyz),
                                             normalize(biTangent),
                                             normalize(data.normal));
                                     
                v2fData.lightDir = mul(rotation,ObjSpaceLightDir(data.vertex).xyz);
                v2fData.viewDir = mul(rotation,ObjSpaceViewDir(data.vertex).xyz);

                return v2fData;

            }

            fixed4 frag(v2f i):SV_Target
            {
                float4 packNormal = tex2D(_BumpTex,i.uv.zw);
                float3 unpackNormal = UnpackNormal(packNormal) * _BumpNum;
                fixed3 albedo = tex2D(_MainTex,i.uv.xy)*_MainColor.rgb;

                fixed3 lambertColor = albedo.rgb * _LightColor0.rgb * max(0,dot(normalize(i.lightDir),unpackNormal));

                float3 halfA = normalize(normalize(i.lightDir)+normalize(i.viewDir));
                fixed3 specularColor = _SpecularColor.rgb * _LightColor0.rgb * pow(max(0,dot(unpackNormal,halfA)),_SpecularNum);

                fixed3 color = UNITY_LIGHTMODEL_AMBIENT.rgb*albedo + lambertColor + specularColor;

                return fixed4(color ,1);

            }


            ENDCG
        }
    }
}
