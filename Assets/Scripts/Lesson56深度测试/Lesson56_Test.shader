Shader "Unlit/Lesson56_Test"
{
    Properties
    {
       //主要就是将单张纹理Shader和布林方光照模型逐片元Shader进行一个结合
       _MainTex("MainTex", 2D) = ""{}
       //漫反射颜色、高光反射颜色、光泽度
       _MainColor("MainColor", Color) = (1,1,1,1)
       _SpecularColor("SpecularColor", Color) = (1,1,1,1)
       _SpecularNum("SpecularNum", Range(0,20)) = 15
       _CutOff("AlphaNum",range(0,1)) = 0
    }
    SubShader
    {
        Tags{ "Queue" = "AlphaTest" "IgnoreProjector" = "True" "RenderType" = "TransparentCutout" }
        Pass
        {
            Tags{ "LightMode" = "ForwardBase" }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "Lighting.cginc"

            //纹理贴图对应的映射成员
            sampler2D _MainTex;
            float4 _MainTex_ST;
            //漫反射颜色、高光反射颜色、光泽度
            fixed4 _MainColor;
            fixed4 _SpecularColor;
            float _SpecularNum;
            float _CutOff;

            struct v2f
            {
                //裁剪空间下的顶点坐标
                float4 pos:SV_POSITION;
                //UV坐标
                float2 uv:TEXCOORD0;
                //世界空间下的法线
                float3 wNormal:NORMAL;
                //世界空间下的顶点坐标
                float3 wPos:TEXCOORD1;
            };

            v2f vert (appdata_base v)
            {
               v2f data;
               //把模型空间下的顶点转换到裁剪空间下
               data.pos = UnityObjectToClipPos(v.vertex);
               //uv坐标计算
               data.uv = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
               //世界空间下的法线
               data.wNormal = UnityObjectToWorldNormal(v.normal);
               //世界空间下的顶点坐标
               data.wPos = mul(unity_ObjectToWorld, v.vertex);
               return data;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 textureColor = tex2D(_MainTex, i.uv);
                if(textureColor.w<_CutOff)
                {
                    discard;
                }
                //新知识点：纹理颜色需要和漫反射材质颜色叠加（乘法） 共同决定最终的颜色
                fixed3 albedo = textureColor.rgb * _MainColor.rgb;
                //光的方向（指向光源方向）
                float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
                //兰伯特漫反射颜色 = 光的颜色 * 漫反射材质的颜色 * max(0, dot(世界坐标系下的法线, 光的方向))
                //新知识点：兰伯特光照模型计算时，漫反射材质颜色使用 1 中的叠加颜色计算
                fixed3 lambertColor = _LightColor0.rgb * albedo.rgb * max(0, dot(i.wNormal, lightDir));
                
                // 视角方向
                //float3 viewDir = normalize(_WorldSpaceCameraPos.xyz - i.wPos);
                float3 viewDir = normalize(UnityWorldSpaceViewDir(i.wPos));
                //半角向量 = 视角方向 + 光的方向
                float3 halfA = normalize(viewDir + lightDir);
                //高光反射的颜色 = 光的颜色 * 高光反射材质的颜色 * pow(max(0, dot(世界坐标系下的法线, 半角向量)), 光泽度)
                fixed3 specularColor = _LightColor0.rgb * _SpecularColor * pow( max(0, dot(i.wNormal, halfA)), _SpecularNum);

                //布林方光照颜色 = 环境光颜色 + 兰伯特漫反射颜色 + 高光反射的颜色
                //新知识点：最终使用的环境光叠加时，环境光变量UNITY_LIGHTMODEL_AMBIENT需要和 1 中颜色进行乘法叠加
                //         为了避免最终的渲染效果偏灰
                fixed3 color = UNITY_LIGHTMODEL_AMBIENT.rgb * albedo + lambertColor + specularColor;

                return fixed4(color.rgb, 1);
            }
            ENDCG
        }
    }
}
