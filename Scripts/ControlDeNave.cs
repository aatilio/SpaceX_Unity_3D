using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ControlDeNave : MonoBehaviour
{
    Rigidbody rigidbody;
    Transform transform;
    AudioSource audioSource;
    enum Estado { alive, dead, reload, nivelcompleto };
    private Estado estadoNave = Estado.alive;
    private bool activeCrash = true;
    private int colisiones = 5;

    public int condicion = 0;
    public static bool muerteExterna = false;

    //SISTEMA DE PUNTUACION
    public float puntos;
    public float totalPuntaje;
    public Text textPuntos;


    //Usando el valor de otro codigo
    //public Puntos codigoPuntaje;

    //para funciones
    //Puntos codigoFuncionSumar;

    //LimiteColisiones

    //Invoke
    [SerializeField] float DelayMuerte = 1.0f;
    [SerializeField] float DelayNivelCompleto = 1.0f;
    //sonidos
    [Header("Sonidos")]
    [SerializeField] AudioClip sonidoCombustible;
    [SerializeField] AudioClip sonidoExplosion;
    [SerializeField] AudioClip sonidoNivelCompletado;

    [Header("Particulas")]
    [SerializeField] ParticleSystem ParticulaPropulsion;
    [SerializeField] ParticleSystem ParticulaMuerte;
    [SerializeField] ParticleSystem ParticulaNivelC;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
        //que encuenter el objeto para variables
        //codigoPuntaje = FindObjectOfType<Puntos>();
        //para funciones
        //codigoFuncionSumar = GameObject.FindGameObjectWithTag("coin").GetComponent<Puntos>();
    }

    void Update()
    {
        if (muerteExterna)
        {
            muerteExterna = false;
            ProcesarMuerte();
        }
        //print("hola");
        ProcesarImput();
        //textPuntos.text = "Puntos " + codigoPuntaje.totalPuntaje.ToString();
        textPuntos.text = "Puntos " + totalPuntaje.ToString();


    }

    //metodo privado que sirve para saber que tecla se esta pulsando
    private void ProcesarImput()
    {
        if (estadoNave == Estado.alive)
        {
            Propulsion();
            RotacionDerechaIzquierda();
            RotacionAdelanteAtras();
            TraslacionDerechaIzquierda();
        }
        //TODO opciones de desarrollador
        if (Debug.isDebugBuild)
        {
            procesosInputDev();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (estadoNave != Estado.alive || activeCrash == false)
        {
            return;
        }
        switch (collision.gameObject.tag)
        {
            case "ColisionSegura":
                break;
            case "Combustible":
                print("Recargando Combustible");
                break;
            case "coin":
                print("Acumula puntos");
                /*ObjPuntos.GetComponent<Puntos>().puntos += puntaje;
                Destroy(gameObject);*/
                break;
            case "PlataformaControl":
                // print("Estamos a salvo por ahora...");
                ProcesarNivelCompleto();
                //sumar puntos
                //codigoFuncionSumar.SumarPuntos(puntos);

                break;
            default:
                //print("Colisiona la Nave...");
                if (colisiones != 0)
                {
                    colisiones = colisiones - 1;
                }
                else if (condicion == 2)
                {
                    ProcesarMuerteOwer();
                }
                else
                {
                    ProcesarMuerte();
                }
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

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "coin")
        {
            ObjPuntos.GetComponent<Puntos>().puntos += puntaje;
            Destroy(gameObject);
        }
    }*/

    private void procesosInputDev()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            activeCrash = !activeCrash;
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            nextlvl();
        }
    }

    /*private void ProcesarRecargaCombustible()
    {
        audioSource.Stop();
        estadoNave = Estado.reload;
        Invoke("OnCollisionEnter", DelayCombustible);
        audioSource.PlayOneShot(sonidoCombustible);
        if (estadoNave == Estado.reload)
        {
            ProcesarNivelCompleto();
        }
        ParticulaNivelC.Play();
    }*/

    private void ProcesarNivelCompleto()
    {
        audioSource.Stop();
        estadoNave = Estado.nivelcompleto;
        Invoke("nextlvl", DelayNivelCompleto);
        audioSource.PlayOneShot(sonidoNivelCompletado);
        ParticulaNivelC.Play();
        totalPuntaje += puntos;
        //textPuntos.text = "Puntos " + codigoPuntaje.totalPuntos.ToString();
        textPuntos.text = "Puntos " + totalPuntaje.ToString();
    }

    private void ProcesarMuerte()
    {
        condicion += 1;
        audioSource.Stop();
        estadoNave = Estado.dead;
        Invoke("dead", DelayMuerte);
        audioSource.PlayOneShot(sonidoExplosion);
        ParticulaMuerte.Play();

    }

    private void ProcesarMuerteOwer()
    {
        audioSource.Stop();
        estadoNave = Estado.dead;
        Invoke("deadOwer", DelayMuerte);
        audioSource.PlayOneShot(sonidoExplosion);
        ParticulaMuerte.Play();
    }

    public void dead()
    {
        int numeroEscenas = SceneManager.sceneCountInBuildSettings;
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escenaActual);//nos lleva al inicio del nivel que estamos
    }

    public void deadOwer()
    {
        SceneManager.LoadScene("Nivel-1");//no lleva al nivel 1
    }

    public void nextlvl()
    {
        int numeroEscenas = SceneManager.sceneCountInBuildSettings;
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        int siguienteEscena = (escenaActual + 1) % numeroEscenas;
        /*if (siguienteEscena == numeroEscenas)
        {
            siguienteEscena= 0;
        }*/
        SceneManager.LoadScene(siguienteEscena);//nos lleva al siguiente nivel
    }

    public void Propulsion()
    {
        //esta condicion nos dice que tecla es la que esta siendo pulsada
        if (!ParticulaPropulsion.isPlaying)
        { ParticulaPropulsion.Play(); }
        if (Input.GetKey(KeyCode.Space))
        {
            //print("Propulsor de la Nave...");
            rigidbody.freezeRotation = true;
            GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * 3.0f);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
            ParticulaPropulsion.Stop();
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
            positionIzquierda.x -= Time.deltaTime * 11;
            transform.position = positionIzquierda;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            var positionDerecha = transform.position;
            positionDerecha.x += Time.deltaTime * 11;
            transform.position = positionDerecha;
        }
    }
}
