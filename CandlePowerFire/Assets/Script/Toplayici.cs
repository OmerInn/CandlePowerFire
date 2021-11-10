using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toplayici : MonoBehaviour //toplayýcý
{
    GameObject MyCube; // ana kübümüze eriþiyoruz.
    int height; //yüksekliðini tutucak.





    // Start is called before the first frame update
    void Start()
    {
        MyCube = GameObject.Find("MyCube");
    }

    // Update is called once per frame
    void Update()
    {
        //yerden yükseklik arttýðýnda bizim kübümüzde yerden artsýn.
        MyCube.transform.position = new Vector3(transform.position.x, height + 1, transform.position.z);
        this.transform.localPosition = new Vector3(0, -height, 0); //bizim guther yani toplayýcýmýz playerýmýzýn ÝÇÝNDE.yani local pozisyonda.

    }

    public void YukseklikAzalt()
    {
        height-=2;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Topla" && other.GetComponent<ToplanabilirKüp>().GetToplandiMi() == false) //gameobjenin ismi ne ise bizde gather bunun yüksekliðini bir arttýr.
        {
            height += 2;
            other.gameObject.GetComponent<ToplanabilirKüp>().ToplandiYap(); //KÜP TOPLANMIÞ OLUYOR.
            other.gameObject.GetComponent<ToplanabilirKüp>().IndexAyarla(height); //Yerden yüksekliðiindexini ayarlýyýcaz.topladýðýmýz küp aldýmýza gelicek ve biz bunu belirticez.
            other.gameObject.transform.parent = MyCube.transform; //yardýmcý küpler bizim kübümüz olucaðý için bize eklememiz gerekiyor.Ana küp.transform .artýk çarptýðýmýz other parent gutherse o bizim altýmýzda oluþucak. 
                
        }
    }

}
