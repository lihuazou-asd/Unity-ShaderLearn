Shader "Unlit/Lesson42_BlinnPhongSpecularF"
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
                //�ü��ռ��λ��
                float4 pos:SV_POSITION;
                //������������ϵ�µĶ���λ��
                float3 wPos:TEXCOORD0;
                //������������ϵ�µķ���
                float3 wNormal:NORMAL;
            };

            fixed4 _SpecularColor;
            float _SpecularNum;

            v2f vert (appdata_base v)
            {
                v2f data;
                //����ת���ü��ռ�
                data.pos = UnityObjectToClipPos(v.vertex);
                //�Ѷ����ģ�Ϳռ�ת��������ռ��� ���о���˷�����
                data.wPos = mul(unity_ObjectToWorld, v.vertex);
                //���߼���
                data.wNormal = UnityObjectToWorldNormal(v.normal);

                return data;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                //�߹ⷴ�������ɫ = ��Դ����ɫ * ���ʸ߹ⷴ����ɫ * max��0, ��׼���󶥵㷨�߷������� �� ��׼����������������������

                float3 viewDir = normalize( _WorldSpaceCameraPos.xyz - i.wPos );
                //���߷��� ��λ����
                float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
                //��Ƿ�������
                float3 halfA = normalize(viewDir + lightDir);

                //�߹ⷴ�������ɫ = ��Դ����ɫ * ���ʸ߹ⷴ����ɫ * max��0, ��׼���󶥵㷨�߷������� �� ��׼����������������������
                fixed3 color = _LightColor0.rgb * _SpecularColor.rgb * pow( max(0, dot(i.wNormal, halfA)) , _SpecularNum);

                return fixed4(color.rgb, 1);
            }
            ENDCG
        }
    }
}
