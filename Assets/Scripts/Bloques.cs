using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bloques : MonoBehaviour
{
    //public static Bloques instance; No le puedo poner el singleton porque no compila
    float timeCounted = 0.0f;

    [SerializeField]
    public int vidaBloques;

    [SerializeField]
    public Material[] materiales;

    [SerializeField]
    public int puntosBloques;

    [SerializeField]
    public AudioClip bloqueRotoSFX;

    [SerializeField]
    TextMeshProUGUI sumaDePuntos;

    //int sumaPuntos=100;

    private void Awake()
    {
        //Configurar la etiqueta
    }
    //Para detectar las colisiones de la bola con los bloques y cambiar el material
    public void OnCollisionEnter(Collision collision)
    {
        vidaBloques = vidaBloques - 1;
        AudioSource.PlayClipAtPoint(bloqueRotoSFX, transform.position);
        Puntuaciones.instance.puntos += 100f;
        timeCounted = 0.5f;
        // Activar tu gameObject con texto

        //sumaPuntos.SetActive(true);//No funciona por alguna razon con el TextMeshPro
        gameObject.GetComponent<MeshRenderer>().material = materiales[vidaBloques];
        if (vidaBloques <= 0)
        {
            Destroy(gameObject);
        }
    }
    /*IEnumerator apagarSumaPuntos() {

       // GameObject TEXTO = GameObject.Find("Puntos Ganados");
        GameObject TEXTOINSTANCIADO = Instantiate(sumaDePuntos, TEXTO.transform.position, Quaternion.identity);
        sumaDePuntos.gameObject.SetActive(true);
        sumaDePuntos.text = "100";
        yield return new WaitForSeconds(0.25f);
        sumaDePuntos.gameObject.SetActive(false);
    }*/

    private void Update()
    {
        if (timeCounted > 0f)
        {
            timeCounted -= Time.deltaTime;
        }
        else
        {
            // Desactivar tu gameObject con texto

        }
    }
}
