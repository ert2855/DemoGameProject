using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalObstacleHareket : MonoBehaviour
{
    Vector3 baslangicpos,bitis,sol,sag;
    float zaman;
    public float hiz=1;
    private void Start()
    {
        baslangicpos = transform.localPosition;
        bitis = transform.localPosition + new Vector3(1, 0, 0);
        sol = baslangicpos;
        sag = bitis;
    }
    private void Update()
    {
        zaman = zaman + Time.deltaTime;
        transform.localPosition = Vector3.Lerp(baslangicpos, bitis, zaman/0.5f*hiz);
        if (transform.localPosition==sol)
        {
            baslangicpos = sol;
            bitis = sag;
            zaman = 0;
        }
        else if(transform.localPosition == sag)
        {
            baslangicpos = sag;
            bitis = sol;
            zaman = 0;
        }

    }


}
