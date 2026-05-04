using UnityEngine;

public class Sumar : Calcular
{
    public override Color32 Calculo()
    {
        float r = new float();
        float g = new float();
        float b = new float();

        Color32 col = new Color();

        for (int i = 0; i < valores.Length; i++)
        {
            r += valores[i].r;
            g += valores[i].g;
            b += valores[i].b;
        }

        if (r > 255)
            col.r = 255;
        else
            col.r = ((byte)r);

        if (g > 255) 
            col.g = 255;
        else
            col.g = ((byte)g);

        if (b > 255) 
            col.b = 255; 
        else
            col.b = ((byte)b);

        col.a = 255;

        return col;
    }
}
