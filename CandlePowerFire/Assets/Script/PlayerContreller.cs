using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContreller : MonoBehaviour
{

    public float speed;
    public float LeftRightSpeed;
    Vector2 StartTouchVector;
    public GameObject camera;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.forward * speed * Time.deltaTime;
        camera.transform.position +=Vector3.forward * speed * Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            StartTouchVector = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            if (this.transform.position.x<=2.5f && this.transform.position.x>=-2.5f)
            {
                if (Input.mousePosition.x > StartTouchVector.x)
                {
                    this.transform.position += Vector3.right * LeftRightSpeed * Time.deltaTime;
                }
                if (Input.mousePosition.x < StartTouchVector.x)
                {
                    this.transform.position += Vector3.left * LeftRightSpeed * Time.deltaTime;
                }
                StartTouchVector = Input.mousePosition;
            }
            else
            {
                if (this.transform.position.x>2.5f)
                {
                    this.transform.position=new Vector3(2.4f,this.transform.position.y,this.transform.position.z);
                }
               else if (this.transform.position.x < -2.5f)
                {
                    this.transform.position = new Vector3(-2.4f, this.transform.position.y, this.transform.position.z);
                }
            }
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Finish")
        {
            speed = 0;
            panel.SetActive(true);
        }
    }


}
