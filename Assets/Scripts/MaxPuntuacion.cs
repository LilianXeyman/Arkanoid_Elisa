using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MaxPuntuacion : MonoBehaviour
{
    public static MaxPuntuacion Instance;

    [SerializeField]
    private TextMeshProUGUI textoRecord;

    [SerializeField]
    private TextMeshProUGUI textoRecordEnPantalla;

    public int puntuacionActual = 0;
    public int record = 0;

    //Eventos: sirve para mantener actualizado la puntuacion maxima
    public event EventHandler<AñadirPuntosEventArgs> añadirPuntosEvent;
    public class AñadirPuntosEventArgs : EventArgs 
    {
        public int puntuacionActualEvent;
        public int recordEvent;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        record = PlayerPrefs.GetInt("Record",0);
        ActualizarTextoRecord();
    }
    public void AñadirPuntos(int puntos)
    { 
       puntuacionActual = Puntuaciones.instance.puntos;
        if (puntuacionActual > record)
        {
            record = puntuacionActual;
            PlayerPrefs.SetInt("Record", record);
            PlayerPrefs.Save();//Te guarda siempre la puntuacion
            Debug.Log("¡Nuevo Record guardado: " + record);
        }
        añadirPuntosEvent?.Invoke(this, new AñadirPuntosEventArgs { puntuacionActualEvent = puntuacionActual, recordEvent = record });
    }
    private void ActualizarTextoRecord()
    {
        textoRecord.text = record.ToString();
        textoRecordEnPantalla.text = record.ToString();
    }
}
