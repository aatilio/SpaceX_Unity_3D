using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoObstaculos : MonoBehaviour
{
    private Vector3 InitPos;
    [SerializeField] Vector3 DestPos;
    private Vector3 FinalPos;

    

    //public float speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<>();
        //print(FinalPos);
    }
    // Update is called once per frame
    void Update()
    {
        //var posF = transform.position.gameObject.
        InitPos = transform.position;
        FinalPos = InitPos + DestPos * Time.deltaTime;
        transform.position = FinalPos;
    }

    /*
    private Vector3 InitPos;
    
    private Vector3 FinalPos;

    [SerializeField] GameObject OtherObject;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float PosY = OtherObject.transform. position. Y;
        print(PosY); 
        if (PosX <= 12)
        {
            InitPos = OtherObject.transform. position;
            FinalPos = InitPos + DestPos * Time.deltaTime * speed;
            OtherObject.transform.position = FinalPoss
        }        
    }*/
}
