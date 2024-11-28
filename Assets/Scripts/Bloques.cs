using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloques : MonoBehaviour
{
    //public static Bloques instance;
    
    [SerializeField]
    public int vidaBloques;

    [SerializeField]
    public Material[] materiales;

    [SerializeField]
    public int puntosBloques;

    /*private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }*/
    //Para detectar las colisiones de la bola con los bloques y cambiar el material
    public void OnCollisionEnter(Collision collision)
    {
        vidaBloques = vidaBloques - 1;
        puntosBloques = puntosBloques + 100;
        //PuntuacionesLlamar();
        gameObject.GetComponent<MeshRenderer>().material = materiales[vidaBloques];
        if (vidaBloques <= 0)
        {
            Destroy(gameObject);
        }
        //Puntuaciones.instance.Puntos();
    }
   /* public void PuntuacionesLlamar()
    {
        //puntosBloques = Puntuaciones.instance.puntosBloques;// De esta forma estoy guardando el resultado del valor de los puntos Bloques para que luego se pueda llamar desde el Script puntuaciones y se vaya actualizando 
    }*/
}
