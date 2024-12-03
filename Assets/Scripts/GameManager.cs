using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField]
    public Image puntos1, puntos2, puntos3, puntos4;

    public float tiempoPuntos1 = 0;
    public float tiempoPuntos2 = 0;
    public float tiempoPuntos3 = 0;
    public float tiempoPuntos4 = 0;

    [SerializeField]
    LeanTweenType animacionImagenes;

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
        puntos1.gameObject.transform.localScale = Vector3.zero;
        puntos2.gameObject.transform.localScale = Vector3.zero;
        puntos3.gameObject.transform.localScale = Vector3.zero;
        puntos4.gameObject.transform.localScale = Vector3.zero;
    }
    void Update()
    {
        /*tiempoPuntos1 = tiempoPuntos1 - Time.deltaTime;
        if (tiempoPuntos1 <= 0)
        {
            puntos1.enabled = false;
        }
        tiempoPuntos2 = tiempoPuntos2 - Time.deltaTime;
        if (tiempoPuntos2 <= 0)
        {
            puntos2.enabled = false;
        }
        tiempoPuntos3 = tiempoPuntos3 - Time.deltaTime;
        if (tiempoPuntos3 <= 0)
        {
            puntos3.enabled = false;
        }
        tiempoPuntos4 = tiempoPuntos4 - Time.deltaTime;
        if (tiempoPuntos4 <= 0)
        {
            puntos4.enabled = false;
        }*/
    }
    public void Sumar100()
    {
        Debug.Log("Entra en juego");

        LeanTween.scale(puntos1.gameObject, Vector3.one, 0.1f).setEase(animacionImagenes).setOnComplete(() =>
        {
            LeanTween.scale(puntos2.gameObject, Vector3.one, 0.1f).setEase(animacionImagenes).setOnComplete(() =>
            {
                LeanTween.scale(puntos3.gameObject, Vector3.one, 0.1f).setEase(animacionImagenes).setOnComplete(() =>
                {
                    LeanTween.scale(puntos4.gameObject, Vector3.one, 0.1f).setEase(animacionImagenes).setOnComplete(() =>
                    {
                        LeanTween.scale(puntos4.gameObject, Vector3.one, 0.5f).setEase(animacionImagenes).setOnComplete(() =>
                        {
                            LeanTween.scale(puntos1.gameObject, Vector3.zero, 0.1f).setEase(animacionImagenes).setOnComplete(() =>
                            {
                                LeanTween.scale(puntos2.gameObject, Vector3.zero, 0.1f).setEase(animacionImagenes).setOnComplete(() =>
                                {
                                    LeanTween.scale(puntos3.gameObject, Vector3.zero, 0.1f).setEase(animacionImagenes).setOnComplete(() =>
                                    {
                                        LeanTween.scale(puntos4.gameObject, Vector3.zero, 0.1f).setEase(animacionImagenes);
                                    });
                                });
                            });
                        });
                    });
                });
            });
        });
    }
}
