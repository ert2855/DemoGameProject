using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class yonetici : MonoBehaviour
{
    [SerializeField] GameObject bitiscizgisi, player,mainCamera,PaintCamera;
    [SerializeField] GameObject[] yarismacilar;
    [SerializeField] GameObject gamovercanvas,parkursonucanvas,baslacanvas,gostergecanvas,paintcanvas,AI;
    float bitisnoktasi,playersira;
    [SerializeField] Text sira,can,bitissira,gerisayimtext;
    public float gerisayimsayi = 3;
    public bool start = false, canvasacildi = false;
    void Start()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("can", 2);
        PlayerPrefs.SetInt("bitti", 0);
        bitisnoktasi = bitiscizgisi.transform.position.z;
        StartCoroutine(gerisayim());
    }

    void Update()
    {
 
        can.text = PlayerPrefs.GetInt("can").ToString();
        siralama();
        gameover();
        parkursonu();
    }

    void siralama()
    {
        playersira = 1;
        float playermesafe = bitisnoktasi - player.transform.position.z;
        for (int i=0;i<=9;i++)
        {
            float mesafe = bitisnoktasi - yarismacilar[i].transform.position.z;
            if (mesafe < playermesafe)
                playersira++;

        }
        sira.text = playersira.ToString();
    }
    void gameover()
    {
        if(PlayerPrefs.GetInt("can")<=0)
        {
            Time.timeScale = 0;
            gamovercanvas.SetActive(true);
        }
    }
    void parkursonu()
    {
        if(PlayerPrefs.GetInt("bitti")==1)
        {
            start = false;
            if (!canvasacildi)
            {
                parkursonucanvas.SetActive(true);
                canvasacildi = true;
                Time.timeScale = 0;
            }
            bitissira.text = playersira + ".";
        }
        
    }
    IEnumerator gerisayim()
    {
        gerisayimtext.text = "3";
        yield return new WaitForSeconds(1);
        gerisayimtext.text = "2";
        yield return new WaitForSeconds(1);
        gerisayimtext.text = "1";
        yield return new WaitForSeconds(1);
        gerisayimtext.text = "GO";
        yield return new WaitForSeconds(1);
        Time.timeScale = 1;
        start = true;
        baslacanvas.SetActive(false);
        AI.SetActive(true);
    }

    public void againbuton()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void mainmenu()
    {

        SceneManager.LoadScene(0);
    }
    public void nextlevel()
    {
        Time.timeScale = 1;
        parkursonucanvas.SetActive(false);
        gostergecanvas.SetActive(false);
        paintcanvas.SetActive(true);
        PaintCamera.SetActive(true);
        mainCamera.SetActive(false);
        
    }

    public void exitbutton()
    {
        Application.Quit();
    }
}
