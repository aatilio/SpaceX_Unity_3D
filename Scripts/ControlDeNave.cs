using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDeNave : MonoBehaviour
{
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //print("hola");
        ProcesarImput();
    }

    //metodo privado que sirbe para saber que tecla se esta pulsando
    private void ProcesarImput()
    { 
        //esta condicion nos dice que tecla es la que esta ciendo pusada
        if(Input.GetKey(KeyCode.Space))
        {
            //print("Propulsor de la Nave...");
            GetComponent<Rigidbody>().AddRelativeForce(Vector3.up);
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
