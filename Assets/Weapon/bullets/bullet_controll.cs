using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_controll : MonoBehaviour
{

    //przyspieszenie pocisku 
    public float impuls = 10;
    //private bool czy_dodano_impuls = true;
    public int obrażenia = 10;
    public float czas_do_despawnu = 10;

    //Czy sojuszniczy pocisk czy wrogi ? 
    public bool czy_sojuszniczy_pocisk = true;
    //Czy jest włączone autonamierzanie gracza ? ? ? 
    public bool auto_namierzanie_gracza = false;
   
    Rigidbody2D rb;

    Assets assets;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
        assets = GameObject.Find("Assets").GetComponent<Assets>();
    }
    private void Start()
    {
        rb.AddRelativeForce(new Vector2(0, impuls));
    }
    private void FixedUpdate()
    {
       
        czas_do_despawnu -= Time.deltaTime;
        if (czas_do_despawnu < 0) Destroy(gameObject);

        if (auto_namierzanie_gracza)
        {
            rb.AddRelativeForce(new Vector2(0, -impuls));
            Debug.Log(assets.Player.name);
           
            var d = new Vector2(assets.Player.gameObject.transform.position.x, assets.Player.gameObject.transform.position.y);
            d -= new Vector2(transform.position.x, transform.position.y);
            var kąt = Mathf.Atan2(d.y, d.x) * Mathf.Rad2Deg;
            rb.rotation = kąt - 90;
            rb.AddRelativeForce(new Vector2(0, impuls));

        }

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (czy_sojuszniczy_pocisk)
        {
            var c = collision.GetComponent<Enemy_Controller>();
            if (c != null)
            {
                c.HP -= obrażenia;
                Destroy(gameObject);
            }
        }
        else 
        {
         
            var c = collision.GetComponent<Player_Controller>();
            if (c != null)
            {
                c.HP -= obrażenia;
                Destroy(gameObject);
            }
          
        }
        //Obsługa budynków
        var c2 = collision.GetComponent<Struktura>();
        if (c2 != null)
        {
            if (!c2.czy_może_przelecieć_pocisk_nad_strukturą)
            {
                Destroy(gameObject);
            }
        }
    }
}
