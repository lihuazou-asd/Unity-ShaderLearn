using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson48 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ֪ʶ�ع� ���ú���������ά�����������
        //fixed4 tex2D(sampler2D tex, float2 s)
        //��������ͼƬ��uv����
        //��������ͼƬ�ж�Ӧλ�õ���ɫֵ
        #endregion

        #region ֪ʶ�� ��д����������ɫ����Shader

        #region ��һ�� ���Shader�ļ������ṹ�����䲻����
        #endregion

        #region �ڶ��� �������Ժ�CG��Ա��������
        //  �ؼ�֪ʶ��
        //  CG��ӳ��ShaderLab�е��������ԣ���Ҫ��������Ա����
        //  һ������ӳ��������ɫ���ݣ�һ������ӳ����������ƽ������
        //
        //  ShaderLab�е�����
        //  ͼƬ���ԣ�2D��
        //  ��������UV������ȡ������ɫ

        //  CG������ӳ�����Եĳ�Ա����
        //  1.sampler2D ����ӳ������ͼƬ
        //  2.float4    ����ӳ������ͼƬ�����ź�ƽ��
        //              �̶�������ʽ ������_ST (S����scale���� T����translationƽ��)
        #endregion

        #region ������ ������ƽ�Ʋ�������uvֵ����
        //1.��λ�ȡģ����Я����uv��Ϣ��
        //  �ڶ�����ɫ���У����ǿ�������TEXCOORD�����ȡ��ģ���е�����������Ϣ
        //  ����һ��float4���͵�
        //  xy��ȡ���������������ˮƽ�ʹ�ֱ����
        //  zw��ȡ����������Я����һЩ������Ϣ���������ֵ��

        //2.��μ���
        //  �̶��㷨
        //  �����ţ���ƽ(ƫ)��
        //  �����ó˷���ƽ(ƫ)�üӷ�
        //  ��������.xy * ������_ST.xy + ������_ST.wz
        //  ����ֱ�������ú�
        //  TRANSFORM_TEX(�����������, �������)
        //  �ú����ڲ��������ͬ�ļ���
        #endregion

        #region ���Ĳ� ��ƬԪ��ɫ���н���������ɫ����

        #endregion

        #endregion

        #region �ܽ�
        //������ɫ�����ǳ���
        //1.������ɫ���л�ȡ��ģ���е�����������Ϣ
        //  ������ص�����ƫ�Ƽ���󷵻�
        //2.ƬԪ��ɫ���õ���ֵ���uv��������������
        //  ���ض�Ӧ����ɫ
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
