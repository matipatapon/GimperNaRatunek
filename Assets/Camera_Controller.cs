using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    //Assets 
    Assets Assets;

    //Opcje Kontrolne 
    public bool czy_śledzić_gracza = true;

    // Start is called before the first frame update
    void Start()
    {
        Assets = GameObject.Find("Assets").GetComponent<Assets>();
    }

    // Update is called once per frame
    void Update()
    {
        if (czy_śledzić_gracza)
            transform.position = new Vector3(Assets.Player.transform.position.x, Assets.Player.transform.position.y, -10);
        //transform.rotation = Assets.Player.transform.rotation;
    }
}
