using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson6 : MonoBehaviour
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

        //��Ⱦ��ǩ��ͨ����ǩ��ȷ��ʲôʱ���Լ���ζ����������Ⱦ
        #endregion

        #region ֪ʶ��һ ��Ⱦ��ǩ���﷨�ṹ
        //Tags{ "��ǩ��1" = "��ǩֵ1" "��ǩ��2" = "��ǩֵ2" "��ǩ��2" = "��ǩֵ2" .......}

        //��Ⱦ��ǩ��ͨ����ֵ�Ե���ʽ����������
        //����û���������ƣ�����ʹ����������ǩ
        #endregion

        #region ֪ʶ��� ��Ⱦ����Queue
        //��Ҫ���ã�
        //ȷ���������Ⱦ˳��

        //Tags{ "Queue" = "��ǩֵ" }
        //����UnityԤ�ȶ���õ���Ⱦ���б�ǩֵ��

        //1.Background(����)(���к�:1000)
        //  ���类��Ⱦ������Ķ��У�һ��������Ⱦ��պл��߱���
        //  Tags{ "Queue" = "Background" }

        //2.Geometry(����)(���к�:2000)
        //  ��͸���ļ�����ͨ��ʹ�øö��У���û��������Ⱦ����ʱ��Unity��Ĭ��ʹ���������
        //  Tags{ "Queue" = "Geometry" }

        //3.AlphaTest(͸������)(���к�:2450)
        //  ��͸��ͨ���ģ���Ҫ����Alpha���Եļ������ʹ�øö���
        //  ������Geometry����ʵ���������ٻ���AlphaTest���У�Ч�ʸ���
        //  Tags{ "Queue" = "AlphaTest" }

        //4.Transparent(͸����)(���к�:3000)
        //  �ö����м����尴����Զ������˳����л��ƣ���͸���������Ⱦ���У����н���͸����ϵļ����嶼Ӧ��ʹ�øö���
        //  ���磺�������ʣ�������Ч��
        //  Tags{ "Queue" = "Transparent" }

        //5.Overlay(����)(���к�:4000)
        //  ���Ƿ��������Ⱦ�Ķ��У��ڵ�����Ⱦ��Ч�������羵ͷ���ε�
        //  Tags{ "Queue" = "Overlay" }

        //6.�Զ������
        //  ����UnityԤ�ȶ���õ���Щ��Ⱦ���б�ǩ�����мӼ������������Լ�����Ⱦ����
        //  ���磺
        //  Tags{ "Queue" = "Geometry+1" }    ����Ķ��кž��� 2001
        //  Tags{ "Queue" = "Transparent-1" } ����Ķ��кž��� 2999
        //  �Զ��������һЩ��������£��ر�����
        //  ���� һЩˮ����Ⱦ ��Ҫ�ڲ�͸������֮�󣬰�͸������֮ǰ������Ⱦ���Ϳ����Զ���

        //  ע�⣺�Զ������ֻ�ܻ���Ԥ�ȶ���õĸ����ͽ��м��㣬������Shader��ֱ�Ӹ�ֵ����
        //       ���ʵ����Ҫֱ�Ӹ�ֵ���֣������ڲ�������н�������
        #endregion

        #region ֪ʶ���� ��Ⱦ����RenderType
        //��Ҫ���ã�
        //����ɫ�����з��֮࣬�����������ɫ���滻����
        //��������ж�Ӧ��API������ָ�������Ⱦ�������滻�ɱ����ɫ��

        //Tags{ "RenderType" = "��ǩֵ" }
        //����UnityԤ�ȶ���õ���Ⱦ���ͱ�ǩֵ��

        //1.Opaque(��͸����)
        //  ������ͨShader�����磺��͸�����Է��⡢�����
        //2.Transparent(͸����)
        //  ���ڰ�͸��Shader�����磺͸��������
        //3.TransparentCutout(͸���и�)
        //  ����͸������Shader�����磺ֲ��Ҷ��
        //4.Background(����)
        //  ������պ�Shader
        //5.Overlay(����)
        //  ����GUI����Halo���⻷����Flare�����Σ�

        //�˽⼴��
        //6.TreeOpaque
        //  ���ڵ���ϵͳ�е�����
        //7.TreeTransparentCutout
        //  ���ڵ���ϵͳ�е���Ҷ
        //8.TreeBillboard
        //  ���ڵ���ϵͳ�е�Billboarded��
        //9.Grass
        //  ���ڵ���ϵͳ�еĲ�
        //10.GrassBillboard
        //  ���ڵ���ϵͳ�е�Billboarded��
        #endregion

        #region ֪ʶ���� ����������
        //��Ҫ���ã�
        //��ʹ��������ʱ��ģ�ͻᱻ�任������ռ��У�ģ�Ϳռ�ᱻ����
        //����ܻᵼ��ĳЩʹ��ģ�Ϳռ䶥�����ݵ�Shader�����޷�ʵ����Ҫ�Ľ��
        //����ͨ���������������������������

        //���ǽ���������
        //Tags{ "DisableBatching" = "True" }

        //������������Ĭ��ֵ��
        //Tags{ "DisableBatching" = "False" }

        //�˽⼴��
        //LODЧ������ʱ�Ż������������Ҫ���ڵ���ϵͳ�ϵ���
        //Tags{ "DisableBatching" = "LODFading" }
        #endregion

        #region ֪ʶ���� ��ֹ��ӰͶӰ
        //��Ҫ���ã�
        //���Ƹ�SubShader�������Ƿ��Ͷ����Ӱ

        //��Ͷ����Ӱ
        //Tags{ "ForceNoShadowCasting" = "True" }
        //Ͷ����Ӱ��Ĭ��ֵ��
        //Tags{ "ForceNoShadowCasting" = "False" }
        #endregion

        #region ֪ʶ���� ����ͶӰ��
        //��Ҫ���ã�
        //�����Ƿ��ܵ�Projector��ͶӰ������Ͷ��
        //Projector��Unity�е�һ�����ܣ��Ժ󽲽⣩

        //����Projector��һ���͸��Shader��Ҫ�����ñ�ǩ��
        //Tags{ "IgnoreProjector" = "True" }

        //������Projector��Ĭ��ֵ��
        //Tags{ "IgnoreProjector" = "False" }
        #endregion

        #region ֪ʶ���� ������ǩ
        //1.�Ƿ����ھ���
        //��Ҫ����SubShader����Spriteʱ�����ñ�ǩ����ΪFalse
        //Tags{ "CanUseSpriteAtlas" = "False" }

        //2.Ԥ������
        //������Ԥ������Ĭ��Ϊ���Σ������Ҫ�ı�Ϊƽ�����պ�
        //ֻ��Ҫ�ı�Ԥ����ǩ����
        //ƽ��
        //Tags{ "PreviewType" = "Panel" }
        //��պ�
        //Tags{ "PreviewType" = "SkyBox" }
        #endregion

        #region ֪ʶ��� ��Ⱦ��ǩ��ע��ʵ��
        //������Щ��ǩֻ����SubShader����������
        //֮�󽲽��Pass��Ⱦͨ��������Ҳ����������Ⱦ��ǩ
        //���ǽ��콲������ݶ�������Pass������
        //Pass�����Լ�ר�ŵı�ǩ���ͣ����ǻ���֮�󽲽�
        #endregion

        #region �ܽ�
        //��Ⱦ��ǩ��ʵ�����Լ�ֵ�Ե���ʽ���ֵ�����
        //����ֵ�����ַ�������
        //��Щ��Ⱦ��ǩ��SubShader����Ⱦ����֮��Ĺ�ͨ����
        //���ǿ���������Ⱦ��ǩ������Unity����ϣ������Լ���ʱ��Ⱦ�������

        //��Щ���ݣ���ҿ��Խ�������Լ��ıʼǵ���
        //֮����ʹ������ʱ�������ʼǼ���
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
