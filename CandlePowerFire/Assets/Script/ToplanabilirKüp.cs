using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToplanabilirK�p : MonoBehaviour
{

    bool toplandiMi; //bir kere ald���m�z k�p� bir daha almak istemiyoruz.
    int index; //y�ksekli�ini belirtir.
    public Toplayici toplamaci; //toplay�c�y� tan�ml�yorum eri�mek i�in

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
            if (transform.parent != null) //bir�eyin i�indeyse �al��s�n
            {
                transform.localPosition = new Vector3(0, -index, 0); // direk bunu yaparsak b�t�n kutular alt alta gelir bunu �nelemek i�in if �art� yaz�caz.

            }
            transform.localPosition = new Vector3(0, -index, 0); // direk bunu yaparsak b�t�n   kutular alt alta gelir bunu �nelemek i�in if �art� yaz�caz.
        }
      
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="water" || other.gameObject.tag =="Danger") //bir trigera girdiysek su ya girdiysem toplay�c�n�n yukseklik azalt fonksiy�nunu �a��r�p azalt�yoruz.
        {
            
                toplamaci.YukseklikAzalt();
                transform.parent = null; //bizimle bir alakas� olmuyor �arpt�ktan sonra.
                GetComponent<BoxCollider>().enabled = false;//herhangi bir kutu b�rakt���m�zda onunda collider�n� kapatal�m.
                other.gameObject.GetComponent<BoxCollider>().enabled = false; //�arpt���m�z objeninde collider�n� kapt�yoruz ki bir daha orda �arpma gibi bir bug ortadan kalkar.
            
            

        }
        //bir suya girdi�imiz zaman y�ksekli�imizin azlmas� laz�m
    }
   

    public bool GetToplandiMi() //topland�m� boolunu return etsin
    {
        return toplandiMi;
    }
    public void ToplandiYap() // ilk ba�ta topland�s� false olarak ayarlad�k.Ve sonra toplan�nca true de�erini d�nd�rs�n.
    {
        toplandiMi = true;
    }
    public void IndexAyarla(int index) //this.index globaldaki index
    {
        this.index = index;
    }

}
