using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson23 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ֪ʶ�ع� ShaderLab�������
        //Unity Shader��������Ҫ�ֳ������ࣺ��ֵ����ɫ��������������ͼ
        //���ԵĻ����﷨
        //  _Name("Display Name", type) = defaultValue[{options}]

        //  _Name: �������֣���������Ҫ��ǰ���һ���»��ߣ�������֮���ȡ
        //  Display Name:�����������ʾ������
        //  type:���Ե�����
        //  defaultValue:��Shaderָ�������ʵ�ʱ���ʼ����Ĭ��ֵ

        //��ֵ���������֣�
        //1.����
        //_Name("Display Name", Int) = number
        //2.������
        //_Name("Display Name", Float) = number
        //3.��Χ������
        //_Name("Display Name", Range(min,max)) = number

        //4.��ɫ
        //_Name("Display Name", Color) = (number1,number2,number3,number4)
        //ע�⣺��ɫֵ�е�RGBA��ȡֵ��Χ�� 0~1 ��ӳ��0~255��
        //5.����
        //_Name("Display Name", Vector) = (number1,number2,number3,number4)
        //ע�⣺����ֵ�е�XYZW��ȡֵ��Χû������

        //6.2D ������õ�������������ͼ��������ͼ������2D����
        //_Name("Display Name", 2D) = "defaulttexture"{}

        //7.2DArray �����������飬�����������д洢���ͼ�����ݣ�ÿ�㿴��һ��2Dͼ��һ��ʹ�ýű�����������ʹ�ã��˽⼴�ɣ�
        //_Name("Display Name", 2DArray) = "defaulttexture"{}

        //8.Cube map texture����������������ǰ����������6������ϵ��2D��ͼƴ�ɵ������壬������պкͷ���̽�룩
        //_Name("Display Name", Cube) = "defaulttexture"{}

        //9.3D����һ��ʹ�ýű�����������ʹ�ã��˽⼴�ɣ�
        //_Name("Display Name", 3D) = "defaulttexture"{}
        #endregion

        #region ֪ʶ��һ CG�б������͵Ķ�ӦShaderLab����������
        //       ShaderLab��������          CG��������
        //         Color,Vector          float4,half4,fixed4
        //        Range,Float,Int        float,half,fixed
        //             2D                  sampler2D
        //            Cube                 samplerCube
        //             3D                  sampler3D
        //           2DArray             sampler2DArray
        #endregion

        #region ֪ʶ��� �����CG������ʹ��ShaderLab������������
        //ֱ����CG������
        //�����������ж�Ӧ���͵�ͬ����������
        #endregion

        #region �ܽ�
        //ShaderLab�����������Զ�����Ҫ��Shader(��ɫ��)�߼���ʹ�õ�
        //������Ҫ��CG�����������Զ�Ӧ���͵�ͬ������
        //�����Ϳ�����֮���Shader(��ɫ��)�߼���ȥ������ʵ�ֶ�Ӧ���߼���

        //������Ҫ���յľ���ShaderLab�������ͺ�CG�������͵Ķ�Ӧ��ϵ
        #endregion

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
