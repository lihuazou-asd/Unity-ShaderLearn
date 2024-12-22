Shader "Unlit/Lesson39_PhongF"
{
    Properties
    {
        _MainColor("MainColor", Color) = (1,1,1,1)
        //�߹ⷴ����ɫ  �����
        _SpecularColor("SpecularColor", Color) = (1,1,1,1)
        _SpecularNum("SpecularNum", Range(0, 20)) = 1
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

            //������������ɫ
            fixed4 _MainColor;
            fixed4 _SpecularColor;
            float _SpecularNum;

            //������ɫ�����س�ȥ������
            struct v2f
            {
                //�ü��ռ��µĶ���λ��
                float4 pos:SV_POSITION;
                //����ռ��µķ���λ��
                float3 wNormal:NORMAL;
                //����ռ��µ� �������� 
                float3 wPos:TEXCOORD0;
            };

            //�õ������ع���ģ�ͼ������ɫ ����ƬԪ��
            fixed3 getLambertFColor(in float3 wNormal)
            {
                //�õ���Դ��λ����
                float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
                //������������ع��յ���������ɫ
                fixed3 color = _LightColor0.rgb * _MainColor.rgb * max(0, dot(wNormal, lightDir));

                return color;
            }

            //�õ�Phongʽ�߹ⷴ��ģ�ͼ������ɫ����ƬԪ��
            fixed3 getSpecularColor(in float3 wPos, in float3 wNormal)
            {
                //1.�ӽǵ�λ����
                float3 viewDir = normalize(_WorldSpaceCameraPos.xyz - wPos );

                //2.��ķ��䵥λ����
                //��ķ���
                float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
                //�ⷴ����ߵĵ�λ����
                float3 reflectDir = reflect(-lightDir, wNormal);
                //color = ��Դ��ɫ * ���ʸ߹ⷴ����ɫ * pow( max(0, dot(�ӽǵ�λ����, ��ķ��䵥λ����)), ����� )
                fixed3 color = _LightColor0.rgb * _SpecularColor.rgb * pow( max(0, dot(viewDir, reflectDir)), _SpecularNum );

                return color;
            }

            v2f vert (appdata_base v)
            {
               v2f v2fData;
               //ת��ģ�Ϳռ��µĶ��㵽�ü��ռ���
               v2fData.pos = UnityObjectToClipPos(v.vertex);
               //ת��ģ�Ϳռ��µķ��ߵ�����ռ���
               v2fData.wNormal = UnityObjectToWorldNormal(v.normal);
               //����ת������ռ�
               v2fData.wPos = mul(unity_ObjectToWorld, v.vertex).xyz;

               return v2fData;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                //���������ع�����ɫ
                fixed3 lambertColor = getLambertFColor(i.wNormal);
                //����Phongʽ�߹ⷴ����ɫ
                fixed3 specularColor = getSpecularColor(i.wPos, i.wNormal);
                //������������ɫ = ��������ɫ + �����ع���ģ��������ɫ + Phongʽ�߹ⷴ�����ģ��������ɫ
                fixed3 phongColor = UNITY_LIGHTMODEL_AMBIENT.rgb + lambertColor + specularColor; 

                return fixed4(phongColor.rgb, 1);
            }
            ENDCG
        }
    }
}
