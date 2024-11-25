using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    // Variables para el movimiento del jugador
    [SerializeField]
    public float movimientoX;

    [SerializeField]
    public float movimientoY;

    [SerializeField]
    public float movimientoZ;

    [SerializeField]
    public float velJugador;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movimientoX = -Input.GetAxis("Horizontal") * Time.deltaTime * velJugador;
        transform.Translate(movimientoX, movimientoY, movimientoZ);
    }
}
