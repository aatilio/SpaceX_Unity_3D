using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDeNave : MonoBehaviour
{
    Rigidbody rigidbody;
    Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
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
        if (Input.GetKey(KeyCode.Space))
        {
            //print("Propulsor de la Nave...");
            GetComponent<Rigidbody>().AddRelativeForce(Vector3.up);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            //print("Girar a la Derecha...");
            var rotarDerecha = transform.rotation;
            rotarDerecha.x -= Time.deltaTime * 1;
            transform.rotation = rotarDerecha;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            //print("Girar a la Izquierda...");
            var rotarIzquierda = transform.rotation;
            rotarIzquierda.x += Time.deltaTime * 1;
            transform.rotation = rotarIzquierda;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //print("Girar a la Izquierda...");
            var positionDerecha = transform.position;
            positionDerecha.x -= Time.deltaTime * 10;
            transform.position = positionDerecha;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //print("Girar a la Izquierda...");
            var positionIzquierda = transform.position;
            positionIzquierda.x += Time.deltaTime * 10;
            transform.position = positionIzquierda;
        }
    }
}
