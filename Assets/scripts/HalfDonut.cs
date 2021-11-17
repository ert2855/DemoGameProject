using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfDonut : MonoBehaviour
{
    Vector3 baslangicpos, bitis, sol, sag,ilkpos;
    float zaman;
    public float hiz = 1,fark,beklemesuresi=3;
    bool hareketet=true;
    public bool solagit;
    private void Start()
    {
        ilkpos = transform.localPosition;
        if(solagit)
        {
            baslangicpos = transform.localPosition;
            bitis = transform.localPosition + new Vector3(-fark, 0, 0);
        }
        else
        {
            baslangicpos = transform.localPosition + new Vector3(-fark, 0, 0);
            bitis = transform.localPosition;
        }
        sol = baslangicpos;
        sag = bitis;
    }
    private void Update()
    {
        transform.Rotate(5, 0, 0);
        if(hareketet)
        {
            zaman = zaman + Time.deltaTime;
            transform.localPosition = Vector3.Lerp(baslangicpos, bitis, zaman / 0.5f * hiz);
            if (transform.localPosition == sol)
            {
                baslangicpos = sol;
                bitis = sag;
                zaman = 0;
            }
            else if (transform.localPosition == sag)
            {
                baslangicpos = sag;
                bitis = sol;
                zaman = 0;
            }
            if (transform.localPosition == ilkpos)
                StartCoroutine(bekle());
        }
    }
    IEnumerator bekle()
    {
        hareketet = false;
        yield return new WaitForSeconds(beklemesuresi);
        hareketet = true;
    }
}
