// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Unlit/Lesson41_BlinnPhongSpecular"
{
    Properties
    {
        //�߹ⷴ�������ɫ �Լ� �����
        _SpecularColor("SpecularColor", Color) = (1,1,1,1)
        _SpecularNum("SpecularNum", Range(0,20)) = 5
    }
    SubShader
    {
        Pass
        {
            Tags { "LightMode"="ForwardBase" }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
           
            struct v2f
            {
                float4 pos:SV_POSITION;
                fixed3 color:COLOR;
            };

            fixed4 _SpecularColor;
            float _SpecularNum;

            v2f vert (appdata_base v)
            {
                v2f data;
                //����ת���ü��ռ�
                data.pos = UnityObjectToClipPos(v.vertex);

                //�߹ⷴ�������ɫ = ��Դ����ɫ * ���ʸ߹ⷴ����ɫ * max��0, ��׼���󶥵㷨�߷������� �� ��׼����������������������

                //1.��׼���󶥵㷨�߷�������
                float3 wNormal = UnityObjectToWorldNormal(v.normal);

                //2.��׼������������������
                //�ӽǷ��� ��λ����
                float3 wPos = mul(unity_ObjectToWorld, v.vertex);
                float3 viewDir = normalize( _WorldSpaceCameraPos.xyz - wPos );
                //���߷��� ��λ����
                float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
                //��Ƿ�������
                float3 halfA = normalize(viewDir + lightDir);

                //�߹ⷴ�������ɫ = ��Դ����ɫ * ���ʸ߹ⷴ����ɫ * max��0, ��׼���󶥵㷨�߷������� �� ��׼����������������������
                data.color = _LightColor0.rgb * _SpecularColor.rgb * pow( max(0, dot(wNormal, halfA)) , _SpecularNum);


                return data;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return fixed4(i.color.rgb, 1);
            }
            ENDCG
        }
    }
}
