Shader "Masked/Mask"{
    
    SubShader{
        
        Tags{"Queue" = "Geometry+10"}
        
        ColorMask 0
        Zwrite on 
        
        pass{}
    
    }

}