using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refueling : MonoBehaviour
{
    [SerializeField] private float cantidadPuntos;
    [SerializeField] SP puntaje;

    public void OnCollisionEnter(Collision barril)
    {
        if (barril.transform.CompareTag("Player"))
        {
            puntaje.SumarPuntos(cantidadPuntos);
            Destroy(gameObject);
        }
    }
}
