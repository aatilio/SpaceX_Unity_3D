using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDeNave : MonoBehaviour
{
    Rigidbody rigidbody;
    Transform transform;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
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
        Propulsion();
        RotacionDerechaIzquierda();
        RotacionAdelanteAtras();
        TraslacionDerechaIzquierda();
    }
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "ColisionSegura":
            print("OK...");
            break;
            case "ColisionPeligrosa":
            print("PUMMMMNNN...");
            break;
            case "PlataformaPrincipal":
            print("NAVE ESTABLE...");
            break;
        }
        /*if (collision.gameObject.CompareTag("ColisionSegura"))
        {
            print("OK...");
        }
        else if (collision.gameObject.CompareTag("ColisionPeligrosa"))
        {
            print("PUNNNMMMM...");
        }*/
    }
    public void Propulsion()
    {
        //esta condicion nos dice que tecla es la que esta siendo pulsada
        if (Input.GetKey(KeyCode.Space))
        {
            //print("Propulsor de la Nave...");
            rigidbody.freezeRotation = true;
            GetComponent<Rigidbody>().AddRelativeForce(Vector3.up);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
        rigidbody.freezeRotation = false;
    }

    public void RotacionDerechaIzquierda()
    {
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
    }

    public void RotacionAdelanteAtras()
    {
        //ROTAR HACIA ADELANTE Y ATRAS
        if (Input.GetKey(KeyCode.W))
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

    public void TraslacionDerechaIzquierda()
    {
        //TRASLACION DERECHA IZQUIERDA
        if (Input.GetKey(KeyCode.A))
        {
            var positionIzquierda = transform.position;
            positionIzquierda.x -= Time.deltaTime * 3;
            transform.position = positionIzquierda;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            var positionDerecha = transform.position;
            positionDerecha.x += Time.deltaTime * 3;
            transform.position = positionDerecha;

        }
    }
}
