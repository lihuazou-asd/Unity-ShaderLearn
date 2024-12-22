Shader "Unlit/Lesson48Test"
{
    Properties
    {
        _MainTex("MainTex",2D) = ""{}
    }
    SubShader
    {

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f_img vert(appdata_base data)
            {
                v2f_img v2f_img;
                v2f_img.pos = UnityObjectToClipPos(data.vertex);

                v2f_img.uv = data.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;

                return v2f_img;
            }


            fixed4 frag(v2f_img i):SV_Target
            {
                return tex2D(_MainTex,i.uv);
            }

            ENDCG
        }
    }
}
