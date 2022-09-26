using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDeNave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //print("hoalj");
        ProcesarImput();
    }

    //metodo privado que sirve para saber que tecla se esta pulsando
    private void ProcesarImput()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            print("Propulsor de la Nave...");
        }
        if(Input.GetKey(KeyCode.D))
        {
            print("Girar a la Derecha...");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            print("Girar a la Izquierda...");
        }
    }
}
