using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson29 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region �ؼ�֪ʶ�ع�
        //��ʽ��
        //�����������ɫ = ��Դ����ɫ * ���ʵ���������ɫ * max��0, ��׼����������淨�������� ��׼�����Դ����������

        //1.��Դ����ɫ
        //  Lighting.cginc �����ļ��е� _LightColor0
        //2.��Դ�ķ���
        //  _WorldSpaceLightPos0 ��ʾ��Դ0����������ϵ�µ�λ��
        //3.������һ������
        //  normalize
        //4.ȡ���ֵ����
        //  max
        //5.��˷���
        //  dot
        //6.�����ع���ģ�ͻ��������������ģ�⻷����������Ӱ�죬����������Ӱ������ȫ�ڰ���
        //  UNITY_LIGHTMODEL_AMBIENT.rgb
        //7.�����ߴ�ģ�Ϳռ�ת��������ռ�
        //  UnityObjectToWorldNormal
        #endregion

        #region ֪ʶ�� ���������ع���ģ��ʵ�ֹ���Ч�����𶥵���գ�
        //�ؼ�����
        //1.������������ɫ��������
        //2.��Ⱦ��ǩTags���� ��LightMode����ģʽ ����ΪForwardBase��ǰ��Ⱦ��ͨ�����ڲ�͸������Ļ�����Ⱦ��
        //3.���������ļ�UnityCG.cginc��Lighting.cginc
        //4.�ṹ������
        //5.���ڹ�ʽʵ���߼�
        //
        //ע�⣺Ϊ����Ӱ����ȫ�ڣ���Ҫ���������ػ�������ɫ��������
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
