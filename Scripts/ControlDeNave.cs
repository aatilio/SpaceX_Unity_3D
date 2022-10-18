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
        //ROTACION DERECHA IZQUIERDA
        if (Input.GetKey(KeyCode.Q))
        {
            var rotarIzquierda = transform.rotation;
            rotarIzquierda.z += Time.deltaTime * 1;
            transform.rotation = rotarIzquierda;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            var rotarDerecha = transform.rotation;
            rotarDerecha.z -= Time.deltaTime * 1;
            transform.rotation = rotarDerecha;
        }
        //TRASLACION DERECHA IZQUIERDA
        else if (Input.GetKey(KeyCode.A))
        {
            var positionIzquierda = transform.position;
            positionIzquierda.x -= Time.deltaTime * 10;
            transform.position = positionIzquierda;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            var positionDerecha = transform.position;
            positionDerecha.x += Time.deltaTime * 10;
            transform.position = positionDerecha;

        }
        //ROTAR HACIA ADELANTE Y ATRAS
        else if (Input.GetKey(KeyCode.W))
        {
            var rotarAdelante = transform.rotation;
            rotarAdelante.x += Time.deltaTime * 1;
            transform.rotation = rotarAdelante;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            var rotarAtras = transform.rotation;
            rotarAtras.x -= Time.deltaTime * 1;
            transform.rotation = rotarAtras;
        }
    }
}
