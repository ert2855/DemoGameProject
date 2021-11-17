using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class brush : MonoBehaviour
{
    float mouseilkposx, mouseilkposy, mouseposx, mouseposy;
    List<string> duvarparca = new List<string>();
    [SerializeField] Text boyamiktari; 
    [SerializeField] Slider boyalikisim; 
    [SerializeField] GameObject oyunsonucanvas; 
    void Update()
    {
        oyunsonu();
        if(PlayerPrefs.GetInt("bitti")==1)
            hareket();
        boyamiktari.text = duvarparca.Count.ToString();
        boyalikisim.value = duvarparca.Count;
    }
    void hareket()
    {

        if (Input.GetMouseButtonDown(0))
        {
            mouseilkposx = Input.mousePosition.x;
            mouseilkposy = Input.mousePosition.y;
        }
        else if (Input.GetMouseButton(0))
        {
            mouseposx = Input.mousePosition.x - mouseilkposx;
            mouseposy = Input.mousePosition.y - mouseilkposy;
            mouseilkposx = Input.mousePosition.x;
            mouseilkposy = Input.mousePosition.y;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            mouseposx = 0;
            mouseposy = 0;
        }
        transform.Translate(mouseposx * 0.1f * Time.deltaTime, mouseposy * 0.1f * Time.deltaTime, 0);
        transform.localPosition = new Vector3(
            Mathf.Clamp(transform.localPosition.x, -0.95f, -0.15f),
            Mathf.Clamp(transform.localPosition.y, -0.9f,0),
            transform.localPosition.z);
    }

    void oyunsonu()
    {
        if(duvarparca.Count>=100)
            oyunsonucanvas.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Renderer>().material.color = Color.red;
        if(!duvarparca.Contains(other.gameObject.name))
            duvarparca.Add(other.gameObject.name);
    }
}
