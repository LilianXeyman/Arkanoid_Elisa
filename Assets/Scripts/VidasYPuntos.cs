using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidasYPuntos : MonoBehaviour
{
    [SerializeField]
    BotonesMenu botonesMenu;

    [SerializeField]
    public int cuentaVidas = 3;//Esto se irá modificando en base a los PowerUps

    [SerializeField]
    Vector3 inpulsoBola;
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

    [SerializeField]
    public bool pelotaEnJuego;

    [SerializeField]
    public float fuerzaRebote = 10f;

    //Para el sistema de vidas
    [SerializeField]
    public Image imagen1Vidas, imagen2Vidas, imagen3Vidas;

    //Para las vidas de los bloques
    [SerializeField]
    public int vidas1Bloques = 0;
    [SerializeField]
    public int vidas2Bloques = 0;
    [SerializeField]
    public int vidas3Bloques = 0;
    [SerializeField]
    public int vidas4Bloques = 0;
    [SerializeField]
    GameObject bloque1Vida;
    [SerializeField]
    GameObject bloque2Vida;
    [SerializeField]
    GameObject bloque3Vida;
    [SerializeField]
    GameObject bloque4Vida;
    //Velocidad de la bola
    private Vector3 velocidadPrevia;
    private Vector3 direccionPrevia;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        canvasMuerte.SetActive(false);
    }
    void Update()
    {
        if (botonesMenu.tiempo == true)
        {
            if (!pelotaEnJuego && Input.GetButtonUp("Jump"))
            {
                rb.constraints &= ~RigidbodyConstraints.FreezePositionX;
                Debug.Log("Press Space");
                pelotaEnJuego = true;
                transform.parent = null;
                rb.AddForce(new Vector3(5f, 10f, 0f) * velBola);//Problemas con el rozamiento. La bola se va frenando.
                //rb.AddForce(inpulsoBola,ForceMode.Impulse );
            }
            if (pelotaEnJuego == true)
            {
                if (rb.velocity.magnitude != velBola)//Esto no se si funciona o si está bien
                {
                    rb.velocity = rb.velocity.normalized * velBola;
                }
            }
        }
        //Intento1
        /*if (botonesMenu.tiempo == true)
        {
            if (!pelotaEnJuego && Input.GetButtonUp("Jump"))
            {
                rb.constraints &= ~RigidbodyConstraints.FreezePositionX;
                Debug.Log("Press Space");
                pelotaEnJuego = true;
                transform.parent = null;
                if (velocidadPrevia != Vector3.zero)
                {
                    rb.velocity = velocidadPrevia;
                    rb.velocity = direccionPrevia * velocidadPrevia.magnitude;
                }
                else 
                {
                    rb.AddForce(new Vector3(5f, 10f, 0f) * velBola, ForceMode.Impulse);//Problemas con el rozamiento. La bola se va frenando.
                }
            }
            if (pelotaEnJuego == true)
            {
                if (rb.velocity.magnitude != velBola)//Esto no se si funciona o si está bien
                {
                    rb.velocity = rb.velocity.normalized * velBola;
                }
            }
            if (pelotaEnJuego)
            {
                rb.constraints &= ~RigidbodyConstraints.FreezePositionX;
            }
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            //rb.velocity = Vector3.zero;
            if (pelotaEnJuego)
            {
                velocidadPrevia = rb.velocity;
                direccionPrevia = rb.velocity.normalized;
            }
        }
        */
        //Va desactivando las imagenes que representan las vidas
        if (cuentaVidas == 2)
        {
            imagen1Vidas.enabled = false;

        }
        if (cuentaVidas == 1)
        {
            imagen2Vidas.enabled = false;
        }
        if (cuentaVidas == 0)
        {
            imagen3Vidas.enabled = false;
        }
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        rb.velocity=rb.velocity.normalized*velBola;
    }*/
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Muerte"))
        {
            cuentaVidas = cuentaVidas - 1;
            if (cuentaVidas < 3)
            {
                ReiniciarBola();
                pelotaEnJuego = false;
                if (cuentaVidas <= 0) //Cuando sale la pantalla de victoria se sigue moviendo la bola haciendo que pierdas las 3 vidas y te salga la pantalla de muerte
                {
                    botonesMenu.tiempo = false;
                    canvasMuerte.SetActive(true); 
                }
                else
                {
                    Debug.Log("No más vidas");
                }
            }
        }
    }
    public void ReiniciarBola()
    {
        gameObject.transform.position = new Vector3(883.7f, -137f, 250.9f);
        playerTransform.transform.localPosition = new Vector3(883.7f, -139.6667f, 250.6f);
        rb.constraints |= RigidbodyConstraints.FreezePositionX;
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
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Vector3 normalColision = col.contacts[0].normal;
            Vector3 direccionRebote = Vector3.Reflect(rb.velocity, normalColision);
            rb.velocity = direccionRebote.normalized * velBola * fuerzaRebote;
            /*Vector3 rebote = col.contacts[0].normal * rb.velocity.magnitude;
            rb.velocity=rebote*fuerzaRebote;*///Rebota raro
        }
        VelocityFix();
        //rigidbody comprobar vel en y si es menor a ? *10
    }
    private void VelocityFix()
    {
        float velocityDelta = 10f;
        float minVelocity = 5f;
        if(Mathf.Abs(rb.velocity.x) < minVelocity)
        {
            velocityDelta = Random.value < 10f ? velocityDelta:-velocityDelta;
            rb.velocity += new Vector3(velocityDelta, 0f, 0f);
        }
        if(Mathf.Abs(rb.velocity.y) < minVelocity)
        {
            velocityDelta = Random.value < 10f ? velocityDelta : -velocityDelta;
            rb.velocity += new Vector3(0f, velocityDelta, 0f);
        }
    }
}
