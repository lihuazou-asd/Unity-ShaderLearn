Shader "Unlit/Lesson52"
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

            float4 _MainColor;//��������ɫ
            sampler2D _MainTex;//��ɫ����
            float4 _MainTex_ST;//��ɫ��������ź�ƽ��
            sampler2D _BumpMap;//��������
            float4 _BumpMap_ST;//������������ź�ƽ��
            float _BumpScale;//��͹�̶�
            float4 _SpecularColor;//�߹���ɫ
            fixed _SpecularNum;//�����

            struct v2f
            {
                float4 pos:SV_POSITION;
                //float2 uvTex:TEXCOORD0;
                //float2 uvBump:TEXCOORD1;
                //���ǿ��Ե�������������float2�ĳ�Ա���ڼ�¼ ��ɫ�ͷ��������uv����
                //Ҳ����ֱ������һ��float4�ĳ�Ա xy���ڼ�¼��ɫ�����uv��zw���ڼ�¼���������uv
                float4 uv:TEXCOORD0;
                //������������������λ�� ��Ҫ���� ֮��� �ӽǷ���ļ���
                //float3 worldPos:TEXCOORD1;
                //���� �� ����ռ�� �任����
                //float3x3 rotation:TEXCOORD2;

                //�����������߿ռ䵽����ռ�� �任�����3��
                float4 TtoW0:TEXCOORD1;
                float4 TtoW1:TEXCOORD2;
                float4 TtoW2:TEXCOORD3;
            };

            v2f vert (appdata_full v)
            {
                v2f data;
                //��ģ�Ϳռ��µĶ���ת���ü��ռ���
                data.pos = UnityObjectToClipPos(v.vertex);
                //�������������ƫ��
                data.uv.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                data.uv.zw = v.texcoord.xy * _BumpMap_ST.xy + _BumpMap_ST.zw;
                //�õ�����ռ��µ� ����λ�� ����֮����ƬԪ�м����ӽǷ�������ռ��µģ�
                //data.worldPos = mul(unity_ObjectToWorld, v.vertex);
                float3 worldPos = mul(unity_ObjectToWorld, v.vertex);
                //��ģ�Ϳռ��µķ��ߡ�����ת��������ռ���
                float3 worldNormal = UnityObjectToWorldNormal(v.normal);
                float3 worldTangent = UnityObjectToWorldDir(v.tangent);
                //���㸱���� �����˽���� ��ֱ�����ߺͷ��ߵ����������� ͨ������ ���ߵ��е�w���Ϳ���ȷ������һ��
                float3 worldBinormal = cross(normalize(worldTangent), normalize(worldNormal)) * v.tangent.w;
                //����������� ���߿ռ䵽����ռ�� ת������
                //data.rotation = float3x3( worldTangent.x, worldBinormal.x,  worldNormal.x,
                //                          worldTangent.y, worldBinormal.y,  worldNormal.y,
                //                          worldTangent.z, worldBinormal.z,  worldNormal.z);
                data.TtoW0 = float4(worldTangent.x, worldBinormal.x,  worldNormal.x, worldPos.x);
                data.TtoW1 = float4(worldTangent.y, worldBinormal.y,  worldNormal.y, worldPos.y);
                data.TtoW2 = float4(worldTangent.z, worldBinormal.z,  worldNormal.z, worldPos.z);

                return data;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                //����ռ��¹�ķ���
                fixed3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
                //����ռ����ӽǷ���
                float3 worldPos = float3(i.TtoW0.w, i.TtoW1.w, i.TtoW2.w);
                fixed3 viewDir = normalize(UnityWorldSpaceViewDir(worldPos));

                //ͨ������������� ȡ������������ͼ���е�����
                float4 packedNormal = tex2D(_BumpMap, i.uv.zw);
                //������ȡ�����ķ������� ���������㲢�ҿ��ܻ���н�ѹ�������㣬���յõ����߿ռ��µķ�������
                float3 tangentNormal = UnpackNormal(packedNormal);
                //���԰�͹�̶ȵ�ϵ��
                tangentNormal.xy *= _BumpScale;
                tangentNormal.z = sqrt(1.0 - saturate(dot(tangentNormal.xy, tangentNormal.xy)));
                //�Ѽ�����Ϻ�����߿ռ��µķ���ת��������ռ���
                //float3x3 rotation = float3x3(i.TtoW0.xyz, i.TtoW1.xyz, i.TtoW2.xyz );
                //float3 worldNormal = mul(rotation, tangentNormal);
                //���� �����ڽ��о�������
                float3 worldNormal = float3(dot(i.TtoW0.xyz, tangentNormal), dot(i.TtoW1.xyz, tangentNormal), dot(i.TtoW2.xyz, tangentNormal));

                //�������������� ����ɫ����� ���ַ�����ģ�ͼ���

                //��ɫ�������������ɫ�� ����
                fixed3 albedo = tex2D(_MainTex, i.uv.xy) * _MainColor.rgb;
                //������
                fixed3 lambertColor = _LightColor0.rgb * albedo.rgb * max(0, dot(worldNormal, normalize(lightDir)));
                //�������
                float3 halfA = normalize(normalize(viewDir) + normalize(lightDir));
                //�߹ⷴ��
                fixed3 specularColor = _LightColor0.rgb * _SpecularColor.rgb * pow(max(0, dot(worldNormal, halfA)), _SpecularNum);
                //���ַ�
                fixed3 color = UNITY_LIGHTMODEL_AMBIENT.rgb * albedo + lambertColor + specularColor;

                return fixed4(color.rgb, 1);
            }
            ENDCG
        }
    }
}
