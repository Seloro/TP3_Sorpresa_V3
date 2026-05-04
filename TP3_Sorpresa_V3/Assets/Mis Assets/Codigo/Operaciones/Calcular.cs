using UnityEngine;

public class Calcular : MonoBehaviour
{
    public string referencia;

    internal Color32[] valores = new Color32[4];
    MeshRenderer rend;

    void Start()
    {
        rend = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        CargarColores();
        if (ComprobarNietos())
            rend.material.SetColor(referencia, Calculo());
        else
            rend.material.SetColor(referencia, Color.white);
    }

    void CargarColores()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).childCount > 0)
            {
                MeshRenderer render = transform.GetChild(i).GetChild(0).GetComponent<MeshRenderer>();

                valores[i] = render.material.GetColor(referencia);
            }
            else
                valores[i] = Color.black;
        }
    }

    bool ComprobarNietos()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).childCount > 0)
            {
                return true;
            }
        }

        return false;
    }

    public virtual Color32 Calculo()
    {
        return Color.white;
    }
}
