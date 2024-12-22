// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/Lesson20"
{
    Properties
    {
        
    }
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex myVert
            #pragma fragment myFrag

            //������ɫ�� �ص����� 
            //POSITION �� SV_POSITION��CG���Ե�����
            //POSITION����ģ�͵Ķ���������䵽����Ĳ���v����
            //SV_POSITION��������ɫ������������ǲü��ռ��еĶ�������
            //���û����Щ�������޶��������������Ļ�����ô��Ⱦ������ȫ��֪���û������������ʲô���ͻ�õ������Ч��
            float4 myVert(float4 v:POSITION):SV_POSITION
            {
                //mul��CG�����ṩ�ľ���������ĳ˷����㺯��������һ�����õĺ�����
                //UNITY_MATRIX_MVP ����һ���任���� ��Unity���õ�ģ�͡��۲졢ͶӰ����ļ���
                //UnityObjectToClipPos�������ú�֮ǰ�ľ���˷���һ���ģ���ҪĿ�ľ����ڽ�������任 ֻ�����°汾�����װ������ ʹ�ø��ӷ���
                //mul(UNITY_MATRIX_MVP,v);
                return UnityObjectToClipPos(v);
            }

            //ƬԪ��ɫ�� �ص�����
            //SV_Target:������Ⱦ�������û������ɫ�洢��һ����ȾĿ���У����ｫ�����Ĭ�ϵ�֡������
            fixed4 myFrag():SV_Target
            {
                return fixed4(0,1,0,1);
            }

            ENDCG
        }
    }
}
