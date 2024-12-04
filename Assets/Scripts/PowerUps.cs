using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public static PowerUps Instance;

    [SerializeField]
    VidasYPuntos vidasYPuntos;
    // Start is called before the first frame update
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SlowBall(float duracion=10)
    {
        vidasYPuntos.velBola = 20;
        duracion=duracion-Time.deltaTime;
        if (duracion <= 0)
        {
            vidasYPuntos.velBola = 30;
        }
    }
}
