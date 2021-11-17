using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float kuvvet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "boy" || collision.gameObject.tag == "girl")
        {
            collision.gameObject.transform.localPosition =collision.gameObject.transform.localPosition - new Vector3(0, 0, 0.2f);
        }
    }
}
