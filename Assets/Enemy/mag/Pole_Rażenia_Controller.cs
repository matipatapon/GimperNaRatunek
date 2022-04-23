using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pole_Rażenia_Controller : MonoBehaviour
{
    //Mag
    mag_controller mag;
    public bool czy_sasin = false;
    void Start()
    {
        if (czy_sasin) 
        {
            mag = GameObject.Find("Sasin").gameObject.GetComponent<mag_controller>();
           
        }
        else
        mag = transform.parent.gameObject.GetComponent<mag_controller>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player") mag.czy_gracz_w_polu_rażenia = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player") mag.czy_gracz_w_polu_rażenia = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
}
