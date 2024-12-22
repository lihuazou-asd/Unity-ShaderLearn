Shader "Unlit/Lesson59_AlphaTest_Both"
{
     Properties
    {
       //��Ҫ���ǽ���������Shader�Ͳ��ַ�����ģ����ƬԪShader����һ�����
       _MainTex("MainTex", 2D) = ""{}
       //��������ɫ���߹ⷴ����ɫ�������
       _MainColor("MainColor", Color) = (1,1,1,1)
       _SpecularColor("SpecularColor", Color) = (1,1,1,1)
       _SpecularNum("SpecularNum", Range(0,20)) = 15
       //͸���Ȳ����õ���ֵ
       _Cutoff("Cutoff", Range(0,1)) = 0
    }
    SubShader
    {
        //������Ⱦ���� ���������ں�ʱ��Ⱦ
        Tags{"Queue"="AlphaTest" "IgnoreProjector"="True" "RenderType"="TransparentCutout"}
        Pass
        {
            Tags{ "LightMode" = "ForwardBase" }
            //�ر��޳� ������ͱ��涼ȥ������Ⱦ
            Cull Off

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "Lighting.cginc"

            //������ͼ��Ӧ��ӳ���Ա
            sampler2D _MainTex;
            float4 _MainTex_ST;
            //��������ɫ���߹ⷴ����ɫ�������
            fixed4 _MainColor;
            fixed4 _SpecularColor;
            float _SpecularNum;
            //͸���Ȳ����õ���ֵ
            fixed _Cutoff;

            struct v2f
            {
                //�ü��ռ��µĶ�������
                float4 pos:SV_POSITION;
                //UV����
                float2 uv:TEXCOORD0;
                //����ռ��µķ���
                float3 wNormal:NORMAL;
                //����ռ��µĶ�������
                float3 wPos:TEXCOORD1;
            };

            v2f vert (appdata_base v)
            {
               v2f data;
               //��ģ�Ϳռ��µĶ���ת�����ü��ռ���
               data.pos = UnityObjectToClipPos(v.vertex);
               //uv�������
               data.uv = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
               //����ռ��µķ���
               data.wNormal = UnityObjectToWorldNormal(v.normal);
               //����ռ��µĶ�������
               data.wPos = mul(unity_ObjectToWorld, v.vertex);
               return data;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                //��ɫ�������ɫ��Ϣ
                fixed4 texColor = tex2D(_MainTex, i.uv);

                //�ж���ͼ�� ��ɫ��Ϣ�е� ͸��ͨ�� ��û��С����ֵ 
                //���С���� ��ֱ�Ӷ���
                clip(texColor.a - _Cutoff);
                //�൱��
                //if(texColor.a - _Cutoff < 0)
                //if(texColor.a < _Cutoff)
                //    discard;

                //��֪ʶ�㣺������ɫ��Ҫ�������������ɫ���ӣ��˷��� ��ͬ�������յ���ɫ
                fixed3 albedo = texColor.rgb * _MainColor.rgb;
                //��ķ���ָ���Դ����
                float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
                //��������������ɫ = �����ɫ * ��������ʵ���ɫ * max(0, dot(��������ϵ�µķ���, ��ķ���))
                //��֪ʶ�㣺�����ع���ģ�ͼ���ʱ�������������ɫʹ�� 1 �еĵ�����ɫ����
                fixed3 lambertColor = _LightColor0.rgb * albedo.rgb * max(0, dot(i.wNormal, lightDir));
                
                // �ӽǷ���
                //float3 viewDir = normalize(_WorldSpaceCameraPos.xyz - i.wPos);
                float3 viewDir = normalize(UnityWorldSpaceViewDir(i.wPos));
                //������� = �ӽǷ��� + ��ķ���
                float3 halfA = normalize(viewDir + lightDir);
                //�߹ⷴ�����ɫ = �����ɫ * �߹ⷴ����ʵ���ɫ * pow(max(0, dot(��������ϵ�µķ���, �������)), �����)
                fixed3 specularColor = _LightColor0.rgb * _SpecularColor * pow( max(0, dot(i.wNormal, halfA)), _SpecularNum);

                //���ַ�������ɫ = ��������ɫ + ��������������ɫ + �߹ⷴ�����ɫ
                //��֪ʶ�㣺����ʹ�õĻ��������ʱ�����������UNITY_LIGHTMODEL_AMBIENT��Ҫ�� 1 ����ɫ���г˷�����
                //         Ϊ�˱������յ���ȾЧ��ƫ��
                fixed3 color = UNITY_LIGHTMODEL_AMBIENT.rgb * albedo + lambertColor + specularColor;

                return fixed4(color.rgb, 1);
            }
            ENDCG
        }
    }
}
