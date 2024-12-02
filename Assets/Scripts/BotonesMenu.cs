using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class BotonesMenu : MonoBehaviour
{
    [SerializeField]
    VidasYPuntos vidasYPuntos;
    //Crear botones Continuar, Nuevo Juego, Opciones, Salir
    //A continuación se pondrán las variables que dependan del control del juego por el menú
    /*[SerializeField]
    GameObject canvasInicio;*/
    [SerializeField]
    GameObject canvasMenu;
    [SerializeField]
    GameObject canvasMenuMenu;
    [SerializeField]
    GameObject canvasOpciones;
    [SerializeField]
    GameObject canvasJuego;
    [SerializeField]
    GameObject botonNuevoJuego;
    [SerializeField]
    GameObject botonContinuar;
    [SerializeField]
    GameObject botonOpciones;
    [SerializeField]
    GameObject botonSalir;
    [SerializeField]
    LeanTweenType animCurve;
    [SerializeField]
    float tiempoAnimacion;
    [SerializeField]
    float posicionY1;
    [SerializeField]
    float posicionY2;
    [SerializeField]
    float posicionY3;
    [SerializeField]
    float posicionY4;
    [SerializeField]
    float posicionX=1179f;
    [SerializeField]
    float posicionX1;
    [SerializeField]
    float posicionOpciones;
    [SerializeField]
    GameObject tituloJuego;
    [SerializeField]
    GameObject pulsaEnter;
    //Variables para contar el tiempo
    float tiempoTotal=0;
    float minutos = 0;
    float segundos = 0;
    float milisegundos=0;
    [SerializeField]
    TextMeshProUGUI tiempoEnPartida;
    [SerializeField]
    TextMeshProUGUI tiempoEnPartidaFinal;
    [SerializeField]
    TextMeshProUGUI tiempoEnPartidaFinalVictoria;

    //Aquí se escribirán los booleanos del juego
    public bool comienzaElJuego;
    public bool tiempo;
    public bool estaJugando;
    
    void Start()
    {
        //canvasInicio.SetActive(true);
        canvasMenu.SetActive(true);
        canvasJuego.SetActive(false);
        botonContinuar.SetActive(false);
        canvasOpciones.SetActive(false);
        //Pantalla inicio
        botonNuevoJuego.SetActive(false);
        botonOpciones.SetActive(false);
        botonSalir.SetActive(false);
        canvasMenuMenu.SetActive(false);
        //Boleanos
        comienzaElJuego = true;
        tiempo = false;
        estaJugando = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (estaJugando == true)
        {
            //Intente ponerle animaciones a esto pero queda raro
            //LeanTween.scale(pulsaEnter, Vector3.one * 1.2f, 2f);
            //LeanTween.scale(pulsaEnter, Vector3.one * 1.2f, 0.5f).setLoopPingPong(); <= Con un RectTransform
            if (Input.GetButtonDown("Submit"))//Darle al Enter
            {
                /*LeanTween.moveLocalY(canvasInicio, 1080, 1.1f);
                canvasMenu.SetActive(true);
                LeanTween.moveLocalY(canvasMenu, -900, 0f);
                LeanTween.moveLocalY(canvasMenu, 0, 1f).setOnComplete(() =>
                {
                    canvasInicio.SetActive(false);
                });*/
                pulsaEnter.SetActive(false);
                botonNuevoJuego.SetActive(true);
                botonOpciones.SetActive(true);
                botonSalir.SetActive(true);
                canvasMenuMenu.SetActive(true);
                LeanTween.moveLocalY(botonNuevoJuego, -1000, 0);
                LeanTween.moveLocalY(botonOpciones, -1000, 0);
                LeanTween.moveLocalY(botonSalir, -1000, 0);
                LeanTween.moveLocalY(canvasMenuMenu, -1000, 0);
                LeanTween.moveY(tituloJuego, 540, 0.25f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() =>
                {
                    LeanTween.moveLocalY(canvasMenuMenu, -237, tiempoAnimacion).setOnComplete(() =>
                    {
                        LeanTween.moveLocalY(botonNuevoJuego, 37, tiempoAnimacion).setEase(animCurve).setOnComplete(() => {
                            LeanTween.moveLocalY(botonOpciones, -105, tiempoAnimacion).setEase(animCurve).setOnComplete(() => {
                                LeanTween.moveLocalY(botonSalir, -275, tiempoAnimacion).setEase(animCurve);
                            });
                        });
                    });
                    
                });
                estaJugando = false;
            }
        }
            if (Input.GetButtonDown("Cancel"))//Darle al Escape
            {
                Debug.Log("escape");
                if (canvasMenu.activeSelf)
                {
                HidePopUp();
                }
                else
                {
                ShowPopUp();
                }
            }
            //Para contar el tiempo de la partida
            if (comienzaElJuego == false)
            {
                if (tiempo == true)
                {
                    tiempoTotal = tiempoTotal + Time.deltaTime;
                    minutos = Mathf.Floor((tiempoTotal % 3600) / 60);
                    segundos = Mathf.Floor(tiempoTotal % 60);
                    milisegundos = Mathf.Floor(tiempoTotal * 60) % 60;
                    tiempoEnPartida.text = minutos.ToString("00") + " : " + segundos.ToString("00") + " : " + milisegundos.ToString("00");
                    tiempoEnPartidaFinal.text = minutos.ToString("00") + " : " + segundos.ToString("00") + " : " + milisegundos.ToString("00");
                    tiempoEnPartidaFinalVictoria.text = minutos.ToString("00") + " : " + segundos.ToString("00") + " : " + milisegundos.ToString("00");
            }
            }
    }
    public void ShowPopUp()
    {
        tiempo = false;
        botonContinuar.SetActive (true);
        canvasMenu.SetActive (true);
        canvasJuego.SetActive(false);
        canvasOpciones.SetActive (false); 
        tituloJuego.SetActive (false);
        //Animaciones de los botones
        LeanTween.moveY(canvasMenuMenu, 285, 0);//Corregir posicion en clase
        LeanTween.moveLocalY(botonContinuar, -900f, 0);
        LeanTween.moveLocalY(botonNuevoJuego, -900, 0);
        LeanTween.moveLocalY(botonOpciones, -900, 0);
        LeanTween.moveLocalY(botonSalir, -900, 0);
        LeanTween.moveLocalY(botonContinuar, posicionY1, tiempoAnimacion).setEase(animCurve).setOnComplete(()=>
        {
            LeanTween.moveLocalY(botonNuevoJuego, posicionY2, tiempoAnimacion).setEase(animCurve).setOnComplete( ()=> {
                LeanTween.moveLocalY(botonOpciones, posicionY3, tiempoAnimacion).setEase(animCurve).setOnComplete(()=> {
                    LeanTween.moveLocalY(botonSalir, posicionY4, tiempoAnimacion).setEase(animCurve);
                });
            });
        });
        //Animaciones de los botones de Opciones
        LeanTween.moveX(canvasMenuMenu, 205, 0).setEase(animCurve).setOnComplete(() =>
        {
            LeanTween.moveX(botonContinuar, 538, 0).setEase(animCurve).setOnComplete(() =>
            {
                LeanTween.moveX(botonNuevoJuego, 538, 0).setEase(animCurve).setOnComplete(() => {
                    LeanTween.moveX(botonOpciones, 538, 0).setEase(animCurve).setOnComplete(() => {
                        LeanTween.moveX(botonSalir, 538, 0).setEase(animCurve).setOnComplete(() =>
                        {
                            //Time.timeScale = 0f;
                        });
                    });
                });
            });
        });
    }
    public void HidePopUp()
    {
        tiempo = true;
        canvasMenu.SetActive(false);
        canvasJuego.SetActive(true);
        //Time.timeScale = 1f;
    }
    public void Reestablecer()
    {
        canvasMenu.SetActive(false);
        canvasJuego.SetActive(true);
        vidasYPuntos.canvasMuerte.SetActive(false);
        Puntuaciones.instance.canvasVictoria.SetActive(false);
        tiempo = true;
        tiempoTotal = 0;
        vidasYPuntos.cuentaVidas = 3;
        vidasYPuntos.imagen1Vidas.enabled = true;
        vidasYPuntos.imagen2Vidas.enabled = true;
        vidasYPuntos.imagen3Vidas.enabled = true;
        vidasYPuntos.ReiniciarBola();
        vidasYPuntos.pelotaEnJuego = false;
        Puntuaciones.instance.puntos = 0;
    }
    //Botones
    public void Continuar()
    {
        tiempo = true;
        canvasMenu.SetActive(false);
        canvasJuego.SetActive(true);
    }
    public void NuevoJuego()
    { 
        comienzaElJuego=false;
        Reestablecer();
    }
    public void Opciones()
    {
        //Botones menu
        LeanTween.moveX(canvasMenuMenu, posicionX1, tiempoAnimacion).setEase(animCurve).setOnComplete(() =>
        {
            LeanTween.moveX(botonContinuar, posicionX, tiempoAnimacion).setEase(animCurve).setOnComplete(() =>
            {   
                LeanTween.moveX(botonNuevoJuego, posicionX, tiempoAnimacion).setEase(animCurve).setOnComplete(() => {
                    LeanTween.moveX(botonOpciones, posicionX, tiempoAnimacion).setEase(animCurve).setOnComplete(() => {
                        LeanTween.moveX(botonSalir, posicionX, tiempoAnimacion).setEase(animCurve);
                    });
                });
            });
        });
        //Botones Opciones
        canvasOpciones.SetActive(true);
        LeanTween.moveLocalX(canvasOpciones, -900f, 0);
        LeanTween.moveLocalX(canvasOpciones, posicionOpciones, tiempoAnimacion).setEase(animCurve);
    }
    public void Salir()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
