using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson35 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region �ؼ�֪ʶ��ع�
        //�߹ⷴ�������ɫ = ��Դ����ɫ * ���ʸ߹ⷴ����ɫ * max��0, ��׼����۲췽�������� ��׼����ķ��䷽����

        //1.�۲��ߵ�λ�ã��������λ�ã�
        //  _WorldSpaceCameraPos
        //2.����ڷ������ķ������� ����
        //  reflect(��������,���㷨����) ���ط�������
        //3.ָ���� ����
        //  pow(������ָ��) ���ؼ�����
        #endregion

        #region ֪ʶ�� ����Phongʽ�߹ⷴ�����ģ��ʵ�ֹ���Ч�����𶥵���գ�
        //�ؼ�����
        //1.�������������ʸ߹ⷴ����ɫ������ȣ�
        //2.��Ⱦ��ǩTags���� ��LightMode����ģʽ ����ΪForwardBase��ǰ��Ⱦ��ͨ�����ڲ�͸������Ļ�����Ⱦ��
        //3.���������ļ�UnityCG.cginc��Lighting.cginc
        //4.�ṹ������
        //5.������ʽʵ���߼�
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
