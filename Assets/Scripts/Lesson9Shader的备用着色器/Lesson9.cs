using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson9 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ֪ʶ�ع�
        //ShaderLab��Ҫ��4���������
        //1.Shader������
        //2.Shader������
        //3.1~n������ɫ��
        //4.���õ�Shader

        //��һ����
        //Shader "��ɫ������" 
        //{ 
        //      //�ڶ�����
        //      Properties
        //      {
        //          //��������Ͽ��Կ���������
        //      }

        //      //��������
        //      SubShader
        //      {
        //           Tags(��Ⱦ��ǩ)
        //           States(��Ⱦ״̬)
        //           Pass(��Ⱦͨ��1)
        //           Pass(��Ⱦͨ��2)
        //           ....(��Ⱦͨ��n)
        //      }
        //      SubShader
        //      {
        //           Tags(��Ⱦ��ǩ)
        //           States(��Ⱦ״̬)
        //           Pass(��Ⱦͨ��1)
        //           Pass(��Ⱦͨ��2)
        //           ....(��Ⱦͨ��n)
        //      }
        //      .....������n��SubShader�����

        //      //���Ĳ���
        //      Fallback "���õ�Shader"
        //}
        #endregion

        #region ֪ʶ��һ ����Shader������
        //����֪��ShaderLab���������ж��SubShader����ɫ��
        //��ִ����Ⱦʱ������ϵ���ʹ�õ�һ���ܹ�����ִ�е�SubShader����ɫ������Ⱦ����

        //����û�п�������SubShade����ɫ�������ܹ����Կ���ִ���أ�
        //���ǿ϶���
        //�п��ܳ�����ĳһ���豸�ϣ������Զ��������SubShader���޷�����ִ�У��豸�Կ��޷�֧��һЩapi�������
        //��ô��ʱ����Shader�Ϳ����𵽺ܴ������ˣ������ٿ����ö����ܹ�������Ⱦ����

        //���
        //����Shader��Ҫ���þ��ǵ�Shader�ļ��е�����SubShader����ɫ�����޷���������ʱ
        //��һ���������ã��������ܹ�ʹ��һ����ͼ���Shaderȥ��Ⱦ������Ч���Բ�������ܹ���ʾ��
        #endregion

        #region ֪ʶ��� ����Shader���﷨
        //Fallback "Shader��"
        //����
        //Fallback Off

        //��Fallback�ؼ��ʺ���ո�ͨ��һ���ַ���������Unity
        //����ͼ���Unity Shader����˭
        //Ҳ����ֱ�ӹر�Fallback���ܣ���������ر��Ǿ���ζ�š��������ơ�
        #endregion

        #region �ܽ�
        //����Shader���﷨�ǳ��� 
        //Fallback "Shader��"
        //����
        //Fallback Off

        //������Ҫ���þ����ṩ���������ݡ�
        //����һ���ʹ�ý�Ϊ�ͼ���Ч����Ϊ����Shader
        //ȷ�������ڵͶ��豸��Ҳ�ܹ�������Ⱦ
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
