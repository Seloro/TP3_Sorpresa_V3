using UnityEngine;

public class Multiplicasion : Calcular
{
    public override Color32 Calculo()
    {
        float r = new float();
        float g = new float();
        float b = new float();

        Color32 col = new Color();

        for (int i = 0; i < valores.Length; i++)
        {
            r += valores[i].g + valores[i].b;
            g += valores[i].r + valores[i].b;
            b += valores[i].r + valores[i].g;
        }

        if (r > 250)
            col.r = 250;
        else
            col.r = ((byte)r);

        if (g > 250)
            col.g = 250;
        else
            col.g = ((byte)g);

        if (b > 250)
            col.b = 250;
        else
            col.b = ((byte)b);

        col.a = 255;

        return col;
    }
}
