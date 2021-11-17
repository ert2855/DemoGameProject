using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deneme : MonoBehaviour
{
    public Vector3 mesafe;
    private void OnCollisionStay(Collision collision)
    {
        mesafe = collision.gameObject.transform.position - transform.position;
        Debug.Log(mesafe);
        Debug.Log("girdi");
    }
   
}
