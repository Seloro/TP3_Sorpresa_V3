using UnityEngine;

public class Control_Cubos : MonoBehaviour
{
    public Camera camara;
    public LayerMask capa;
    public float velocidad;

    bool arrastrando;
    Vector3 posicionObjetivo;
    Renderer rend;
    Color32 colorInicial;

    private void Start()
    {
        rend = GetComponent<Renderer>();

        colorInicial = GenerarColorMultiplo25();
        rend.material.SetColor("_Color_Base", colorInicial);
    }

    void Update()
    {
        Movimiento();
    }

    public void Movimiento()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayo = camara.ScreenPointToRay(Input.mousePosition);
            RaycastHit impacto;
            if (Physics.Raycast(rayo, out impacto, Mathf.Infinity, ~capa))
                if (impacto.collider.gameObject == gameObject)
                    arrastrando = true;
        }

        if (Input.GetMouseButtonUp(0) && arrastrando)
        {
            arrastrando = false;

            Ray rayo = camara.ScreenPointToRay(Input.mousePosition);
            RaycastHit impacto;
            if (Physics.Raycast(rayo, out impacto, Mathf.Infinity, capa))
                if (PrimerHijoSinNietos(impacto.transform) != null)
                    gameObject.transform.SetParent(PrimerHijoSinNietos(impacto.transform));
        }


        if (arrastrando && Input.GetMouseButton(0))
        {
            Ray rayo = camara.ScreenPointToRay(Input.mousePosition);
            Plane planoXZ = new Plane(Vector3.up, Vector3.zero);
            float distancia;
            if (planoXZ.Raycast(rayo, out distancia))
            {
                Vector3 punto = rayo.GetPoint(distancia);
                posicionObjetivo = new Vector3(punto.x, 5.5f, punto.z);
                transform.position = Vector3.Lerp(transform.position, posicionObjetivo, Time.deltaTime * velocidad);
            }
        }
        else
            transform.position = Vector3.MoveTowards(transform.position, transform.parent.position, Time.deltaTime * velocidad * 2);
    }

    Color GenerarColorMultiplo25()
    {
        int r = Random.Range(0, 11) * 25;
        int g = Random.Range(0, 11) * 25;
        int b = Random.Range(0, 11) * 25;

        return new Color32 (((byte)r), ((byte)g), ((byte)b), 255);
    }

    public Transform PrimerHijoSinNietos(Transform objeto)
    {
        if (objeto.childCount > 0)
        {
            foreach (Transform hijo in objeto)
            {
                if (hijo.childCount == 0)
                {
                    return hijo;
                }
            }
        }

        return null;
    }

}
