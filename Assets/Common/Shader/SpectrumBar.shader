Shader "Custom/SpectrumBar"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
    }
    
    SubShader
    {
        // タグの設定
        Tags
        {
            "RenderType" = "Transparent"
            "Queue" = "Transparent"
        }
        LOD 200

        // 前面のレンダリング
        Pass
        {
            CGPROGRAM
            
            // シェーダに使用する関数名を登録
            #include "UnityCG.cginc"
            #pragma vertex vert
            #pragma fragment frag

            // 頂点シェーダ -> ジオメトリシェーダ
            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 texcoord : TEXCOORD0;
            };

            // 変数を定義
            fixed4 _Color;

            // 頂点シェーダ
            v2f vert(appdata_base input)
            {
                v2f output;
                output.vertex = UnityObjectToClipPos(input.vertex);
                output.texcoord = input.texcoord;
                return output;
            }

            // ピクセルシェーダ
            fixed4 frag(v2f input) : SV_TARGET
            {
                return _Color;
            }

            ENDCG
        }
    }
    FallBack "Diffuse"
}
