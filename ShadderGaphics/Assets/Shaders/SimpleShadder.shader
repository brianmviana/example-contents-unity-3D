
Shader "Shadders/SimpleShadder" {
    Properties{
        _MainTex ("Texture", 2D) = "white" {}
    }

    SubShader {
        Tags {
            "Queue" = "Transparent"
        }

        Pass {
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM

            #include "UnityCG.cginc"

            #pragma vertex vert
            #pragma fragment frag

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;

            v2f vert (appdata i){
                v2f o;
                o.vertex = UnityObjectToClipPos(i.vertex);
                o.uv = i.uv;
                return o;
            }

            float4 frag (v2f i) : SV_TARGET {
                //return float4(i.uv.x, i.uv.y, 0, 1);
                float4 color = tex2D(_MainTex, i.uv);

                // Desafio 1
                // color.g = 0;

                // Desafio 2
                // float c = (color.r, color.g, color.b) / 3;
                // color.rgb = float3(c, c, c);

                // Desafio 3
                // float3 mapUV = float3(i.uv.x, i.uv.y, 0);
                // float c = (color.r, color.g, color.b) / 3;
                // color.rgb = float3(c, c, c) * mapUV;

                // Desafio 4
                // color = tex2D(_MainTex, i.uv * 2);

                // Desafio 5
                    // Animated material
                    //float s = (i.uv.y * 150) + _Time.y;
                    // i.uv.x += sin(s) * 0.01;
                // i.uv.x += sin(i.uv.y * 150) * 0.01;
                // color = tex2D(_MainTex, i.uv * 2);

                // Desafio 6
                // color.rgb = (1 - color.rgb);

                return color;
            }

            ENDCG
        }
    }
}
