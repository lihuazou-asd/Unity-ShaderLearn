using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson59 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ֪ʶ��һ ˫����Ⱦ��͸��Ч������������������ģ�
        //������ʵ����İ�͸�����壬���ǲ�������͸���������������������
        //Ҳ���Կ�����������Լ����ڲ��ṹ
        //��������֮ǰʵ�ֵ� ͸���Ȳ��� �� ͸���Ȼ�� ���Shader
        //���޷�����ģ�͵��ڲ��ṹ

        //��˫����Ⱦ��͸��Ч��Shader����������������
        //�����ǲ�������͸����͸�����忴��������������ӻ����Կ����Լ����ڲ��ṹ
        #endregion

        #region ֪ʶ��� ˫����Ⱦ��͸��Ч���Ļ���ԭ��
        //����ԭ��
        //  Ĭ������£�Unity���Զ��޳�����ı��棬��ֻ��Ⱦ���������
        //  ˫����Ⱦ�Ļ���ԭ�������������֮ǰѧϰ���� Cull �޳�ָ��������ָ������
        //  Cull Back     �����޳�
        //  Cull Front    �����޳�
        //  Cull Off      ���޳�
        //  �����õĻ���Ĭ��Ϊ�����޳�

        //  ����͸���Ȳ���Shader
        //  �����������ϣ��������ֱ�� �ر��޳�����

        //  ����͸���Ȼ��Shader
        //  ��������Ҫ���л��
        //  ��Ҫʹ������Pass��һ��������Ⱦ���棬һ��������Ⱦ����
        //  ����Pass�г����޳����ͬ ���������֮ǰһ��
        #endregion

        #region ֪ʶ���� ʵ�� ˫����Ⱦ��͸��Ч��Shader
        //͸���Ȳ���
        //  1.���� Lesson56 ͸���Ȳ������Shader����
        //  2.��Pass�йر��޳� Cull Off

        //͸���Ȼ��
        //  1.���� Lesson57 ͸���Ȼ�����Shader����
        //  2.����֮ǰ��Pass���������һģһ����Pass
        //  3.�ڵ�һ��Pass���޳����� Cull Front���ڵڶ���Pass���޳�����Cull Back
        //    �൱��һ��ƬԪ����Ⱦ��������Ⱦ����
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
