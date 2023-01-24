using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SP : MonoBehaviour
{
    private float puntos = 100;
    private TextMeshPro textMesh;
    void Start()
    {
        textMesh = GetComponent<TextMeshPro>();
    }
    void Update()
    {
        textMesh.text = "COMBUSTIBLE: " + puntos + "%";
    }

    public void SumarPuntos(float puntosEntrada)
    {
        puntos += puntosEntrada;
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Combustible"))
        {
            puntos += 50;
            Destroy(other.gameObject);
        }
    }*/
}
