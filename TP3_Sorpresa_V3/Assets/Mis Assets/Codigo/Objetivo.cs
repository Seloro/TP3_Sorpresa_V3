using UnityEngine;
using UnityEngine.SceneManagement;

public class Objetivo : MonoBehaviour
{
    public string referencia;
    public Color32[] objetivos;

    MeshRenderer rend;
    void Start()
    {
        rend = GetComponent<MeshRenderer>();

        if (Inicio.nivel >= 0)
            rend.material.SetColor(referencia, objetivos[Inicio.nivel]);
        else
            rend.material.SetColor(referencia, GenerarColorMultiplo25());
    }

    void Update()
    {
        Comprobacion();
    }

    Color GenerarColorMultiplo25()
    {
        int r = Random.Range(0, 11) * 25;
        int g = Random.Range(0, 11) * 25;
        int b = Random.Range(0, 11) * 25;

        return new Color32(((byte)r), ((byte)g), ((byte)b), 255);
    }

    void Comprobacion()
    {
        if (transform.GetChild(0).childCount > 0)
        {
            if (transform.GetChild(0).transform.position == transform.GetChild(0).GetChild(0).transform.position)
            {
                MeshRenderer nietoRend = transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>();

                if (nietoRend.material.GetColor(referencia) == rend.material.GetColor(referencia))
                {
                    Inicio.menu = true;

                    SceneManager.LoadScene(0);
                }
                    
            }
        }
    }
}
