using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class event_controller : MonoBehaviour
{
    Assets assets;
    // Start is called before the first frame update
    void Start()
    {
        assets = GameObject.Find("Assets").GetComponent<Assets>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public enum event_typ_enum
    {
        start_gry,
        wejscie_do_domu,
        koniec_gry,
    }
    public event_typ_enum event_typ;

    public bool czy_wielokrotny_event = false;

    bool czy_wykonał_się_event = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!czy_wielokrotny_event && czy_wykonał_się_event) return;
        if (collision.name == "Player")
        {
            switch (event_typ)
            {
                case event_typ_enum.start_gry:
                    assets.Dialog.GetComponent<Dialog_Controller>().który_dialog = 1;
                    czy_wykonał_się_event = true;
                    break;
                case event_typ_enum.koniec_gry:
                    assets.Dialog.GetComponent<Dialog_Controller>().który_dialog = 200;
                    czy_wykonał_się_event = true;
                    break;
                case event_typ_enum.wejscie_do_domu:
                    assets.Dialog.GetComponent<Dialog_Controller>().który_dialog = 10;
                    GetComponent<EdgeCollider2D>().enabled = true;
                    czy_wykonał_się_event = true;
                    break;

            }
           
        }
    }

}


