using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlTempo : MonoBehaviour
{
    [SerializeField] int min, seg;
    [SerializeField] TextMeshProUGUI reloj;

    private float tRestante;
    private bool exeReloj;

    private void Awake()
    {
        tRestante = (min * 60) + seg;
        exeReloj = true;
    }
    void Update()
    {
        if (exeReloj)
        {
            tRestante -= Time.deltaTime;
            if (tRestante < 1)
            {
                exeReloj = false;
                ControlDeNave.muerteExterna = true;    //muere el jugador
            }
            int tMin = Mathf.FloorToInt(tRestante / 60);
            int tSeg = Mathf.FloorToInt(tRestante % 60);
            reloj.text = string.Format("{00:00}:{01:00}", tMin, tSeg);
        }
    }
}
