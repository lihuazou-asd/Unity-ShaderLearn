Shader "Unlit/Lesson22"
{
    Properties
    {
        _MyColor("MyColor",Color) = (1,0,0,1) 
        _My2D("My2D",2D) = ""{}
    }
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            fixed4 _MyColor;
            sampler2D _My2D;
            //�ýṹ��
            //�����ڴ�Ӧ�ý׶λ�ȡ��Ӧ�������ݺ�
            //���ݸ�������ɫ���ص�������
            struct a2v
            {
                //��������(����ģ�Ϳռ�)
                float4 vertex:POSITION;
                //���㷨��(����ģ�Ϳռ�)
                float3 normal:NORMAL;
                //��������(uv����)
                float2 uv:TEXCOORD0;
            };


            //�Ӷ�����ɫ�����ݸ�ƬԪ��ɫ���� �ṹ������ 
            //ͬ��������ĳ�ԱҲ��Ҫ������ȥ��������
            struct v2f
            {
                //�ü��ռ��µ�����
                float4 position:SV_POSITION;
                //���㷨��(����ģ�Ϳռ�)
                float3 normal:NORMAL;
                //��������(uv����)
                float2 uv:TEXCOORD0;
            };

            v2f vert(a2v data)
            {
                //��Ҫ���ݸ�ƬԪ��ɫ��������
                v2f v2fData;
                v2fData.position = UnityObjectToClipPos(data.vertex);
                v2fData.normal = data.normal;
                v2fData.uv = data.uv;

                return v2fData;
            }

          
            fixed4 frag(v2f data):SV_Target
            {

                return tex2D(_My2D,data.uv);
            }
            ENDCG
        }
    }
}
