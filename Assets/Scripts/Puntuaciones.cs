using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntuaciones : MonoBehaviour
{
    public static Puntuaciones instance;

    // Poner puntuaciones a medida que la pelota rebota en los bloques
    [SerializeField]
    Puntuaciones puntuaciones;
    public int puntosBloques;
    [SerializeField]
    public int puntuacion;
    [SerializeField]
    TextMeshProUGUI puntuacionEnPantalla;

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

    // Update is called once per frame
    void Update()
    {
        puntuacion = puntuacion + puntosBloques;//Ir añadiendo los PowerUps que dan puntos
        puntuacionEnPantalla.text = puntuacion.ToString("000000000");
    }
}
