using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bloques : MonoBehaviour
{
    //Para la creación de PowerUps
    [SerializeField]
    GameObject powerUpSlowBall;
    [SerializeField]
    float probPowerUpSlowBall = 0.2f;
    //public static Bloques instance; No le puedo poner el singleton porque no compila
    [SerializeField]
    MaxPuntuacion maxPuntuacion;

    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    public int vidaBloques;

    [SerializeField]
    public Material[] materiales;

    [SerializeField]
    public int puntosBloques;

    //Para detectar las colisiones de la bola con los bloques y cambiar el material
    public void OnCollisionEnter(Collision collision)
    {
        vidaBloques = vidaBloques - 1;
        CrearPowerUp();
        Puntuaciones.instance.puntos += 100;
        MaxPuntuacion.Instance.AñadirPuntos(MaxPuntuacion.Instance.record);
        GameManager.instance.Sumar100();
        // Activar tu gameObject con texto
        gameObject.GetComponent<MeshRenderer>().material = materiales[vidaBloques];
        if (vidaBloques <= 0)
        {
            Destroy(gameObject);
            Puntuaciones.instance.BlockDestroyed();
        }
    }
    public void CrearPowerUp()//Sirve para crear el PowerUp dependiendo de la probabilidad en el lugar de la colisión
    {
        if (Random.value <= probPowerUpSlowBall)
        {
            Instantiate(powerUpSlowBall, transform.position,Quaternion.identity);
        }
    }
}
