using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson46 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ֪ʶ��һ ���ù��ռ�����غ�����ʲô��
        //������ʵ�ֹ���ģ��ʱ
        //���������һЩ��ѧ����
        //���� ���ꡢ������ص�ת��
        //��UnityCG.cginc���ṩ��һЩ���õĺ���
        //���԰������ǿ�ݵĽ�����ѧ����

        //��������֮ǰ�����ߴ�ģ�Ϳռ�ת��������ռ�ķ���
        //UnityObjectToWorldNormal ��

        //������Щ���ú��������ǾͲ���Ҫ�Լ�ȥͨ����ѧ�������õ������
        //ֱ�ӵ���API���ɵõ�������Ҫ�Ľ��

        //����֮ǰ�����ڿγ����õ���һЩ������
        //����һЩ���������ú���
        //��ڿ�������Ҫ���Ƕ����ǽ����˽�
        #endregion

        #region ֪ʶ��� �������ú���
        //1. float3 WorldSpaceViewDir(float4 v)
        //   ����ģ�Ϳռ��µĶ���λ�ã���������ռ��дӸõ㵽������Ĺ۲췽��

        //2. float3 UnityWorldSpaceViewDir(flaot4 v)
        //   ��������ռ��еĶ���λ�ã���������ռ��дӸõ㵽������Ĺ۲췽��

        //3. float3 ObjSpaceViewDir(float4 v)
        //   ����ģ�Ϳռ��еĶ���λ�ã�����ģ�Ϳռ��дӸõ㵽������Ĺ۲췽��

        //4. float3 WorldSpaceLightDir(float4 v)
        //   (��������ǰ��Ⱦ��)
        //   ����ģ�Ϳռ��еĶ���λ�ã���������ռ��иõ㵽��Դ�Ĺ��շ���û�й�һ����

        //5. float3 UnityWorldSpaceLightDir(float4 v)
        //   (��������ǰ��Ⱦ��)
        //   ��������ռ��еĶ���λ�ã���������ռ��дӸõ㵽��Դ�Ĺ��շ���û�й�һ����

        //6. float3 ObjSpaceLightDir(float4 v)
        //   (��������ǰ��Ⱦ��)
        //   ����ģ�Ϳռ��еĶ���λ�ã�����ģ�Ϳռ��дӸõ㵽��Դ�Ĺ��շ���û�й�һ����

        //7. float3 UnityObjectToWorldNormal(float3 normal)
        //   �ѷ��ߴ�ģ�Ϳռ�ת��������ռ���

        //8. float3 UnityObjectToWorldDir(float3 dir)
        //   �ѷ���ʸ����ģ�Ϳռ�ת��������ռ���

        //9. float3 UnityWorldToObjectDir(float3 dir)
        //   �ѷ���ʸ��������ռ�ת����ģ�Ϳռ���   

        //10.float4 UnityObjectToClipPos(float4 v)
        //   ����ģ�Ϳռ��еĶ���λ�ã����زü��ռ��µĶ���λ��
        #endregion

        #region �ܽ�
        //���԰���Щ���ú����ǵ��ʼ���
        //�Ժ�ʹ��ʱ�������伴��
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
