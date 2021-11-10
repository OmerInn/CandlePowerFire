using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toplayici : MonoBehaviour //toplay�c�
{
    GameObject MyCube; // ana k�b�m�ze eri�iyoruz.
    int height; //y�ksekli�ini tutucak.





    // Start is called before the first frame update
    void Start()
    {
        MyCube = GameObject.Find("MyCube");
    }

    // Update is called once per frame
    void Update()
    {
        //yerden y�kseklik artt���nda bizim k�b�m�zde yerden arts�n.
        MyCube.transform.position = new Vector3(transform.position.x, height + 1, transform.position.z);
        this.transform.localPosition = new Vector3(0, -height, 0); //bizim guther yani toplay�c�m�z player�m�z�n ���NDE.yani local pozisyonda.

    }

    public void YukseklikAzalt()
    {
        height-=2;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Topla" && other.GetComponent<ToplanabilirK�p>().GetToplandiMi() == false) //gameobjenin ismi ne ise bizde gather bunun y�ksekli�ini bir artt�r.
        {
            height += 2;
            other.gameObject.GetComponent<ToplanabilirK�p>().ToplandiYap(); //K�P TOPLANMI� OLUYOR.
            other.gameObject.GetComponent<ToplanabilirK�p>().IndexAyarla(height); //Yerden y�ksekli�iindexini ayarl�y�caz.toplad���m�z k�p ald�m�za gelicek ve biz bunu belirticez.
            other.gameObject.transform.parent = MyCube.transform; //yard�mc� k�pler bizim k�b�m�z oluca�� i�in bize eklememiz gerekiyor.Ana k�p.transform .art�k �arpt���m�z other parent gutherse o bizim alt�m�zda olu�ucak. 
                
        }
    }

}
