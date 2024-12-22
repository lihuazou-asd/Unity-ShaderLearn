Shader "Unlit/Lesson53"
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
        Pass
        {
            Tags {"LightMode" = "ForwardBase"}
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "Lighting.cginc"

            fixed4 _MainColor;
            sampler2D _RampTex;
            float4 _RampTex_ST;
            fixed4 _SpecularColor;
            float _SpecularNum;

            struct v2f
            {
                //�ü��ռ��¶�������
                float4 pos:SV_POSITION;
                //����ռ��¶�������
                float3 worldPos:TEXCOORD0;
                //����ռ��·���
                float3 worldNormal:TEXCOORD1;
            };

            v2f vert (appdata_base v)
            {
                v2f data;
                data.pos = UnityObjectToClipPos(v.vertex);
                data.worldPos = mul(unity_ObjectToWorld, v.vertex);
                data.worldNormal = UnityObjectToWorldNormal(v.normal);
                return data;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                //��ķ���
                float3 lightDir = normalize(_WorldSpaceLightPos0);
                
                //��������ɫ��ͨ����������õ�����ɫ�����е��ӣ�
                fixed halfLambertNum = dot(normalize(i.worldNormal), lightDir) * 0.5 + 0.5;
                //��������ɫ = �����ɫ * ��������ɫ * ����������ȡ������ɫ
                fixed3 diffuseColor = _LightColor0.rgb * _MainColor.rgb * tex2D(_RampTex, fixed2(halfLambertNum, halfLambertNum));

                //�߹ⷴ����ɫ
                //�ӽǷ���
                float3 viewDir = normalize(UnityWorldSpaceViewDir(i.worldPos));
                float3 halfDir = normalize(lightDir + viewDir);
                fixed3 specularColor = _LightColor0.rgb * _SpecularColor.rgb * pow(max(0, dot(i.worldNormal, halfDir)), _SpecularNum);

                //���ַ� ��ʽ
                fixed3 color = UNITY_LIGHTMODEL_AMBIENT.rgb + diffuseColor + specularColor;

                return fixed4(color.rgb, 1);
            }
            ENDCG
        }
    }
}
