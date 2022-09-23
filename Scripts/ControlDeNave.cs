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

    private void ProcesarImput()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            print("Propulsor...");
        }
        if(Input.GetKey(KeyCode.D))
        {
            print("Rotar Derecha...");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            print("Rotar Izquierda...");
        }
    }
}
