using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidasYPuntos : MonoBehaviour
{
    [SerializeField]
    BotonesMenu botonesMenu;

    [SerializeField]
    public int cuentaVidas=1;//Esto se irá modificando en base a los PowerUps

    [SerializeField]
    float velBola;

    [SerializeField]
    GameObject bola;

    [SerializeField]
    Rigidbody rb;

    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    public GameObject canvasMuerte;

    bool pelotaEnJuego;
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        canvasMuerte.SetActive(false);
    }
    void Update()
    {
        if (botonesMenu.tiempo == true)
        {
            if (!pelotaEnJuego && Input.GetKeyUp(KeyCode.Space))
            {
                pelotaEnJuego = true;
                transform.parent = null;
                rb.AddForce(Vector3.up * velBola);//Problemas con el rozamiento. La bola se va frenando.
            }
            if (pelotaEnJuego == true)
            {
                if (rb.velocity.magnitude != velBola)
                {
                    rb.velocity = rb.velocity.normalized * velBola;
                }
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Muerte"))
        {
            cuentaVidas = cuentaVidas - 1;
            if (cuentaVidas <= 0)
            {
                ReiniciarBola();
                botonesMenu.tiempo = false;
                canvasMuerte.SetActive(true);
                pelotaEnJuego = false;
            }
            else 
            {
                Debug.Log("No más vidas");  
            }
        }
    }
    private void ReiniciarBola()
    {
        gameObject.transform.position = new Vector3(883.7f, -137f, 250.9f);
        playerTransform.transform.localPosition = new Vector3(883.7f, -139.6667f, 250.6f);
        if (playerTransform != null)
        {
            transform.SetParent(playerTransform);
            Debug.Log("Bola reasignada");
        }
        else 
        {
            Debug.Log("No asignación");
        }
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
    //Para mantener la velocidad cte en la pelota
    /*private void EstablecerVelocidadInicial()
    { 
         rb.velocity=new Vector3(1f,1f,0f).normalized*velBola;
    }*/
}
