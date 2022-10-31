Shader "Custom/WipeCircle"
{
    Properties{
  		_Radius("Radius", Range(0,2))=2
          _MainTex("MainTex", 2D) = "white"{}
  	}
    SubShader {
        Pass {
            CGPROGRAM
 
            #include "UnityCG.cginc"
 
            #pragma vertex vert_img
            #pragma fragment frag
 
            sampler2D _MainTex;
            float _Radius;
            fixed4 frag(v2f_img i) : COLOR
            {
                fixed2 wipezone = i.uv - fixed2(0.5, 0.4);
                wipezone.x *= 16.0/9.0;
                if( distance(wipezone, fixed2(0,0)) < _Radius ){
                    fixed4 c = tex2D(_MainTex, i.uv);
                    return c;
                }
                return fixed4(0.0,0.0,0.0,1.0);
            }
            ENDCG
        }
    }
}
