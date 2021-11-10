using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToplanabilirKüp : MonoBehaviour
{

    bool toplandiMi; //bir kere aldýðýmýz küpü bir daha almak istemiyoruz.
    int index; //yüksekliðini belirtir.
    public Toplayici toplamaci; //toplayýcýyý tanýmlýyorum eriþmek için

    bool WaterColTrue;
    // Start is called before the first frame update
    void Start()
    {
        toplandiMi = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (toplandiMi == true)
        {
            if (transform.parent != null) //birþeyin içindeyse çalýþsýn
            {
                transform.localPosition = new Vector3(0, -index, 0); // direk bunu yaparsak bütün kutular alt alta gelir bunu önelemek için if þartý yazýcaz.

            }
            transform.localPosition = new Vector3(0, -index, 0); // direk bunu yaparsak bütün   kutular alt alta gelir bunu önelemek için if þartý yazýcaz.
        }
      
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="water" || other.gameObject.tag =="Danger") //bir trigera girdiysek su ya girdiysem toplayýcýnýn yukseklik azalt fonksiyýnunu çaðýrýp azaltýyoruz.
        {
            
                toplamaci.YukseklikAzalt();
                transform.parent = null; //bizimle bir alakasý olmuyor çarptýktan sonra.
                GetComponent<BoxCollider>().enabled = false;//herhangi bir kutu býraktýðýmýzda onunda colliderýný kapatalým.
                other.gameObject.GetComponent<BoxCollider>().enabled = false; //çarptýðýmýz objeninde colliderýný kaptýyoruz ki bir daha orda çarpma gibi bir bug ortadan kalkar.
            
            

        }
        //bir suya girdiðimiz zaman yüksekliðimizin azlmasý lazým
    }
   

    public bool GetToplandiMi() //toplandýmý boolunu return etsin
    {
        return toplandiMi;
    }
    public void ToplandiYap() // ilk baþta toplandýsý false olarak ayarladýk.Ve sonra toplanýnca true deðerini döndürsün.
    {
        toplandiMi = true;
    }
    public void IndexAyarla(int index) //this.index globaldaki index
    {
        this.index = index;
    }

}
