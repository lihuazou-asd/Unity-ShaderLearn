using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson43 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ֪ʶ��һ Blinn Phong����ģ�͵�������ԭ��
        //������
        //Blinn Phong����ģ������֮ǰ�ᵽ��
        //�����ɼ�ķ�����֣�Jim Blinn�������������ѧ�ң�
        //��1977��ʱ����Phong����ģ�ͻ����Ͻ����޸������
        //����Phongһ����һ������ģ�ͣ�����������ʵ�����еĹ�������
        //����ֻ�ǿ�������ȷ

        //ԭ��
        //Blinn Phong��Phong����ģ��һ������Ϊ������淴�����������������ɵ�
        //������ + ������� + ���淴��⣨�߹ⷴ��⣩
        #endregion

        #region ֪ʶ��� Blinn Phong����ģ�͵Ĺ�ʽ
        // Blinn Phong����ģ�͹�ʽ��
        //������������ɫ = ��������ɫ + ���������ɫ + �߹ⷴ�����ɫ
        //���У�
        //��������ɫ = UNITY_LIGHTMODEL_AMBIENT(unity_AmbientSky��unity_AmbientEquator��unity_AmbientGround)
        //���������ɫ = �����ع���ģ�� ����õ�����ɫ
        //�߹ⷴ�����ɫ = Blinn Phongʽ�߹ⷴ�����ģ�� ����õ�����ɫ
        #endregion

        #region �ܽ�
        //Blinn Phong����ģ�͹�ʽ��
        //������������ɫ = ��������ɫ + �����ع���ģ��������ɫ + Blinn Phongʽ�߹ⷴ�����ģ��������ɫ
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
