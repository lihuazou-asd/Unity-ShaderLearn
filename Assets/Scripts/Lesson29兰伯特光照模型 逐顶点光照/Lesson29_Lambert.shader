Shader "Unlit/Lesson29_Lambert"
{
    Properties
    {
        //���ʵ������������ɫ
        _MainColor("MainColor", Color) = (1,1,1,1)
    }
    SubShader
    {
        //�������ǵĹ���ģʽ ForwardBase������ǰ��Ⱦģʽ ��Ҫ���������� ��͸������� ������Ⱦ��
        Tags { "LightMode"="ForwardBase" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            //���ö�Ӧ�������ļ� 
            //��Ҫ��Ϊ��֮�� �� �������ýṹ��ʹ�ã����ñ���ʹ��
            #include "UnityCG.cginc"
            #include "Lighting.cginc"

            //���ʵ���������ɫ
            fixed4 _MainColor;

            //������ɫ�����ݸ�ƬԪ��ɫ��������
            struct v2f
            {
                //�ü��ռ��µĶ���������Ϣ
                float4 pos:SV_POSITION;
                //��Ӧ����������������ɫ
                fixed3 color:COLOR;
            };

            //�𶥵���� ������ص������������ɫ�ļ��� ��Ҫд�ڶ�����ɫ�� �ص�������
            v2f vert (appdata_base v)
            {
                v2f v2fData;
                //��ģ�Ϳռ��µ� ����ת�����ü��ռ���
                v2fData.pos = UnityObjectToClipPos(v.vertex);

                //��ģ�Ϳռ��µķ��� 
                //v.normal
                //��ȡ�� �������������ϵ�µ� ������Ϣ
                float3 normal = UnityObjectToWorldNormal(v.normal);
                float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);

                //������صĲ��� �Ϳ����ù�ʽ�����м�����
                //������ɫ
                //_LightColor0
                fixed3 color = _LightColor0.rgb * _MainColor.rgb * max(0, dot(normal, lightDir));

                //��¼��ɫ ���ݸ�ƬԪ��ɫ��
                //���Ǽ��������ع���ģ�ͻ����������Ŀ�� ��ϣ����Ӱ����Ҫȫ�� ��Ȼ��������һЩ����Ȼ
                //Ŀ�ľ���Ϊ���ñ���Ч�����ӽ�����ʵ���� ������Ҫ������
                v2fData.color = UNITY_LIGHTMODEL_AMBIENT.rgb + color;

                return v2fData;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                //�Ѽ���õ������ع��յ���ɫ ���ݳ�ȥ�Ϳ�����
                return fixed4(i.color.rgb, 1);
            }
            ENDCG
        }
    }
}
