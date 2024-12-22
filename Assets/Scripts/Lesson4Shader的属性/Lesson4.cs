using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson4 : MonoBehaviour
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
        //          //����-Ƭ����ɫ�� �� ������ɫ�� �� �̶�������ɫ��
        //      }
        //      SubShader
        //      {
        //          //���Ӿ���İ汾
        //          //Ŀ����������豸
        //      }
        //      .....������n��SubShader�����

        //      //���Ĳ���
        //      Fallback "���õ�Shader"
        //}
        #endregion

        #region ֪ʶ��һ Shader�����Ե�����
        //��Shader��дʱ���Ǿ������õ���ͬ���͵ı�������ͼ����Դ
        //Ϊ������Shader�Ŀɵ����ԣ���Щ��������ֱ����Shader������д��
        //������Ϊ���ŵ�������ʾ�����ǵĲ�������ϣ�������ʹ��ʱ����
        //����Щ���ŵ����Ծ���ͨ�������������
        //Shader�����Ծ��������ص�
        //1.�����ڲ�����屻�༭
        //2.�����ں���������������ṩ����������ɫ��ʹ��
        #endregion

        #region ֪ʶ��� Shader�����ԵĻ����﷨
        //1.��Shader�ļ���
        //  Shader�����Ǵ�����Shader�����е�Properties��������
        //  ����ֻ��Ҫ��Properties�����а����﷨�����������Լ���

        //2.Unity Shader��������Ҫ�ֳ������ࣺ��ֵ����ɫ��������������ͼ

        //3.���ԵĻ����﷨
        //  _Name("Display Name", type) = defaultValue[{options}]

        //  _Name: �������֣���������Ҫ��ǰ���һ���»��ߣ�������֮���ȡ
        //  Display Name:�����������ʾ������
        //  type:���Ե�����
        //  defaultValue:��Shaderָ�������ʵ�ʱ���ʼ����Ĭ��ֵ

        //���ӣ�
        //��һ����
        //Shader "��ɫ������" 
        //{ 
        //      //�ڶ�����
        //      Properties
        //      {
        //          //��������Ͽ��Կ���������
        //          _Name("Display Name", type) = defaultValue[{options}]
        //      }

        //      //�������Ĳ���
        //      .......
        //      .......
        //}
        #endregion

        #region ֪ʶ���� ��ֵ��������
        //��ֵ���������֣�
        //1.����
        //_Name("Display Name", Int) = number
        //2.������
        //_Name("Display Name", Float) = number
        //3.��Χ������
        //_Name("Display Name", Range(min,max)) = number

        //ע�⣺Unity Shader�е���ֵ�������Ի������Ǹ�����(Float)����
        //     ��Ȼ�ṩ������(Int)�����Ǳ���ʱ���ն���ת��Ϊ������
        //     ������Ǹ����ʹ�õĻ���Float����
        #endregion

        #region ֪ʶ���� ��ɫ��������������
        //��ɫ��������������֮���Թ�����һ��
        //����Ϊ
        //��ɫ����RGBA�ĸ���������
        //��������XYZW�ĸ���������
        //���Ƕ�������һ���ĸ�����ɵ����ͱ�ʾ

        //1.��ɫ
        //_Name("Display Name", Color) = (number1,number2,number3,number4)
        //ע�⣺��ɫֵ�е�RGBA��ȡֵ��Χ�� 0~1 ��ӳ��0~255��
        //2.����
        //_Name("Display Name", Vector) = (number1,number2,number3,number4)
        //ע�⣺����ֵ�е�XYZW��ȡֵ��Χû������
        #endregion

        #region ֪ʶ���� ������ͼ��������
        //������ͼ����������
        //1.2D ������õ�������������ͼ��������ͼ������2D����
        //_Name("Display Name", 2D) = "defaulttexture"{}

        //2.2DArray �����������飬�����������д洢���ͼ�����ݣ�ÿ�㿴��һ��2Dͼ��һ��ʹ�ýű�����������ʹ�ã��˽⼴�ɣ�
        //_Name("Display Name", 2DArray) = "defaulttexture"{}

        //3.Cube map texture����������������ǰ����������6������ϵ��2D��ͼƴ�ɵ������壬������պкͷ���̽�룩
        //_Name("Display Name", Cube) = "defaulttexture"{}

        //4.3D����һ��ʹ�ýű�����������ʹ�ã��˽⼴�ɣ�
        //_Name("Display Name", 3D) = "defaulttexture"{}

        //ע�⣺
        //1.����defaulttextureĬ��ֵȡֵ
        //  ��д:Ĭ����ͼΪ��
        //  white:Ĭ�ϰ�ɫ��ͼ��RGBA:1,1,1,1��
        //  black:Ĭ�Ϻ�ɫ��ͼ��RGBA:0,0,0,1��
        //  gray:Ĭ�ϻ�ɫ��ͼ��RGBA:0.5,0.5,0.5,1��
        //  bump:Ĭ��͹��ͼ��RGBA:0.5,0.5,1,1��,һ�����ڷ�����ͼĬ����ͼ
        //  red��Ĭ�Ϻ�ɫ��ͼ��RGBA:1,0,0,1��

        //2.����Ĭ��ֵ����� {} ,�̶�д�����ϰ汾�������ڿ��Կ��ƹ̶�����������������ɣ������°汾��û�иù����ˣ�

        #endregion

        #region �ܽ�
        //Shader��������Ҫ������������
        //��ֵ����ɫ��������������ͼ
        //����ֻ��Ҫ�������������Ļ����﷨����
        //������Ҫ�ǣ�
        //1.�����ڲ�����屻�༭
        //2.�����ں���������������ṩ����������ɫ��ʹ��
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
