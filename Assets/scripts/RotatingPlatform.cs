using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    public float rotatorkuvvet;
    public bool soladonus = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(soladonus)
            transform.Rotate(new Vector3(0, 0, -1.5f));
        else
            transform.Rotate(new Vector3(0, 0, 1.5f));
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag=="boy" || collision.gameObject.tag=="girl")
        {
            if(soladonus)
                collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(rotatorkuvvet, 0, 0));
            else
                collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-rotatorkuvvet, 0, 0));
        }
    }
}
