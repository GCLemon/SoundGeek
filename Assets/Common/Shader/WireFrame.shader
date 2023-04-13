Shader "Custom/WireFrame"
{
    Properties
    {
        _LineColor ("LineColor", Color) = (1,1,1,1)
        _FillColor ("FillColor", Color) = (1,1,1,1)
        _LineWidth ("LineWidth", float) = 1
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

        // 背面のレンダリング
        Pass
        {
            Cull Front

            CGPROGRAM
            
            // シェーダに使用する関数名を登録
            #include "UnityCG.cginc"
            #pragma vertex vert
            #pragma fragment frag

            // 頂点シェーダ -> ピクセルシェーダ
            struct v2f
            {
                float4 vertex : SV_POSITION;
            };

            // 変数を定義
            float _LineWidth;
            fixed4 _LineColor;

            // 頂点シェーダ
            v2f vert(appdata_full input)
            {
                v2f output;
                output.vertex = UnityObjectToClipPos(input.vertex + input.color * _LineWidth);
                return output;
            }

            // ピクセルシェーダ
            fixed4 frag(v2f input) : SV_TARGET
            {
                return _LineColor;
            }

            ENDCG
        }
        
        // 前面のレンダリング
        Pass
        {
            Cull Back

            CGPROGRAM
            
            // シェーダに使用する関数名を登録
            #include "UnityCG.cginc"
            #pragma vertex vert
            #pragma fragment frag

            // 頂点シェーダ -> ピクセルシェーダ
            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 texcoord : TEXCOORD0;
            };

            // 変数を定義
            fixed4 _FillColor;

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
                return _FillColor;
            }

            ENDCG
        }
    }
    FallBack "Diffuse"
}
