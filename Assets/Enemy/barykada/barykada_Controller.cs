using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barykada_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    Enemy_Controller ec;
    Assets assets;
    public bool czy_brama = false;
    public bool czy_drzwi = false;
    void Start()
    {
        ec = GetComponent<Enemy_Controller>();
        assets = GameObject.Find("Assets").GetComponent<Assets>();
    }

    bool czy_został_zniszczony = false;
    void Update()
    {
        if (ec.HP <= 0 && ! czy_został_zniszczony) 
        {
            czy_został_zniszczony = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = assets.popsuta_barykada;
            if(czy_brama) gameObject.GetComponent<SpriteRenderer>().sprite = assets.popsuta_brama;
            if(czy_drzwi) gameObject.GetComponent<SpriteRenderer>().sprite = assets.popsute_drzwi;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
