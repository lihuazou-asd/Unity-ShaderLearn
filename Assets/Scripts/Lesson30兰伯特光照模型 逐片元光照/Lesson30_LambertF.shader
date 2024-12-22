Shader "Unlit/Lesson30_LambertF"
{
    Properties
    {
        _MainColor("MainColor", Color) = (1,1,1,1)
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

            //������������ɫ
            fixed4 _MainColor;

            //������ɫ�����س�ȥ������
            struct v2f
            {
                //�ü��ռ��µĶ���λ��
                float4 pos:SV_POSITION;
                //����ռ��µķ���λ��
                float3 normal:NORMAL;
            };
            
            //һ��ע�� ������ɫ���ص����� ��Ҫ�������ڴ����㡢���ߡ����ߵ����ݵ�����ת��
            v2f vert (appdata_base v)
            {
               v2f v2fData;
               //ת��ģ�Ϳռ��µĶ��㵽�ü��ռ���
               v2fData.pos = UnityObjectToClipPos(v.vertex);
               //ת��ģ�Ϳռ��µķ��ߵ�����ռ���
               v2fData.normal = UnityObjectToWorldNormal(v.normal);

               return v2fData;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                //�õ���Դ��λ����
                float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
                //������������ع��յ���������ɫ
                fixed3 color = _LightColor0.rgb * _MainColor.rgb * max(0, dot(i.normal, lightDir));
                //Ϊ���ñ���ĵط��������Ǻ�ɫ ���Լ����Դ�����������ɫ ������������ʵ
                color = UNITY_LIGHTMODEL_AMBIENT.rgb + color;

                return fixed4(color.rgb, 1);
            }
            ENDCG
        }
    }
}
