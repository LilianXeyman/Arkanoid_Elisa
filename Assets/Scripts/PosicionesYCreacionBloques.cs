using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionesYCreacionBloques : MonoBehaviour
{
    public static PosicionesYCreacionBloques instance;
    
    //Para las posiciones de los bloques
    [SerializeField]
    public GameObject[] posiciones;

    [SerializeField]
    public GameObject[] prebasBloques;

    [SerializeField]
    public Transform bloques;

    [SerializeField]
    int bloquesAGenerar;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(this);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenerarNiveles()
    {
        for (int i = 0; i < posiciones.Length; i++)
        {
            posiciones[i].SetActive(false);
        }
        foreach (Transform child in bloques)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < bloquesAGenerar ; i++)
        {
            GameObject selectedPrefab = prebasBloques[Random.Range(0, prebasBloques.Length)];
            GameObject selectedPos = posiciones[Random.Range(0, posiciones.Length)];
            if (selectedPos.activeSelf == true)
            {
                bloquesAGenerar++;
                if (bloquesAGenerar >= 200)
                {
                    Debug.Log("límite");
                    break;
                }
            }
            else
            {
                selectedPos.SetActive(true);
                GameObject createdObject = Instantiate(selectedPrefab, new Vector3(selectedPos.transform.position.x, selectedPos.transform.position.y, selectedPos.transform.position.z), Quaternion.identity);
                createdObject.transform.parent = bloques;
            }
        }
    }
}
