using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public static MovimientoJugador Instance;
    // Variables para el movimiento del jugador
    [SerializeField]
    BotonesMenu botonesMenu;
    [SerializeField]
    private float movimientoX;

    [SerializeField]
    public float velJugador;

    [SerializeField]
    private float min=26.8f;
    [SerializeField]
    private float max=-30.8f;

    private Rigidbody paloRb;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
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
            float newPosX = transform.position.x + movement * velJugador;// * Time.deltaTime;
            newPosX = Mathf.Clamp(newPosX, min, max);//Clamp hace las multiplicaciones
            //transform.position = new Vector3(newPosX, transform.position.y, transform.position.z);
            paloRb.velocity = new Vector3(movement*velJugador, 0, 0);//Si pongo el Time*deltaTime va con lag. Preguntar si se puede quitar
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SlowBall"))
        {
            PowerUps.Instance.SlowBall();
        }
    }
}
