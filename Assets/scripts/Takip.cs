using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Takip : MonoBehaviour
{
    [SerializeField] GameObject boy;
    public Vector3 konum;
    private void LateUpdate()
    {
        transform.position = boy.transform.position + konum;
    }
}
