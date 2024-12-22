Shader "Unlit/Lesson36_SpecularF"
{
    Properties
    {
        //�߹ⷴ����ɫ  �����
        _SpecularColor("SpecularColor", Color) = (1,1,1,1)
        _SpecularNum("SpecularNum", Range(0, 20)) = 1
    }
    SubShader
    {
        Pass
        {
            //����ж��Pass��Ⱦͨ��ʱ һ������»�ѹ���ģʽ�� Tags�ŵ���Ӧ��Pass��
            //����Ӱ������Pass
            Tags { "LightMode"="ForwardBase" }

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "Lighting.cginc"

            struct v2f
            {
                //�ü��ռ��µĶ�������
                float4 pos:SV_POSITION;
                //����ռ��µ� ������Ϣ
                float3 wNormal:NORMAL;
                //����ռ��µ� �������� 
                float3 wPos:TEXCOORD0;
            };

            fixed4 _SpecularColor;
            float _SpecularNum;

            v2f vert (appdata_base v)
            {
                v2f data;
                //1.����ü��ռ�任
                data.pos = UnityObjectToClipPos(v.vertex);
                //2.���з��߿ռ�任
                data.wNormal = UnityObjectToWorldNormal(v.normal);
                //3.����ת������ռ�
                //data.wPos = mul(UNITY_MATRIX_M, v.vertex).xyz;
                //data.wPos = mul(_Object2World, v.vertex).xyz;
                data.wPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return data;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                //1.�ӽǵ�λ����
                float3 viewDir = normalize(_WorldSpaceCameraPos.xyz - i.wPos );

                //2.��ķ��䵥λ����
                //��ķ���
                float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
                //�ⷴ����ߵĵ�λ����
                float3 reflectDir = reflect(-lightDir, i.wNormal);
                //color = ��Դ��ɫ * ���ʸ߹ⷴ����ɫ * pow( max(0, dot(�ӽǵ�λ����, ��ķ��䵥λ����)), ����� )
                fixed3 color = _LightColor0.rgb * _SpecularColor.rgb * pow( max(0, dot(viewDir, reflectDir)), _SpecularNum );

                return fixed4(color.rgb, 1);
            }
            ENDCG
        }
    }
}
