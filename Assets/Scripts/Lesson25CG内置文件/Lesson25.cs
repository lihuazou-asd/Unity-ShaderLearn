using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson25 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ֪ʶ��һ CG�����ļ���λ�ú�����
        //���ǿ�����Unity�İ�װĿ¼���ҵ�CG�����ļ�
        //��Editor��>Data��>CGIncludes��
        //��׺Ϊcginc���ļ�ΪCG���������ļ�
        //��׺Ϊglslinc���ļ�ΪGLSL���������ļ�

        //������Ԥ�����Shader�ļ�
        //���������һЩ�Ѿ�д�õ�Shader����߼�
        //���ú�CG���ú���һ���������������ǵ�Shader����Ч��
        //����ֱ��ʹ�����еķ����������������߼�����

        //Unity�г��õ������ļ���
        //1.UnityCG.cginc                     ������õİ�����������ͽṹ���
        //2.Lighting.cginc                    �����������ù���ģ�͡������д����Surface Shader(��׼������ɫ���������Զ���������
        //3.UnityShaderVariables.cginc        ����UnityShaderʱ�����Զ���������������������õ�ȫ�ֱ���
        //4.HLSLSupport.cginc                 ����UnityShaderʱ�����Զ����������������˺ܶ����ڿ�ƽ̨����ĺ�Ͷ���
        //�ȵ�
        #endregion

        #region ֪ʶ��� ���ʹ��CG�����ļ�
        //��CG�����н�������
        //ͨ������ָ��
        //#include "�����ļ���.cginc"
        //����ʽ��������
        //���Ǳ������CG������ʹ�����е�����

        //ע�⣺һЩ���õĺ������ꡢ���������Բ������ã�Unity���ڱ���ʱ�Զ�ʶ��
        //     ����Ϊ�˱��ⱨ�����鶼����

        //"��"ͨ��ָ����һ��Ԥ����ָ������Ƭ�Σ������ڴ����н����ı��滻��
        //���������Ա����һ����ʶ����ͨ���Դ�д��ĸ��ʾ��������һ������Ƭ�Σ�
        //Ȼ���ڱ���ʱ�������ʶ���滻Ϊ��Ӧ�Ĵ��룬�����滻���̳�Ϊ��չ����

        //˵�˻�������ΪһЩ����Ƭ�Σ�ȡһ������������ʹ�á�����������ʱ�ڰ������������ɶ�Ӧ�Ĵ��롣
        #endregion

        #region ֪ʶ���� ��������

        #region ����(UnigyCG.cginc��)
        //1.float3 WorldSpaceViewDir(float4 v)
        //  ����һ��ģ�Ϳռ��еĶ���λ�ã���������ռ��дӸõ㵽������Ĺ۲췽��

        //2.float3 ObjSpaceViewDir(float4 v)
        //  ����һ��ģ�Ϳռ��еĶ���λ�ã�����ģ�Ϳռ��дӸõ㵽������Ĺ۲췽��

        //3.float3 WorldSpaceLightDir(float4 v)
        //  ��������ǰ��Ⱦ�С�����һ��ģ�Ϳռ��еĶ���λ�ã���������ռ��дӸõ㵽��Դ�Ĺ��շ��򡣣�����ֵû�б���һ����

        //4.flaot3 ObjSpaceLightDir(float4 v)
        //  ��������ǰ��Ⱦ�С�����һ��ģ�Ϳռ��еĶ���λ�ã�����ģ�Ϳռ��дӸõ㵽��Դ�Ĺ��շ��򡣣�����ֵû�б���һ����

        //5.float3 UnityObjectToWorldNormal(float3 norm)
        //  �ѷ��߷����ģ�Ϳռ�ת��������ռ���

        //6.float3 UnityObjectToWorldDir(in float3 dir)
        //  �ѷ���ʸ����ģ�Ϳռ�ת��������ռ���

        //7.float3 UnityWorldToObjectDir(float3 dir)
        //  �ѷ���ʸ��������ռ�ת����ģ�Ϳռ���

        //�ȵ�
        #endregion

        #region �ṹ��(UnigyCG.cginc��)
        //1.appdata_base
        //  ���ڶ�����ɫ������
        //  ����λ�á����㷨�ߡ���һ����������

        //2.appdata_tan
        //  ���ڶ�����ɫ������
        //  ����λ�á����㷨�ߡ��������ߡ���һ����������

        //3.appdata_full
        //  ���ڶ�����ɫ������
        //  ����λ�á����㷨�ߡ��������ߡ����飨����ࣩ��������

        //4.appdata_img
        //  ���ڶ�����ɫ������
        //  ����λ�á���һ����������

        //5.v2f_img
        //  ���ڶ�����ɫ�����
        //  �ü��ռ��е�λ�ã���������

        //�ȵ�
        #endregion

        #region �任�����(UnityShaderVariables.cginc��)
        //����ռ�任˳��
        //  ģ�Ϳռ� -> ����ռ� -> �۲�ռ� -> �ü��ռ� -> ��Ļ�ռ�

        //1.UNITY_MATRIX_MVP
        //  ��ǰ��ģ��*�۲�*ͶӰ�������ڽ�����/����������ģ�Ϳռ�任���ü��ռ���

        //2.UNITY_MATRIX_MV
        //  ��ǰ��ģ��*�۲�������ڽ�����/����������ģ�Ϳռ�任���۲�ռ���

        //3.UNITY_MATRIX_V
        //  ��ǰ�Ĺ۲�������ڽ�����/��������������ռ�任���۲�ռ���

        //4.UNITY_MATRIX_P
        //  ��ǰ��ͶӰ�������ڽ�����/���������ӹ۲�ռ�任���ü��ռ���

        //5.UNITY_MATRIX_VP
        //  ��ǰ�Ĺ۲�*ͶӰ�������ڽ�����/��������������ռ�任���ü��ռ���

        //6.UNITY_MATRIX_T_MV
        //  UNITY_MATRIX_MV��ת�þ���

        //7.UNITY_MATRIX_IT_MV
        //  UNITY_MATRIX_MV����ת�þ������ڽ����ߴ�ģ�Ϳռ�任���۲�ռ䣬Ҳ�����ڵõ�UNITY_MATRIX_MV�������

        //8._Object2World
        //  ��ǰ��ģ�;������ڽ�����/����ʸ����ģ�Ϳռ�任������ռ�

        //9._World2Object
        //  _Object2World����������ڽ�����/����ʸ��������ռ�任��ģ�Ϳռ�

        //�ȵ�
        #endregion

        #region ����
        //1._Time (�������ã�ֱ��ʹ�ü���)
        //  �Թؿ�����������ʱ�䣨t/20��t��t*2��t*3�����ڶ���ɫ���ڵ�������ж�������
        //2._LightColor0 (��ǰ��Ⱦʱ��UnityLightingCommon.cginc���ӳ���Ⱦ��UnityDeferredLibrary.cginc)
        //  �����ɫ
        //�ȵ�
        #endregion

        #endregion

        #region �ܽ�
        //CG�е������ļ������ú���һ��
        //�����ڰ������ǽ���Shader������
        //�������еĺ������ꡢȫ�ֱ���������
        //������������Shader�Ŀ���Ч��
        //������Ҫ�����ǣ�����Щ�������ݼǵ��ʼ���
        //֮����в���
        //�����Ҫ�˽������������ݿ��Բ���Unity����������
        //�����ļ���أ�https://docs.unity3d.com/Manual/SL-BuiltinIncludes.html
        //������أ�https://docs.unity3d.com/Manual/SL-BuiltinFunctions.html
        //����أ�https://docs.unity3d.com/Manual/SL-BuiltinMacros.html
        //������أ�https://docs.unity3d.com/Manual/SL-UnityShaderVariables.html
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
