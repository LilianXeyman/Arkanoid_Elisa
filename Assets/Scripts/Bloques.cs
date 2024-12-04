using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bloques : MonoBehaviour
{
    //public static Bloques instance; No le puedo poner el singleton porque no compila
    //float timeCounted = 0.0f;
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

    //Para la música
    /*[SerializeField]
    public AudioClip bloqueRotoSFX;*/

    //public AudioSource audioSource;

    /*[SerializeField]
    TextMeshProUGUI sumaDePuntos;

    /*private void Awake()
    {
        sumaDePuntos.text = "+ 100";
        //Configurar la etiqueta
    }
   /* private void Update()
    {
        if (timeCounted > 0f)
        {
            timeCounted -= Time.deltaTime;
        }
        else
        {
            //Destroy(textoInstanciado);
            // Desactivar tu gameObject con texto
            //sumaDePuntos.gameObject.SetActive(false);//Buscar otra forma
        }
    }*/
    //Para detectar las colisiones de la bola con los bloques y cambiar el material
    public void OnCollisionEnter(Collision collision)
    {
        vidaBloques = vidaBloques - 1;
        //AudioSource.PlayClipAtPoint(bloqueRotoSFX, transform.position);
        Puntuaciones.instance.puntos += 100;
        MaxPuntuacion.Instance.AñadirPuntos(MaxPuntuacion.Instance.record);
        GameManager.instance.Sumar100();
        //MostrarPuntos();//Llama a la función MostrarPuntos en donde te cambia el tiempo en el que aparece en pantalla la suma y lo activa
        //Profe
        //timeCounted = 0.5f;
        // Activar tu gameObject con texto
        gameObject.GetComponent<MeshRenderer>().material = materiales[vidaBloques];
        if (vidaBloques <= 0)
        {
            Destroy(gameObject);
            Puntuaciones.instance.BlockDestroyed();
        }
    }
    /*public void MostrarPuntos()
    {
        timeCounted = 0.5f;
        // Activar tu gameObject con texto
    }
    /*IEnumerator apagarSumaPuntos() 
    {
       // GameObject TEXTO = GameObject.Find("Puntos Ganados");
        GameObject TEXTOINSTANCIADO = Instantiate(sumaDePuntos, TEXTO.transform.position, Quaternion.identity);
        sumaDePuntos.gameObject.SetActive(true);
        sumaDePuntos.text = "100";
        yield return new WaitForSeconds(0.25f);
        sumaDePuntos.gameObject.SetActive(false);
    }*/
}
