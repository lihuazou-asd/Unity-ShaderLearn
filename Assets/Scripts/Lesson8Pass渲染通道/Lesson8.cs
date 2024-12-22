using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson8 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ֪ʶ�ع�
        //SubShader����ɫ����������Ϊ��
        //             --------Tags(��Ⱦ��ǩ)
        //            |--------States(��Ⱦ״̬)
        //SubShader---|--------Pass(��Ⱦͨ��1)
        //            |--------Pass(��Ⱦͨ��2)
        //             --------....(��Ⱦͨ��n)

        //��Ⱦͨ��������ʵ����ɫ������ĵط���ÿ��SubShader������������һ����Ⱦͨ���������ж����
        #endregion

        #region ֪ʶ��һ ��Ⱦͨ�����﷨�ṹ
        //Pass{
        //  1.Name ����
        //  2.��Ⱦ��ǩ
        //  3.��Ⱦ״̬
        //  4.������ɫ������
        //}
        #endregion

        #region ֪ʶ��� Pass������
        //��Ҫ���ã�
        //���Ƕ�Pass��������ҪĿ��
        //��������UsePass����������Shader���и��ø�Pass�Ĵ���,
        //ֻ��Ҫ������Shader����ʹ��
        //UsePass "Shader·��/Pass��"
        //ע�⣺
        //Unity�ڲ����Pass����ת��Ϊ��д��ĸ
        //�����ʹ��UsePass����ʱ����ʹ�ô�д��ʽ������

        //Pass{
        //  Name MyPass
        //}

        //������Shader�и��ø�Pass����ʱ
        //UsePass "TeachShader/Lesson4/MYPASS"
        #endregion

        #region ֪ʶ���� Pass�е���Ⱦ��ǩ
        //Pass�е���Ⱦ��ǩ�﷨��SubShader����ͬ
        //Tags{ "��ǩ��1" = "��ǩֵ1" "��ǩ��2" = "��ǩֵ2" "��ǩ��2" = "��ǩֵ2" .......}
        //��������֮ǰ�������SubShader�����е���Ⱦ��ǩ���ܹ���Pass��ʹ��
        //Pass�������Լ�ר�ŵ���Ⱦ��ǩ

        #region 1.Tags{ "LightMode" = "��ǩֵ" }
        //1.Tags{ "LightMode" = "��ǩֵ" }
        //��Ҫ���ã�
        //ָ���˸�PassӦ�����ĸ��׶�ִ��
        //���Խ���ɫ�����������ʵ�����Ⱦ�׶Σ���ʵ�������Ч��

        //1-1.Always
        //    ʼ����Ⱦ����Ӧ�ù���
        //1-2.ForwardBase
        //    ��ǰ����Ⱦ��ʹ�ã�Ӧ�û����⡢������⡢����/SH ��Դ�͹�����ͼ
        //1-3.ForwardAdd
        //    ��ǰ����Ⱦ��ʹ�ã�Ӧ�ø��ӵ�ÿ���ع�Դ��ÿ����Դ��һ��ͨ����
        //1-4.Deferred
        //    ���ӳ���Ⱦ��ʹ�ã���Ⱦ G ������
        //1-5.ShadowCaster
        //    �����������Ⱦ����Ӱ��ͼ�����������
        //1-6.MotionVectors
        //    ���ڼ���ÿ�����˶�ʸ��
        //1-7.PrepassBase
        //    �ھɰ��ӳٹ�����ʹ�ã���Ⱦ���ߺ;��淴��ָ��
        //1-8.PrepassFinal
        //    �ھɰ��ӳٹ�����ʹ�ã�ͨ������������պͷ�������Ⱦ������ɫ
        //1-9.Vertex
        //    �����󲻽��й�����ͼʱ�ھɰ涥�������Ⱦ��ʹ�ã�Ӧ�����ж����Դ
        //1-10.VertexLMRGBM
        //    �����󲻽��й�����ͼʱ�ھɰ涥�������Ⱦ��ʹ�ã��ڹ�����ͼΪ RGBM �����ƽ̨�ϣ�PC ����Ϸ������
        //1-11.VertexLM
        //    �����󲻽��й�����ͼʱ�ھɰ涥�������Ⱦ��ʹ�ã��ڹ�����ͼΪ˫ LDR �����ƽ̨�ϣ��ƶ�ƽ̨��

        //������ǰ��Ⱦ���ӳ���Ⱦ���ɰ���յȸ����˽�
        //https://docs.unity.cn/cn/2019.4/Manual/RenderingPaths.html
        #endregion

        #region 2.Tags{ "RequireOptions" = "��ǩֵ" }
        //2.Tags{ "RequireOptions" = "��ǩֵ" }
        //��Ҫ���ã�
        //����ָ��������ĳЩ����ʱ����Ⱦ��Pass

        //ĿǰUnity��֧��
        //Tags{ "RequireOptions" = "SoftVegetation" }
        //����Quality�����п�����SoftVegetationʱ����Ⱦ��ͨ��
        #endregion

        #region 3.Tags{ "PassFlags" = "��ǩֵ" }
        //3.Tags{ "PassFlags" = "��ǩֵ" }
        //��Ҫ���ã�
        //һ����Ⱦͨ��Pass��ָʾһЩ��־��������Ⱦ������Pass�������ݵķ�ʽ

        //ĿǰUnity��֧��
        //Tags{ "PassFlags" = "OnlyDirectional" }
        //�� ForwardBase ��ǰ��Ⱦ��ͨ��������ʹ��ʱ���˱�־�������ǽ������������ͻ�����/����̽�����ݴ��ݵ���ɫ��
        //����ζ�ŷ���Ҫ��Դ�����ݽ����ᴫ�ݵ������Դ����г������ɫ������
        #endregion

        #endregion

        #region ֪ʶ���� Pass�е���Ⱦ״̬
        //�����Ͻڿ���SubShader������ѧϰ����Ⱦ״̬ͬ��������Pass
        //����
        //�޳���ʽ������ ģ�����汳���Ƿ��ܹ�����Ⱦ
        //��Ȼ������Ȳ��� �����˾����ϵ��ȷ���Լ�͸��Ч������ȷ����
        //��Ϸ�ʽ ������͸����͸����ɫ����ȷ���֣��Լ�һЩ������ɫЧ���ı���
        //��Щ��Ⱦ״̬�������ڵ���Pass�н�������
        //��Ҫע�����
        //�����SubShader������ʹ�û�Ӱ��֮���������Ⱦͨ��Pass
        //�����Pass������ʹ��ֻ��Ӱ�쵱ǰPass��Ⱦͨ��������Ӱ��������Pass

        //������ˣ�Pass�л�����ʹ�ù̶�������ɫ��������
        #endregion

        #region ֪ʶ���� ������ɫ������
        //�������벿�־���ʵ����ɫ���ĺ��Ĵ��벿��
        //���ǿ��ܻ��õ�CG��HLSL����ɫ�������������߼���д
        //����֮�����ϸ����
        #endregion

        #region ֪ʶ���� GrabPass����
        // ���ǿ�������GrabPass����Ѽ������ƶ���ʱ����Ļ����ץȡ��������
        // �ں���ͨ���м���ʹ�ô������Ӷ�ִ�л���ͼ��ĸ߼�Ч����

        //������
        //�����Ƹö���֮ǰ����Ļץȡ�� _BackgroundTexture ��
        //GrabPass
        //{
        //    "_BackgroundTexture"
        //}
        //ע�⣺
        //������һ��д��ĳ��Passǰ����֮���Pass�����п�������_BackgroundTexture�������д���
        #endregion

        #region �ܽ�
        //Pass��Ⱦͨ��������
        //��Ҫ������
        //1.���֣����԰������Ǹ���Pass����
        //2.��Ⱦ��ǩ������ʹ��SubShader�е���Ⱦ��ǩ�����Լ����е���Ⱦ��ǩ
        //3.��Ⱦ״̬��SubShader���е���Ⱦ״̬ͬ��������Pass��ʹ�ã�Ӱ�������ͬ
        //4.��ɫ�������߼�������֮�����ϸѧϰ�Ĳ���
        //�ĸ�����
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
