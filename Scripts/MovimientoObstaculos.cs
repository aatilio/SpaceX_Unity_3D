using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]       //  Evitar que se agregen mas de un mismo  componente                 Atributos de clase
//[ExecuteInEditMode]    ejecucion de los metodos principales sin tener que darle PLAY
//[RequireComponent]  agregar componentes al  importar un objeto si es que este no lo tiene a�n
public class MovimientoObstaculos : MonoBehaviour
{
    [SerializeField][Range(0, 1)] float desplazar;
    [SerializeField] Vector3 posicionInicial;
    [SerializeField] Vector3 despDireccion;
    [SerializeField] float periodo = 1;
    // private Vector3 FinalPos;

    //public float speed = 0;
    void Start()
    {
        posicionInicial = transform.position;
        //audioSource = GetComponent<>();
        //print(FinalPos);
    }

    void Update()
    {
        if (periodo >= Mathf.Epsilon) //evitar comparar flotantes con "= o !=" en cambio ">= <=" 
        {
            float nro_ciclos = Time.time / periodo;       //Time.time=tiempo desde inicio del juego (seg)  |  periodo= cuanto tarda en cumplirse un ciclo
            float tau = Mathf.PI * 2;
            float fSeno = Mathf.Sin(tau * nro_ciclos);
            desplazar = (fSeno / 2 + 0.5f);
            transform.position = posicionInicial + (despDireccion * desplazar);  //Automatizar desplazamiento de 0-1
        }
        //FinalPos = InitPos + DestPos * Time.deltaTime;
        // transform.position = FinalPos;
    }

    /*
    private Vector3 InitPos;
    
    private Vector3 FinalPos;

    [SerializeField] GameObject OtherObject;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float PosY = OtherObject.transform. position. Y;
        print(PosY); 
        if (PosX <= 12)
        {
            InitPos = OtherObject.transform. position;
            FinalPos = InitPos + DestPos * Time.deltaTime * speed;
            OtherObject.transform.position = FinalPoss
        }        
    }*/
}
