using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class BotonesMenu : MonoBehaviour
{
    //Crear botones Continuar, Nuevo Juego, Opciones, Salir
    //A continuación se pondrán las variables que dependan del control del juego por el menú
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
    //Variables para contar el tiempo
    float tiempoTotal=0;
    float minutos = 0;
    float segundos = 0;
    float milisegundos=0;
    [SerializeField]
    TextMeshProUGUI tiempoEnPartida;

    //Aquí se escribirán los booleanos del juego
    public bool comienzaElJuego;
    public bool tiempo;
    public bool estaJugando;
    
    void Start()
    {
        canvasMenu.SetActive(true);
        canvasJuego.SetActive(false);
        botonContinuar.SetActive(false);
        canvasOpciones.SetActive(false);
        comienzaElJuego = true;
        tiempo = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
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
                segundos= Mathf.Floor(tiempoTotal % 60);
                milisegundos = Mathf.Floor(tiempoTotal * 60) % 60;
                tiempoEnPartida.text = minutos.ToString("00") +" : "+ segundos.ToString("00") +" : "+ milisegundos.ToString("00");
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
        //Animaciones de los botones
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
            LeanTween.moveX(botonContinuar, 548, 0).setEase(animCurve).setOnComplete(() =>
            {
                LeanTween.moveX(botonNuevoJuego, 548, 0).setEase(animCurve).setOnComplete(() => {
                    LeanTween.moveX(botonOpciones, 548, 0).setEase(animCurve).setOnComplete(() => {
                        LeanTween.moveX(botonSalir, 548, 0).setEase(animCurve);
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
    }
    public void Reestablecer()
    {
        canvasMenu.SetActive(false);
        canvasJuego.SetActive(true);
        tiempo = true;
        tiempoTotal = 0;
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
