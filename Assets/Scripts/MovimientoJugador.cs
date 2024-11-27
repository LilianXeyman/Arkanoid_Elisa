using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    // Variables para el movimiento del jugador
    [SerializeField]
    BotonesMenu botonesMenu;
    [SerializeField]
    private float movimientoX;

    [SerializeField]
    private float velJugador;

    [SerializeField]
    private float min=26.8f;
    [SerializeField]
    private float max=-30.8f;

    private Rigidbody paloRb;

    void Start()
    {
        paloRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*movimientoX = -Input.GetAxis("Horizontal") * Time.deltaTime * velJugador;
        transform.Translate(movimientoX, movimientoY, movimientoZ);*/ //De esta forma atraviesa las paredes
        if (botonesMenu.tiempo == true)
        {
            float movement = -Input.GetAxis("Horizontal");
            float newPosX = transform.position.x + movement * velJugador * Time.deltaTime;
            newPosX = Mathf.Clamp(newPosX, min, max);//Clamp hace las multiplicaciones
            //transform.position = new Vector3(newPosX, transform.position.y, transform.position.z);
            paloRb.velocity = new Vector3(movement*velJugador*Time.deltaTime, 0, 0);
        }
    }
}
