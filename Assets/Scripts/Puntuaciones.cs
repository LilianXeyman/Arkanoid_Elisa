using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntuaciones : MonoBehaviour
{
    public static Puntuaciones instance;

    // Poner puntuaciones a medida que la pelota rebota en los bloques
    [SerializeField]
    Bloques bloques;

    [SerializeField]
    BotonesMenu botonesMenu;

    [SerializeField]
    VidasYPuntos vidasYPuntos;

    [SerializeField]
    MaxPuntuacion maxPuntuacion;
    //public int puntosBloques;
    [SerializeField]
    public int puntuacion;
    [SerializeField]
    TextMeshProUGUI puntuacionEnPantalla;

    [SerializeField]
    TextMeshProUGUI puntuacionEnPantallaMuerte;
    [SerializeField]
    TextMeshProUGUI puntuacionEnPantallaVictoria;

    private int blocksLeft;

    public int puntos;

    [SerializeField]
    public GameObject canvasVictoria;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        canvasVictoria.SetActive(false);
        //blocksLeft = GameObject.FindGameObjectsWithTag("Bloques").Length;
        //Debug.Log(blocksLeft);
    }
    void Update()
    {
        //Ir añadiendo los PowerUps que dan puntos
        puntuacionEnPantalla.text = puntos.ToString("000000000");
        puntuacionEnPantallaMuerte.text = puntos.ToString();
        puntuacionEnPantallaVictoria.text = puntos.ToString();
    }
    public void BlockDestroyed()
    {
        //blocksLeft--;
        Debug.Log(PosicionesYCreacionBloques.instance.bloques.childCount);
        if (PosicionesYCreacionBloques.instance.bloques.childCount <= 1)
        { 
           botonesMenu.tiempo = false;
           canvasVictoria.SetActive(true);
            vidasYPuntos.BolaPausa();
           PosicionesYCreacionBloques.instance.GenerarNiveles();
        }
    }
}
