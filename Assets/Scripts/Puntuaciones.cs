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
    //public int puntosBloques;
    [SerializeField]
    public int puntuacion;
    [SerializeField]
    TextMeshProUGUI puntuacionEnPantalla;

    [SerializeField]
    TextMeshProUGUI puntuacionEnPantallaMuerte;
    [SerializeField]
    TextMeshProUGUI puntuacionEnPantallaVictoria;

    public float puntos;

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
        
    }
    void Update()
    {
        //Ir añadiendo los PowerUps que dan puntos
        puntuacionEnPantalla.text = puntos.ToString("000000000");
        puntuacionEnPantallaMuerte.text = puntos.ToString();
        puntuacionEnPantallaVictoria.text = puntos.ToString();
    }
}
