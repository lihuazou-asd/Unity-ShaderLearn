using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson57 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ֪ʶ��һ ͸���Ȼ��������������������ģ�
        //�Ͻڿ�����ѧϰ��͸���Ȳ��ԣ�����������ʵ�ְ�͸��Ч��
        //��ֻ���ڿ��ü�����ȫ����������״̬��һ�����������ο�Ч��
        //����ڿ�Ҫѧϰ��͸���Ȼ�ϣ���Ҫ��������ʵ�ְ�͸��Ч����
        #endregion

        #region ֪ʶ��� ͸���Ȼ�ϵĻ���ԭ��
        //����ԭ��
        //  �ر����д�룬������ϣ���ƬԪ��ɫ����ɫ����������ɫ���л�ϼ���

        //����ʵ�֣�
        //  1. ���ð�͸���Ļ�����ӽ��л�� Blend SrcAlpha OneMinusSrcAlpha
        //     ���
        //     Ŀ����ɫ = SrcAlpha * Դ��ɫ + (1-SrcAlpha)*Ŀ����ɫ
        //             = Դ��ɫ͸���� * Դ��ɫ + (1-Դ��ɫ͸����) * Ŀ����ɫ
        //  2. ����һ��0~1�����_AlphaScale���ڿ��ƶ�������͸����
        #endregion

        #region ֪ʶ���� ͸���Ȼ��ʵ��
        //1.���Ǹ��� Lesson50 ����ɫ�����Ϲ���ģ�͵�Shader(��Ϊ���ǵĲ�����Դû�з�����ͼ������)
        //2.�������м�һ����ֵ_AlphaScale,ȡֵ��ΧΪ0~1�������趨��������͸���ȡ�����CG��������Ե�ӳ���Ա
        //3.����Ⱦ��������ΪTransparent�������IgnoreProjector��RenderTypeһ������
        //4.�ر����д��Zwrite off�����û������Blend SrcAlpha OneMinusSrcAlpha
        //5.��ƬԪ��ɫ���л�ȡ����ɫ��ͼ��ɫ���޸���󷵻���ɫ��AֵΪ ����.a * _AlphaScale
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
