using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson21 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ֪ʶ��һ ���������
        //CG�������ṩ�� ���� ��������ؼ����������κ����еĴ�������ͷ���ֵ
        //������Ҫ��������Shader֪���������ȡ���ݣ������������������
        //��������Shader�������п��Ի�ȡ����Ҫ�����ݣ����ҿ��԰����ݴ��ݳ�ȥ

        //ע�⣺Unity��ֻ֧��CG���еĲ�������
        #endregion

        #region ֪ʶ��� ��������

        #region Ӧ�ý׶Ρ���>������ɫ��
        //Ӧ�ý׶δ���ģ�����ݸ�������ɫ��ʱUnity֧�ֵ�����
        //һ���ڶ�����ɫ���ص������Ĵ��������Ӧ��

        //POSITION:
        //ģ�Ϳռ��еĶ���λ�ã�ͨ����float4����

        //NORMAL:
        //���㷨�ߣ�ͨ����float3����

        //TANGENT:
        //�������ߣ�ͨ����float4����

        //TEXCOORDn:
        //���� TEXCOORD0,TEXCOORD1....
        //�ö�����������꣬ͨ����float2����float4����
        //TEXCOORD0��ʾ��һ���������꣬��������
        //�������꣺Ҳ��UV���꣬��ʾ�ö����Ӧ����ͼ���ϵ�λ��

        //COLOR:
        //������ɫ��ͨ����fixed4��float4����
        #endregion

        #region ������ɫ������>ƬԪ��ɫ��
        //�Ӷ�����ɫ���������ݸ�ƬԪ��ɫ��ʱUnity֧�ֵ�����
        //һ���ڶ�����ɫ���ص������ķ���ֵ��Ӧ��

        //SV_POSITION:
        //�ü��ռ��еĶ������꣨�ر���

        //COLOR0:
        //ͨ�����������һ�鶥����ɫ�����Ǳ���ģ�

        //COLOR1:
        //ͨ����������ڶ��鶥����ɫ�����Ǳ���ģ�

        //TEXCOORD0~TEXCOORD7:
        //ͨ����������������꣨���Ǳ���ģ�
        #endregion

        #region ƬԪ��ɫ�����
        //ƬԪ��ɫ�����ʱUnity֧�ֵĳ�������
        //һ����ƬԪ��ɫ���ص������ķ���ֵ��Ӧ��

        //SV_Target:
        //���ֵ��洢����ȾĿ����

        #endregion

        #endregion

        #region ֪ʶ���� ��������
        //HLSL������ܣ�
        //https://learn.microsoft.com/zh-cn/windows/win32/direct3dhlsl/dx-graphics-hlsl-semantics?redirectedfrom=MSDN
        //CG������󲿷ֺ�HLSL����ͬ���ڴ����˽⼴��
        //�Ժ������õ���������ʱ�������ؽ��⼴��
        #endregion

        #region �ܽ�
        //�������Ҫ��������Shader֪���������ȡ���ݣ������������������
        //�����ڱ�д����ƬԪ��ɫ���ص�����������߼�ʱ
        //������Ҫʹ������ȥ���κ��������ͷ���ֵ
        //�������ǲ��ܻ�ȡ��������Ҫ�����ݣ����Ұѽ��������ȷ�ķ��س�ȥ������һ���̴���

        //������Ҫ�����������¼�������Ա����ʹ��
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
