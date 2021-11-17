using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class aicontroller : MonoBehaviour
{
    [SerializeField] GameObject bitis;
    NavMeshAgent nav;
    Vector3 pos,mesafe;
    Rigidbody rb;
    Animator anim;
    NavMeshAgent navmeshagent;
    bool bitti = false;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        pos = transform.position;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        navmeshagent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(bitis.transform.position);
        transform.LookAt(bitis.transform.position);

    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag=="rotator")
        {
            mesafe = collision.gameObject.transform.position - transform.position;
            if(mesafe.x>0)
            {
                rb.velocity = new Vector3(0.4f, 0, 0);
            }
            else if(mesafe.x<0)
            {
                rb.velocity = new Vector3(-0.4f, 0, 0);
            }
            else if(mesafe.x==0)
            {
                rb.velocity = new Vector3(0f, 0, 0);
            }

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "engel")
        {
            anim.SetBool("carpma", true);
            StartCoroutine(geridon());

        }

    }
    IEnumerator geridon()
    {
        navmeshagent.speed = 0;
        yield return new WaitForSeconds(0.8f);
        anim.SetBool("carpma", false);
        transform.position = pos;
        navmeshagent.speed = 0.7f;
    }
}
