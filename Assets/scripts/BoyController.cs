using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float hiz;
    Vector3 rot,baslangicpos;
    Animator anim;
    float mouseilkposx, mouseposx;
    bool start = false;
    [SerializeField] GameObject yonetici;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        baslangicpos = transform.position;
    }

    void Update()
    {
        start = yonetici.GetComponent<yonetici>().start;
        if(start)
            hareket();
        dusmekontrol();
    }

    void hareket()
    {
        transform.eulerAngles = new Vector3(0, rot.y, 0);
        if (Input.GetMouseButtonDown(0))
        {
            mouseilkposx = Input.mousePosition.x;
        }
        else if(Input.GetMouseButton(0))
        {
            mouseposx = Input.mousePosition.x - mouseilkposx;
            mouseilkposx = Input.mousePosition.x;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            mouseposx = 0;
        }

        transform.Translate(mouseposx * 0.1f * Time.deltaTime, 0, 0);
    }

    void dusmekontrol()
    {
        
        if (transform.position.y<-0.2f)
        {
            anim.SetBool("fall", true);
            if(transform.position.y < -2f)
            {
                PlayerPrefs.SetInt("can", PlayerPrefs.GetInt("can") - 1);
                transform.position = baslangicpos;
            }
        }
        else
        {
            anim.SetBool("fall", false);
        }
    }
    IEnumerator geridon()
    {
        rb.isKinematic = true;
        yield return new WaitForSeconds(0.8f);
        anim.SetBool("carpma", false);
        transform.position = baslangicpos;
        rb.isKinematic = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "engel")
        {
           PlayerPrefs.SetInt("can", PlayerPrefs.GetInt("can") - 1);
            anim.SetBool("carpma", true);
            StartCoroutine(geridon());
        }
        if (collision.gameObject.tag == "bitis")
        {
            PlayerPrefs.SetInt("bitti", 1);
            anim.SetBool("paint", true);
            transform.position += new Vector3(0,0,1.45f);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag=="zemin")
        {
            if(start)
                rb.velocity = Vector3.forward * hiz;//İleri Git
        }
        if (collision.gameObject.tag == "rotator")
        {
            
            rb.velocity = Vector3.forward * hiz;//İleri Git
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        //rb.freezeRotation = true;
        //transform.rotation=Quaternion.Euler(0,0,0);
        //rb.freezeRotation = false;
    }
}
