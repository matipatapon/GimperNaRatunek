using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mag_controller : MonoBehaviour
{

    Assets assets;

    //Co ile sekund ma mag strzelić ???
    public float strzał_cooldown;
    //Timmer ile mineło od innego strzału 
    float strzał_timer = 0;
    //pod jakim kątem jest rozrzut
    public float rozrzut = 10;
    //Ile strzałów na raz ? 
    public int ile_pocisków = 1;
    //Czy pociski Auto_namierzają gracza ? 
    public bool czy_pociski_namierzają_gracza = false;
    //Prędkość pocisku 
    public float prędkość_pocisku = 1;
    //Czas despawnu pocisku
    public float despawn_pocisk = 10;
    //Enemy Controller 
    Enemy_Controller enemy_controller;

    void Start()
    {
        assets = GameObject.Find("Assets").GetComponent<Assets>();
        enemy_controller = GetComponent<Enemy_Controller>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Zachowanie się maga 

        //Jeśli żyje 
        if (enemy_controller.HP > 0)
        {
            //Zwracanie sie w strone gracza 
            var dir = new Vector2(transform.position.x, transform.position.y);
            dir -= new Vector2(assets.Player.transform.position.x, assets.Player.transform.position.y);
            var kąt = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(-kąt - 180, Vector3.forward);
        }
        //Jeśli umarł 
        else 
        {
            śmierć();
        }
    }
    private void FixedUpdate()
    {
        //Jeśli żyje
        if (enemy_controller.HP > 0)
        {
            strzał_timer += Time.deltaTime;
            if (strzał_timer >= strzał_cooldown)
            for(int i = 0;i<ile_pocisków;i++)
            strzał();
        }
    }

    //Pocisk prefab 

    //Czy gracz znajduje się w polu rażenia ? 
    public bool czy_gracz_w_polu_rażenia = false;

    void strzał() 
    {
        if (czy_sasin && !assets.czy_wszedl_do_komnaty_z_bosem) return;
        if (!czy_gracz_w_polu_rażenia) return;
        var r = transform.rotation;
        r.eulerAngles += new Vector3(0, 0, +Random.Range(-rozrzut, rozrzut));
        var o = Instantiate(assets.kula_demonetyzacji,transform.position,r);
        strzał_timer = 0;
        var bullet_controll = o.GetComponent<bullet_controll>();
        bullet_controll.auto_namierzanie_gracza = czy_pociski_namierzają_gracza;
        bullet_controll.impuls = prędkość_pocisku;
        bullet_controll.czas_do_despawnu = despawn_pocisk;
        
    }

    //Ma zostać wywołane 1 raz po śmierci 
    bool czy_wykonano_wyrok_śmierci = false;
    public bool czy_sasin = false;
    void śmierć() 
    {
        if (czy_wykonano_wyrok_śmierci) return;
        //Podmiana spritu maga na uśmierconego maga 
        GetComponent<SpriteRenderer>().sprite = assets.mag_dead_sprite;
        //Amatorka kompletna to powino być w osobnym skrypcie / switchu oraz w evencie ale mam 27h by odać gre - sen = 12h - reszta szkoła itp = 6h. Więc przyszły Mateuszu
        //Wiec że to nie tak powinno tu być ! 
       
        if (czy_sasin)
        {
            GetComponent<SpriteRenderer>().sprite = assets.sasin_dead_sprite;
            assets.Dialog.GetComponent<Dialog_Controller>().który_dialog = 100;
       
        }
            //Reset rotacji 
        transform.rotation = Quaternion.identity;
        //Wyłączenie kolizji 
        GetComponent<CircleCollider2D>().enabled = false;
        czy_wykonano_wyrok_śmierci = true;
    }
}
