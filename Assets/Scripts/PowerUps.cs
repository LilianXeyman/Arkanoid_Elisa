using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public static PowerUps Instance;

    [SerializeField]
    VidasYPuntos vidasYPuntos;

    [SerializeField]
    GameObject quinientos;

    [SerializeField]
    float duracion=0;

    [SerializeField]
    float duracionInvertirControles = 0;
    // Start is called before the first frame update
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
    void Start()
    {
        LeanTween.scale(quinientos, Vector3.zero, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Para el PowerUpSlowBall
        duracion=duracion-Time.deltaTime;
        if (duracion <= 0)
        {
            Debug.Log("Restablecer velocidad");
            vidasYPuntos.velBola = 30;
        }
        duracionInvertirControles = duracionInvertirControles - Time.deltaTime;
        if (duracionInvertirControles <= 0)
        {
            Debug.Log("Restablecer controles");
            MovimientoJugador.Instance.controlesInvertidos = false;
        }
    }
    public void SlowBall()
    {
        duracion = 5;
        vidasYPuntos.velBola = 20;
    }
    public void MasPuntos()
    {
        Debug.Log("500 puntos +");
        Puntuaciones.instance.puntos += 500;
        LeanTween.scale(quinientos, Vector3.one, 0.5f).setEase(LeanTweenType.easeOutQuint).setOnComplete(() =>
        {
            LeanTween.scale(quinientos, Vector3.zero, 0.1f).setEase(LeanTweenType.easeOutQuint);
        });
    }
    public void InvertirControles1()
    {
        duracionInvertirControles = 10;
        MovimientoJugador.Instance.InvertirControles2();
    }
}
