using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorDonus : MonoBehaviour
{
    public float donushizi;
    public bool sola;
   
    void Update()
    {
        if(sola)
            transform.Rotate(0, donushizi, 0);
        else
            transform.Rotate(0, -donushizi, 0);
    }
}
