using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField]
    public Image puntos1, puntos2, puntos3, puntos4;

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
