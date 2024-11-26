using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidasYPuntos : MonoBehaviour
{
    [SerializeField]
    BotonesMenu botonesMenu;

    [SerializeField]
    int cuentaVidas=3;//Esto se irá modificando en base a los PowerUps

    [SerializeField]
    float velBola;

    [SerializeField]
    GameObject bola;

    [SerializeField]
    Rigidbody rb;
    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            transform.parent = null;
            rb.AddForce(Vector3.up * velBola);//Problemas con el rozamiento. La bola se va frenando.
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Muerte"))
        {
            cuentaVidas = cuentaVidas - 1;
            if (cuentaVidas == 0)
            {
                gameObject.transform.localPosition = new Vector3 (883.7f, -142.8f,250.9f);
                if (other.CompareTag("Player"))
                {
                    other.gameObject.transform.localPosition = new Vector3(883.7f, -145.6f, 250.6f);
                    if (other != null && other.transform.childCount > 0)//Miras a ver si tiene más hijos
                    {
                        Transform playerChild = other.transform.GetChild(0);//Le da a la bola el componente hijo de "Player"
                    }
                    else
                    {
                        Debug.LogWarning("El jugador no tiene hijos o no se ha encontrado.");
                    }
                }
                
            }
        }
    }
}
