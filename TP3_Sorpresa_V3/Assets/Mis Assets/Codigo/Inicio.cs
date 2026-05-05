using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inicio : MonoBehaviour
{
    public List<ContenedorDeColores> predefinido;
    public string referencia;
    public GameObject panel, ui;

    public static int nivel;
    public static bool menu = true;

    private void Awake()
    {
        CargarColores();
    }

    void Start()
    {
        panel.SetActive(menu);
        ui.SetActive(menu);
    }

    void Update()
    {
        
    }

    void CargarColores()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            MeshRenderer render = transform.GetChild(i).GetChild(0).GetComponent<MeshRenderer>();

            if (nivel >= 0)
                render.material.SetColor(referencia, predefinido[nivel].colores[i]);
            else
                render.material.SetColor(referencia, GenerarColorMultiplo25());
        }
    }

    Color GenerarColorMultiplo25()
    {
        int r = Random.Range(0, 11) * 25;
        int g = Random.Range(0, 11) * 25;
        int b = Random.Range(0, 11) * 25;

        return new Color32(((byte)r), ((byte)g), ((byte)b), 255);
    }

    public void SetearNivel(int n)
    {
        nivel = n;
        menu = false;
        SceneManager.LoadScene(0);
    }
}

[System.Serializable]
public class ContenedorDeColores
{
    public Color32[] colores;
}