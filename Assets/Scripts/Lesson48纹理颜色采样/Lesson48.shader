Shader "Unlit/Lesson48"
{
    Properties
    {
        //������
        _MainTex("MainTex", 2D) = ""{}
    }
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            //ӳ���Ӧ�������Ե�ͼƬ��ɫ�������
            sampler2D _MainTex;
            //ӳ���Ӧ�������Ե� ���� ƽ(ƫ)������
            float4 _MainTex_ST; //xy�������� zw����ƽ��

            v2f_img vert (appdata_base v)
            {
               v2f_img data;
               data.pos = UnityObjectToClipPos(v.vertex);
               //v.texcoord.xy //����uv����
               //v.texcoord.zw //����һЩ������Ϣ
               //������ ��ƽ�� �����һ���̶����㷨 �������
               //���û�н������ź�ƽ�� ��ô �������� ֵ�ǲ�������仯��
               //��Ϊ����Ĭ��ֵ��1��1 ��ƽ��Ĭ��ֵ��0��0
               data.uv = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
               //������һ��д��
               //TRANSFORM_TEX(v.texcoord.xy, _MainTex);
               return data;
            }

            fixed4 frag (v2f_img i) : SV_Target
            {
                //�⴫���uv �Ǿ�����ֵ������ ����ÿһ��ƬԪ�����Լ���һ��uv����
                //�������ܾ�׼������ͼ����ȡ����ɫ
                fixed4 color = tex2D(_MainTex, i.uv);

                return color;
            }
            ENDCG
        }
    }
}
