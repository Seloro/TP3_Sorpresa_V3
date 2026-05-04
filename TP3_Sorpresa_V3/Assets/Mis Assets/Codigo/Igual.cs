using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Igual : MonoBehaviour
{
    public string referencia;
    public MeshRenderer suma, resta, multiplicasion;

    MeshRenderer igual;


    private void Start()
    {
        igual = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        CambiarColor();
        CambiarColorDeNieto();
    }

    void CambiarColor()
    {
        if (ComprobarNietos(suma.gameObject) || ComprobarNietos(resta.gameObject) || ComprobarNietos(multiplicasion.gameObject))
            igual.material.SetColor(referencia, Resultado());
        else
            igual.material.SetColor(referencia, Color.white);
    }

    Color32 Resultado()
    {
        Color32 sumaColor = new Color32();
        Color32 restaColor = new Color32(); 
        Color32 productoColor = new Color32();

        if (ComprobarNietos(suma.gameObject))
            sumaColor = suma.material.GetColor(referencia);
        if (ComprobarNietos(resta.gameObject))
            restaColor = resta.material.GetColor(referencia);
        if (ComprobarNietos(multiplicasion.gameObject))
            productoColor = multiplicasion.material.GetColor(referencia);

        return new Color32(((byte)(sumaColor.r - restaColor.r + productoColor.r)), ((byte)(sumaColor.g - restaColor.g + productoColor.g)), ((byte)(sumaColor.b - restaColor.b + productoColor.b)), 255);
    }

    bool ComprobarNietos(GameObject padre)
    {
        for (int i = 0; i < padre.transform.childCount; i++)
        {
            if (padre.transform.GetChild(i).childCount > 0)
            {
                return true;
            }
        }

        return false;
    }

    void CambiarColorDeNieto()
    {
        if (transform.GetChild(0).childCount > 0)
        {
            MeshRenderer rend = transform.GetChild(0).GetChild(0).gameObject.GetComponent<MeshRenderer>();

            rend.material.SetColor(referencia, igual.material.GetColor(referencia));
        }
    }
}
