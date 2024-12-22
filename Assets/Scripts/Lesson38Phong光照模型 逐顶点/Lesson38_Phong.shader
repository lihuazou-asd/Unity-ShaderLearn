Shader "Unlit/Lesson38_Phong"
{
    Properties
    {
        //���ʵ������������ɫ
        _MainColor("MainColor", Color) = (1,1,1,1)
        //�߹ⷴ����ɫ
        _SpecularColor("SpecularColor", Color) = (1,1,1,1)
        //�����
        _SpecularNum("SpecularNum", Range(0, 20)) = 0.5
    }
    SubShader
    {
        Pass
        {
            //�������ǵĹ���ģʽ ForwardBase������ǰ��Ⱦģʽ ��Ҫ���������� ��͸������� ������Ⱦ��
            Tags { "LightMode"="ForwardBase" }

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            //���ö�Ӧ�������ļ� 
            //��Ҫ��Ϊ��֮�� �� �������ýṹ��ʹ�ã����ñ���ʹ��
            #include "UnityCG.cginc"
            #include "Lighting.cginc"

            //���ʵ���������ɫ
            fixed4 _MainColor;
            //��Ӧ���Ե��е���ɫ�͹����
            fixed4 _SpecularColor;
            float _SpecularNum;

            //������ɫ�����ݸ�ƬԪ��ɫ��������
            struct v2f
            {
                //�ü��ռ��µĶ���������Ϣ
                float4 pos:SV_POSITION;
                //��Ӧ����������������ɫ
                fixed3 color:COLOR;
            };

            //���������ع���ģ�� ��ɫ ��غ���
            fixed3 getLambertColor(in float3 objNormal)
            {
                //��ģ�Ϳռ��µķ��� 
                //v.normal
                //��ȡ�� �������������ϵ�µ� ������Ϣ
                float3 normal = UnityObjectToWorldNormal(objNormal);
                float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);

                //������صĲ��� �Ϳ����ù�ʽ�����м�����
                //������ɫ
                //_LightColor0
                fixed3 color = _LightColor0.rgb * _MainColor.rgb * max(0, dot(normal, lightDir));

                return color;
            }

            //����Phong�߹ⷴ�����ģ�� ��ɫ ��غ���
            fixed3 getSpecularColor(in float4 objVertex, in float3 objNormal)
            {
                //1.��׼����۲췽������
                //��ģ�Ϳռ��µĶ���λ�� ת���� ����ռ��� 
                // UNITY_MATRIX_M : ��ģ�Ϳռ��� ת�� ����ռ��µ�ת������
                float3 worldPos = mul(UNITY_MATRIX_M, objVertex);
                //�õ��ľ����ӽǷ���
                float3 viewDir = _WorldSpaceCameraPos.xyz - worldPos;
                //��λ������һ����
                viewDir = normalize(viewDir);

                //2.��׼����ķ��䷽��
                //�õ��Ĺ�λ�õķ�������������ռ��µģ�
                float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
                //����������ռ��µ�����
                float3 normal = UnityObjectToWorldNormal(objNormal);
                //�����������
                float3 reflectDir = reflect(-lightDir, normal);

                //�߹ⷴ�������ɫ = ��Դ����ɫ * ���ʸ߹ⷴ����ɫ * max��0, ��׼����۲췽�������� ��׼����ķ��䷽����
                fixed3 color = _LightColor0.rgb * _SpecularColor.rgb * pow( max(0, dot(viewDir, reflectDir)), _SpecularNum);

                return color;
            }

            v2f vert (appdata_base v)
            {
                v2f v2fData;
                //��ģ�Ϳռ��µ� ����ת�����ü��ռ���
                v2fData.pos = UnityObjectToClipPos(v.vertex);
                //���������ع���ģ��������ɫ
                fixed3 lambertColor = getLambertColor(v.normal);
                //����Phongʽ�߹ⷴ�����ģ��������ɫ
                fixed3 specularColor = getSpecularColor(v.vertex, v.normal);

                //����Phong����ģ�͹�ʽ ������ɫ����
                //������������ɫ = ��������ɫ + �����ع���ģ��������ɫ + Phongʽ�߹ⷴ�����ģ��������ɫ
                v2fData.color = UNITY_LIGHTMODEL_AMBIENT.rgb + lambertColor + specularColor;

                return v2fData;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return fixed4(i.color.rgb, 1);
            }
            ENDCG
        }
    }
}
