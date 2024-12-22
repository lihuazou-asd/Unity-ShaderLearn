Shader "Unlit/Lesson51"
{
    Properties
    {
        _MainColor("MainColor", Color) = (1,1,1,1)
        _MainTex("MainTex", 2D) = ""{}
        _BumpMap("BumpMap", 2D) = ""{}
        _BumpScale("BumpScale", Range(0,1)) = 1
        _SpecularColor("SpecularColor", Color) = (1,1,1,1)
        _SpecularNum("SpecularNum", Range(0,20)) = 18
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
                //float2 uvTex:TEXCOORD0;
                //float2 uvBump:TEXCOORD1;
                //���ǿ��Ե�������������float2�ĳ�Ա���ڼ�¼ ��ɫ�ͷ��������uv����
                //Ҳ����ֱ������һ��float4�ĳ�Ա xy���ڼ�¼��ɫ�����uv��zw���ڼ�¼���������uv
                float4 uv:TEXCOORD0;
                //��ķ��� ��������߿ռ��µ�
                float3 lightDir:TEXCOORD1;
                //�ӽǵķ��� ��������߿ռ��µ�
                float3 viewDir:TEXCOORD2;
            };

            float4 _MainColor;//��������ɫ
            sampler2D _MainTex;//��ɫ����
            float4 _MainTex_ST;//��ɫ��������ź�ƽ��
            sampler2D _BumpMap;//��������
            float4 _BumpMap_ST;//������������ź�ƽ��
            float _BumpScale;//��͹�̶�
            float4 _SpecularColor;//�߹���ɫ
            fixed _SpecularNum;//�����

            v2f vert (appdata_full v)
            {
                v2f data;
                //��ģ�Ϳռ��µĶ���ת���ü��ռ���
                data.pos = UnityObjectToClipPos(v.vertex);
                //�������������ƫ��
                data.uv.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                data.uv.zw = v.texcoord.xy * _BumpMap_ST.xy + _BumpMap_ST.zw;

                //�ڶ�����ɫ������ �õ� ģ�Ϳռ䵽���߿ռ�� ת������
                //���ߡ������ߡ�����
                //���㸱���� �����˽���� ��ֱ�����ߺͷ��ߵ����������� ͨ������ ���ߵ��е�w���Ϳ���ȷ������һ��
                float3 binormal = cross(v.tangent.xyz, v.normal) * v.tangent.w;
                //ת������
                float3x3 rotation = float3x3( v.tangent.xyz,
                                              binormal,
                                              v.normal);
                //ģ�Ϳռ��µĹ�ķ���
                //data.lightDir = ObjSpaceLightDir(v.vertex);
                //����ģ�Ϳռ䵽���߿ռ��ת������ �Ϳ��Եõ����߿ռ��µ� ��ķ�����
                data.lightDir = mul(rotation, ObjSpaceLightDir(v.vertex));

                //ģ�Ϳռ��µ��ӽǵķ���
                //data.viewDir = ObjSpaceViewDir(v.vertex);
                data.viewDir = mul(rotation, ObjSpaceViewDir(v.vertex));

                return data;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                //ͨ������������� ȡ������������ͼ���е�����
                float4 packedNormal = tex2D(_BumpMap, i.uv.zw);
                //������ȡ�����ķ������� ���������㲢�ҿ��ܻ���н�ѹ�������㣬���յõ����߿ռ��µķ�������
                float3 tangentNormal = UnpackNormal(packedNormal);
                //���԰�͹�̶ȵ�ϵ��
                tangentNormal *= _BumpScale;

                //�������������� ����ɫ����� ���ַ�����ģ�ͼ���

                //��ɫ�������������ɫ�� ����
                fixed3 albedo = tex2D(_MainTex, i.uv.xy) * _MainColor.rgb;
                //������
                fixed3 lambertColor = _LightColor0.rgb * albedo.rgb * max(0, dot(tangentNormal, normalize(i.lightDir)));
                //�������
                float3 halfA = normalize(normalize(i.viewDir) + normalize(i.lightDir));
                //�߹ⷴ��
                fixed3 specularColor = _LightColor0.rgb * _SpecularColor.rgb * pow(max(0, dot(tangentNormal, halfA)), _SpecularNum);
                //���ַ�
                fixed3 color = UNITY_LIGHTMODEL_AMBIENT.rgb * albedo + lambertColor + specularColor;

                return fixed4(color.rgb, 1);
            }
            ENDCG
        }
    }
}
