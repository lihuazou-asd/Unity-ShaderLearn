using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson37 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ֪ʶ��һ ������ɫ���
        //������ѧϰ�����ع���ģ��ʱ�˽���������ɫ���
        //������������������ɫ������һ��
        //��������ɫ��RGBAֵ������˵õ�һ���µ���ɫ

        //��������ɫ��ӵ����� ͬ������������ɫ������һ��
        //����������ɫ��˵������ǣ�
        //���: ��ɫ���ʱ��������ɫ������ɫ��£
        //      ����������ɫ���ʱһ������ɫ���
        //      ��Ϊ��ʵ�����ж����ɫ����һ�����ջ��ɺ�ɫ

        //���: ��ɫ���ʱ��������ɫ������ɫ��£
        //      ������շ���ʱһ������ɫ��ӣ���Ϊ���ɫ��£�ܴ��� �����ĸо������Ϲ�ı���
        #endregion

        #region ֪ʶ��� Unity Shader�еĻ�����
        //������ѧϰ�����غͰ������ع���ģ��ʱ
        //�ڼ�������������պ󣬼�����һ����������� UNITY_LIGHTMODEL_AMBIENT
        //��ô��������������ʵ�ǿ�����Unity�н������õ�

        //Window����>Rendering����>Lighting
        //Environment(����)ҳǩ�е�Environment Lighting(������)
        //����������û�������Դ
        //����Skybox��Colorʱ�����ǿ���ͨ�� UNITY_LIGHTMODEL_AMBIENT ��ȡ����Ӧ��������ɫ
        //����Gradient�����䣩ʱ��ͨ������3����Ա���Եõ���Ӧ�Ļ�����
        //  unity_AmbientSky����Χ����ջ����⣩
        //  unity_AmbientEquator����Χ�ĳ�������⣩
        //  unity_AmbientGround����Χ�ĵ��滷���⣩

        //ע�⣺
        //��Щ���ñ����������� UnityShaderVariables.cginc ��
        //�ڱ���ʱ�����Զ��������ļ������Բ����ֶ�����
        #endregion

        #region ֪ʶ���� Phong����ģ�͵�������ԭ��
        //������
        //Phong����ģ������֮ǰ�ᵽ��
        //����������磨Bui-Tuong Phong��Խ�������������ѧ�ң�
        //��1975��ʱ�������һ�־ֲ����վ���ģ��

        //ԭ��
        //�������Ϊ������淴�����������������ɵ�
        //������ + ������� + ���淴��⣨�߹ⷴ��⣩
        #endregion

        #region ֪ʶ���� Phong����ģ�͵Ĺ�ʽ
        //Phong����ģ�͹�ʽ��
        //������������ɫ = ��������ɫ + ���������ɫ + �߹ⷴ�����ɫ
        //���У�
        //��������ɫ = UNITY_LIGHTMODEL_AMBIENT(unity_AmbientSky��unity_AmbientEquator��unity_AmbientGround)
        //���������ɫ = �����ع���ģ�� ����õ�����ɫ
        //�߹ⷴ�����ɫ = Phongʽ�߹ⷴ�����ģ�� ����õ�����ɫ
        #endregion

        #region �ܽ�
        //Phong����ģ�͹�ʽ��
        //������������ɫ = ��������ɫ + �����ع���ģ��������ɫ + Phongʽ�߹ⷴ�����ģ��������ɫ
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
