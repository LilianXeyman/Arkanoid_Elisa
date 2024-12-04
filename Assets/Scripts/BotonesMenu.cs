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

    [SerializeField]
    MaxPuntuacion maxPuntuacion;
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
    public bool recordsPoner;

    //Para controlar el apartado de Records
    [SerializeField]
    GameObject records;

    //Cuentas para el modo niveles infinitos
    public int cuentaNivelesInfinitos = 1;

    [SerializeField]
    GameObject numeroNivel;

    [SerializeField]
    TextMeshProUGUI cambiarNumNivel;
    
    void Start()
    {
        //Pantalla en juego
        LeanTween.scale(numeroNivel, Vector3.zero, 0);
        //canvasInicio.SetActive(true);
        canvasMenu.SetActive(true);
        canvasJuego.SetActive(false);
        botonContinuar.SetActive(false);
        canvasOpciones.SetActive(false);
        records.SetActive(false);
        //Pantalla inicio
        botonNuevoJuego.SetActive(false);
        botonOpciones.SetActive(false);
        botonSalir.SetActive(false);
        canvasMenuMenu.SetActive(false);
        //Boleanos
        comienzaElJuego = true;
        tiempo = false;
        estaJugando = true;
        recordsPoner = false;
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
                LeanTween.moveY(tituloJuego, 750, 0.25f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() =>//750
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
        vidasYPuntos.BolaPausa();
        tiempo = false;
        botonContinuar.SetActive (true);
        canvasMenu.SetActive (true);
        canvasJuego.SetActive(false);
        canvasOpciones.SetActive (false); 
        tituloJuego.SetActive (false);
        canvasMenuMenu.SetActive (true);
        //Animaciones de los botones
        LeanTween.moveY(canvasMenuMenu, 400, 0);//Corregir posicion en clase
        LeanTween.moveY(botonContinuar, -900f, 0);
        LeanTween.moveY(botonNuevoJuego, -900, 0);
        LeanTween.moveY(botonOpciones, -900, 0);
        LeanTween.moveY(botonSalir, -900, 0);
        LeanTween.moveY(botonContinuar, posicionY1, tiempoAnimacion).setEase(animCurve).setOnComplete(()=>
        {
            LeanTween.moveY(botonNuevoJuego, posicionY2, tiempoAnimacion).setEase(animCurve).setOnComplete( ()=> {
                LeanTween.moveY(botonOpciones, posicionY3, tiempoAnimacion).setEase(animCurve).setOnComplete(()=> {
                    LeanTween.moveY(botonSalir, posicionY4, tiempoAnimacion).setEase(animCurve);
                });
            });
        });
        //Animaciones de los botones de Opciones
        /*LeanTween.moveX(canvasMenuMenu, 205, 0).setEase(animCurve).setOnComplete(() =>
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
        });*/
    }
    public void HidePopUp()
    {
        vidasYPuntos.BolaReanudar();
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
        //Poner todas las pos en apagado
    }
    //Botones
    public void Continuar()
    {
        tiempo = true;
        vidasYPuntos.BolaReanudar();
        canvasMenu.SetActive(false);
        canvasJuego.SetActive(true);
    }
    public void NivelesInfinitos()
    {
        cuentaNivelesInfinitos = cuentaNivelesInfinitos + 1;
        cambiarNumNivel.text="Nivel "+cuentaNivelesInfinitos.ToString();
        comienzaElJuego = false;
        recordsPoner = true;
        canvasMenu.SetActive(false);
        canvasJuego.SetActive(true);
        LeanTween.scale(numeroNivel, Vector3.one, 1.5f).setEase(animCurve).setOnComplete(() => {
            LeanTween.scale(numeroNivel, Vector3.zero, 0.5f);
        });
        vidasYPuntos.canvasMuerte.SetActive(false);
        Puntuaciones.instance.canvasVictoria.SetActive(false);
        tiempo = true;
        vidasYPuntos.ReiniciarBola();
        vidasYPuntos.pelotaEnJuego = false;
        PosicionesYCreacionBloques.instance.GenerarNiveles();
    }
    public void NuevoJuego()
    { 
        comienzaElJuego=false;
        recordsPoner = true;
        Reestablecer();
        PosicionesYCreacionBloques.instance.GenerarNiveles();
        maxPuntuacion.puntuacionActual=0;
    }
    public void Opciones()
    {
        //Botones menu
        canvasMenuMenu.SetActive(false);
        botonContinuar.SetActive(false);
        botonOpciones.SetActive(false);
        botonNuevoJuego.SetActive(false);
        botonSalir.SetActive(false);
        /*LeanTween.moveX(canvasMenuMenu, posicionX1, tiempoAnimacion).setEase(animCurve).setOnComplete(() =>
        {
            LeanTween.moveX(botonContinuar, posicionX, tiempoAnimacion).setEase(animCurve).setOnComplete(() =>
            {   
                LeanTween.moveX(botonNuevoJuego, posicionX, tiempoAnimacion).setEase(animCurve).setOnComplete(() => {
                    LeanTween.moveX(botonOpciones, posicionX, tiempoAnimacion).setEase(animCurve).setOnComplete(() => {
                        LeanTween.moveX(botonSalir, posicionX, tiempoAnimacion).setEase(animCurve);
                    });
                });
            });
        });*/
        //Botones Opciones
        canvasOpciones.SetActive(true);
        //LeanTween.moveLocalX(canvasOpciones, -900f, 0);
        //LeanTween.moveLocalX(canvasOpciones, posicionOpciones, tiempoAnimacion).setEase(animCurve);
    }
    public void CerrarOpciones()
    {
        canvasMenuMenu.SetActive(true);
        botonOpciones.SetActive(true);
        botonNuevoJuego.SetActive(true);
        botonSalir.SetActive(true);
        records.SetActive(false);
        canvasOpciones.SetActive(false);
        tituloJuego.SetActive(false);
        if (recordsPoner == true)
        {
            botonContinuar.SetActive(true);
        }
        else
        {
            botonContinuar.SetActive(false);
        }
        LeanTween.moveY(canvasMenuMenu, 400, 0);//Corregir posicion en clase
        LeanTween.moveY(botonContinuar, -900f, 0);
        LeanTween.moveY(botonNuevoJuego, -900, 0);
        LeanTween.moveY(botonOpciones, -900, 0);
        LeanTween.moveY(botonSalir, -900, 0);
        LeanTween.moveY(botonContinuar, posicionY1, tiempoAnimacion).setEase(animCurve).setOnComplete(() =>
        {
            LeanTween.moveY(botonNuevoJuego, posicionY2, tiempoAnimacion).setEase(animCurve).setOnComplete(() => {
                LeanTween.moveY(botonOpciones, posicionY3, tiempoAnimacion).setEase(animCurve).setOnComplete(() => {
                    LeanTween.moveY(botonSalir, posicionY4, tiempoAnimacion).setEase(animCurve);
                });
            });
        });
    }
    public void Salir()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
    public void Records()
    {
        Debug.Log("Entra?");
        records.SetActive(true);
        canvasOpciones.SetActive(false);
        botonNuevoJuego.SetActive(false);
        botonOpciones.SetActive(false);
        botonSalir.SetActive(false);
        canvasMenuMenu.SetActive(false);
        if (recordsPoner == true)
        {
            LeanTween.moveLocalY(records,100, 0f);
            botonContinuar.SetActive(false);
        }
        else
        {
            botonContinuar.SetActive(false);
        }
    }
    public void Volver()
    {
        records.SetActive(false);
        canvasOpciones.SetActive(true);
    }
}
