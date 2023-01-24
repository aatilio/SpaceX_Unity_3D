using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntos : MonoBehaviour
{
    public float totalPuntos;


    public void SumarPuntos(float puntos)
    {
        totalPuntos += puntos;
    }
}
