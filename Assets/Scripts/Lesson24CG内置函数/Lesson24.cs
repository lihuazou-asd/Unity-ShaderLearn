using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson24 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ֪ʶ��һ CG���ú�����ʲô��
        //Unity Shader�е�CG����
        //�ṩ�˸�������ͼ�α�̵ĺ���
        //��Щ������CGΪ���Ƿ�װ�õ��߼�
        //���ǿ���ʹ����������дUnity Shader
        #endregion

        #region ֪ʶ��� ����Щ���ú�����

        #region 1.��ѧ����
        #region ���Ǻ������
        //sincos(float x, out s, out c)     �ú���ͬʱ����x��sinֵ��cosֵͨ��s��c���з��أ��ȷֱ������ࣩܶ
        //sin(x)                            ���Һ���
        //cos(x)                            ���Һ���
        //tan(x)                            ���к���
        //sinh(x)                           ˫�����Һ���
        //cosh(x)                           ˫�����Һ���
        //tanh(x)                           ˫�����к���
        //asin(x)                           �����Һ��������������Χ[-1,1]������[-��/2,��/2]����ĽǶ�ֵ
        //acos(x)                           �����Һ��������������Χ[-1,1]������[0,��]����ĽǶ�ֵ
        //atan(x)                           �����к��������������Χ[-1,1]������[-��/2,��/2]����ĽǶ�ֵ
        //atan2(y,x)                        ����y/x�ķ�����ֵ����atan����һ����ֻ�����������ͬ��atan(x)=atan2(x,1)   
        #endregion

        #region �������������
        //cross(A,B)                        ��ˣ�ע�⣺����������������ά������
        //dot(A,B)                          ��ˣ�ע�⣺����������������ά������
        //mul(M,N)                          ���������������
        //mul(M,v)                          ���������������
        //mul(v,M)                          ���������;������
        //transpose(M)                      MΪ���󣬼���M��ת�þ���
        //determinant(m)                    ������������ʽ����
        #endregion

        #region ��ֵ���
        //abs(x)                            ������������ľ���ֵ
        //ceil(x)                           �������������ȡ��
        //floor(x)                          �������������ȡ��
        //clamp(x,a,b)                      ���xС��a���򷵻�a��x����b���򷵻�b�����򣬷���x��"�н�"������
        //radians(x)                        �Ƕ�ת����
        //degrees(x)                        ����ת�Ƕ�
        //max(a,b)                          �������ֵ
        //min(a,b)                          ������Сֵ
        //sqrt(x)                           ��x��ƽ������x�������0
        //pow(x,y)                          x��y�η���ֵ
        //round(x)                          ��x��������
        //rsqrt(x)                          x�ķ�ƽ������x�������0
        //lerp(a,b,f)                       ��ֵ����������(1-f)*a + b*f ���� a + f*(b-a)��ֵ

        //exp(x)                            ����e��x�η���ֵ��e=2.71828182845904523536
        //exp2(x)                           ����2��x�η���ֵ
        //fmod(x,y)                         ����x/y��������y��Ϊ0
        //frac(x)                           ���ر�����ÿ��ʸ��������С������
        //frexp(x,out exp)                  ��������x�ֽ�Ϊβ����ֱ������ x = m * 2��exp�η�������m����ָ���洢exp��
        //isfinite(x)                       �жϱ������������е�ÿ�������Ƿ���������������Ƿ���true�����򷵻�false
        //isinf(x)                          �жϱ������������е�ÿ�������Ƿ������ޣ�����Ƿ���true�����򷵻�false
        //isnan(x)                          �жϱ������������е�ÿ�������Ƿ��Ƿ����ݣ�����Ƿ���true�����򷵻�false
        //ldexp(x,n)                        ����x * 2��n�η� ��ֵ
        //log(x)                            ����ln(x)��ֵ��x�������0
        //log2(x)                           ����log2(x�η�)��ֵ��x�������0
        //log10(x)                          ����log2(x�η�)��ֵ��x�������0
        //saturate(x)                       ���xС��0������0�����x����1������1�����򣬷���x
        //sign(x)                           ���x����0������1�����xС��0������-1�����򣬷���0
        //smoothstep(min,max,x)             ֵxλ��min��max�����ڣ����x=min������0�����x=max������1�����������֮�䣬����
        //                                  -2* ((x-min)/(max - min))�����η� + 3* ((x - min)/(max - min))��2�η�
        //step(a,x)                         ���x<a,����0�����򣬷���1
        //all(x)                            �����������Ϊ0���򷵻�true;���򷵻�False���൱���߼���&&
        //any(x)                            �������ֻҪ������һ����Ϊ0���򷵻�true���൱���߼���||
        #endregion

        #region ����
        //lit(NdotL,NdotH,m)                N��ʾ��������L��ʾ�����������H��ʾ���������m��ʾ�߹�ϵ��
        //                                  �ú������㻷���⡢ɢ��⡢�����Ĺ��ף�����4ά������
        //                                  xλ��ʾ�����⹱�ף�yλ��ʾɢ��⹱�ף�zλ��ʾ����⹱�ף�wʼ��Ϊ1
        //noise(x)                          ��������������ֵʼ����0~1֮�䣻������ͬ�����룬ʼ�շ�����ֵͬ����������������������
        #endregion
        #endregion

        #region 2.���κ���
        //length(v)                     ����һ��������ģ��
        //normalize(v)                  ��һ������
        //distance(p1,p2)               ��������֮��ľ���
        //reflect(I,N)                  ���㷴��ⷽ��������IΪ����⣬NΪ���㷨��������I��ָ�򶥵�ģ�I��N���뱻��һ����������3ά����
        //refract(I,N,eta)              ��������������IΪ����⣬NΪ���㷨������etaΪ����ϵ����I��ָ�򶥵�ģ�I��N���뱻��һ����������3ά����
        #endregion

        #region 3.������
        //ע�⣺��Щ���������������ֵΪ fixed4 ���͵���ɫֵ

        #region ��ά����
        //tex2D(sampler2D tex, float2 s)                                    ��ά�����ѯ
        //tex2D(sampler2D tex, float2 s, float2 dsdx, float2 dsdy)          ʹ�õ���ֵ��ѯ��ά����
        //tex2D(sampler2D tex, float3 sz)                                   ��ά�����ѯ�����������ֵ�Ƚ�
        //tex2D(sampler2D tex, float3 sz, float2 dsdx, float2 dsdy)         ʹ�õ���ֵ��ѯ��ά�������������ֵ�Ƚ�
        //tex2Dproj(sampler2D tex, float3 sq)                               ��άͶӰ�����ѯ
        //tex2Dproj(sampler2D tex, float4 szq)                              ��άͶӰ�����ѯ�����������ֵ�Ƚ�
        #endregion

        #region ����������
        //texCUBE(samplerCUBE tex, float3 s)                                ��ѯ����������
        //texCUBE(samplerCUBE tex, float3 s, float3 dsdx, float3 dsdy)      ��ϵ���ֵ��ѯ����������
        //texCUBEDproj(samplerCUBE tex, float4 sq)                          ��ѯ������ͶӰ�������������ֵ�Ƚ�
        #endregion

        #region ��������
        //tex1D(sampler1D tex, float s)                                     һά�����ѯ
        //tex1D(sampler1D tex, float s, float dsdx, float dsdy)             ʹ�õ���ֵ��ѯһά����
        //tex1D(sampler1D tex, float2 sz)                                   һά�����ѯ�����������ֵ�Ƚ�
        //tex1D(sampler1D tex, float2 sz, float dsdx, float dsdy)           ʹ�õ���ֵ��ѯһά�������������ֵ�Ƚ�
        //tex1Dproj(sampler1D tex, float2 sq)                               һάͶӰ�����ѯ
        //tex1Dproj(sampler1D tex, float3 szq)                              һάͶӰ�����ѯ�����������ֵ�Ƚ�

        //texRECT(samplerRECT tex, float2 s)                                ���������ѯ
        //texRECT(samplerRECT tex, float2 s, float2 dsdx, float2 dsdy)      ʹ�õ���ֵ��ѯ��������
        //texRECT(samplerRECT tex, float3 sz)                               ���������ѯ�����������ֵ�Ƚ�
        //texRECT(samplerRECT tex, float3 sz, float2 dsdx, float2 dsdy)     ʹ�õ���ֵ��ѯ�����������������ֵ�Ƚ�
        //texRECTproj(samplerRECT tex, float3 sq)                           ����ͶӰ�����ѯ
        //texRECTproj(samplerRECT tex, float3 szq)                          ����ͶӰ�����ѯ�����������ֵ�Ƚ�

        //tex3D(sampler3D tex, float3 s)                                    ��ѯ��ά����
        //tex3D(sampler3D tex, float3 s, float3 dsdx, float3 dsdy)          ��ϵ���ֵ��ѯ��ά����
        //tex3DDproj(sampler3D tex, float4 sq)                              ��ѯ��άͶӰ�������������ֵ�Ƚ�
        #endregion
        #endregion

        #endregion

        #region �ܽ�
        //��ڿε���ҪĿ��
        //���ô�Ҷ�CG���Ե����ú�����һ�������˽�
        //�����Ҫ�ѳ��ú�����¼���Լ��ıʼǵ��У�����֮���Ҳ���ʹ��
        //Ҳ����ͨ�������������鿴�������غ���
        //https://learn.microsoft.com/en-us/windows/win32/direct3dhlsl/dx-graphics-hlsl-intrinsic-functions
        //����HLSL��Ӧ�����ú�����CG�������ƣ�ע�⣺�������к�������Unity�б�֧�֣�
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
