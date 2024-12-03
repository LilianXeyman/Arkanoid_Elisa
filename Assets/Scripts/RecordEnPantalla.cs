using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecordEnPantalla : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUGUI;

    // Para poder cambiar el texto del record
    void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        //textMeshProUGUI.text = PlayerPrefs.GetInt("Record").ToString();
        MaxPuntuacion.Instance.añadirPuntosEvent += CambiarTexto;
    }
    public void CambiarTexto(object sender, MaxPuntuacion.AñadirPuntosEventArgs e)
    {
        textMeshProUGUI.text = e.recordEvent.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
