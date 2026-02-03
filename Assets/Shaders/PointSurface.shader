Shader "Graph/Point Surface" {

    Properties {
        _Smoothness ("Smoothness", Range(0, 1)) = 0.5
    }

    SubShader {
        CGPROGRAM
            #pragma surface ConfigureSurface Standard fullforwardshadows
            #pragma target 3.0

            struct Input {
                float3 worldPos;
            };
            
            float _Smoothness;
            void ConfigureSurface (Input input, inout SurfaceOutputStandard surface) {
                surface.Albedo = saturate(input.worldPos * 0.5 + 0.5);
                surface.Smoothness = _Smoothness;
            }
        ENDCG
    }

    FallBack "Diffuse"
    // HLSL (High-Level Shading Language) and Cg (C for Graphics) are high-level, C-style programming languages used to write shaders, which are specialized programs that run on GPUs to control lighting, vertex manipulation, and pixel color in real-time graphics. While Cg was developed by NVIDIA and HLSL by Microsoft, they are largely identical in syntax and function, often used interchangeably to create shaders for DirectX, OpenGL, and game engines like Unity. 

}