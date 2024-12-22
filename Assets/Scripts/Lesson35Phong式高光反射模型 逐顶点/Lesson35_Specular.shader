Shader "Unlit/Lesson35_Specular"
{
    Properties
    {
        //�߹ⷴ����ɫ
        _SpecularColor("SpecularColor", Color) = (1,1,1,1)
        //�����
        _SpecularNum("SpecularNum", Range(0, 20)) = 0.5
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
                //�ü��ռ��µ� ��������
                float4 pos:SV_POSITION;
                //��ɫ��Ϣ
                fixed3 color:COLOR;
            };

            //��Ӧ���Ե��е���ɫ�͹����
            fixed4 _SpecularColor;
            float _SpecularNum;

            v2f vert (appdata_base v)
            {
                v2f data;
                //1.����������ת�����ü��ռ䵱��
                data.pos = UnityObjectToClipPos(v.vertex);
                //2.������ɫ���
                //�߹ⷴ�������ɫ = ��Դ����ɫ * ���ʸ߹ⷴ����ɫ * max��0, ��׼����۲췽�������� ��׼����ķ��䷽����
                //��Դ����ɫ _LightColor.rgb
                //���ʸ߹ⷴ����ɫ _SpecularColor.rgb
                //��(�����) _SpecularNum

                //1.��׼����۲췽������
                //��ģ�Ϳռ��µĶ���λ�� ת���� ����ռ��� 
                // UNITY_MATRIX_M : ��ģ�Ϳռ��� ת�� ����ռ��µ�ת������
                float3 worldPos = mul(UNITY_MATRIX_M, v.vertex);
                //�õ��ľ����ӽǷ���
                float3 viewDir = _WorldSpaceCameraPos.xyz - worldPos;
                //��λ������һ����
                viewDir = normalize(viewDir);

                //2.��׼����ķ��䷽��
                //�õ��Ĺ�λ�õķ�������������ռ��µģ�
                float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
                //����������ռ��µ�����
                float3 normal = UnityObjectToWorldNormal(v.normal);
                //�����������
                float3 reflectDir = reflect(-lightDir, normal);

                //�߹ⷴ�������ɫ = ��Դ����ɫ * ���ʸ߹ⷴ����ɫ * max��0, ��׼����۲췽�������� ��׼����ķ��䷽����
                fixed3 color = _LightColor0.rgb * _SpecularColor.rgb * pow( max(0, dot(viewDir, reflectDir)), _SpecularNum);

                data.color = color;

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
