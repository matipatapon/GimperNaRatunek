using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    Rigidbody2D rb;
    Assets assets;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hp_1 = GameObject.Find("hp_1");
        assets = GameObject.Find("Assets").GetComponent<Assets>();
        hps = new GameObject[HP_START];
        życie_start();
       

    }

    // Update is called once per frame
    void Update()
    {
        życie();
    }
    //Zmiene przyspieszenie 
    //Przyspieszenie do Sprint , normalny ruch , do dyłu 
    public Vector3 przyspieszenie = new Vector3(1000, 500, 400);
    //Maksymalne velocity
    public Vector3 max_velocity = new Vector3(10, 5, 5);

    [SerializeField] private float obecne_velocity;
    private void FixedUpdate()
    {
        //Sterowanie Myszką 
        //Obracanie Gracza
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
        //Sterowanie Klawaiturą 
        Vector2 przyspieszenie_vector = new Vector2();
        //Obecne Velocity 
        obecne_velocity = Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y);

        bool W = Input.GetKey(KeyCode.W);
        bool S = Input.GetKey(KeyCode.S);
        bool A = Input.GetKey(KeyCode.A);
        bool D = Input.GetKey(KeyCode.D);
        bool Shift = Input.GetKey(KeyCode.LeftShift);
        if (W)
        {
            if (A && obecne_velocity < max_velocity.y)
                przyspieszenie_vector += new Vector2(-przyspieszenie.y, przyspieszenie.y);
            if (D && obecne_velocity < max_velocity.y)
                przyspieszenie_vector += new Vector2(przyspieszenie.y, przyspieszenie.y);
            if (!A && !D)
            {
                if (!Shift && obecne_velocity < max_velocity.y)
                    przyspieszenie_vector += new Vector2(0, przyspieszenie.y);
                if (Shift && obecne_velocity < max_velocity.x)
                    przyspieszenie_vector += new Vector2(0, przyspieszenie.x);
            }

        }
        if (S)
        {
            if (A && obecne_velocity < max_velocity.z)
                przyspieszenie_vector += new Vector2(-przyspieszenie.z, -przyspieszenie.z);
            if (D && obecne_velocity < max_velocity.z)
                przyspieszenie_vector += new Vector2(przyspieszenie.z, -przyspieszenie.z);
            if (!A && !D)
            {
                if (obecne_velocity < max_velocity.z)
                    przyspieszenie_vector += new Vector2(0, -przyspieszenie.z);

            }

        }
        if (A && !S && !W)
        {
            if (obecne_velocity < max_velocity.y)
                przyspieszenie_vector += new Vector2(-przyspieszenie.y, 0);
        }
        if (D && !S && !W)
        {
            if (obecne_velocity < max_velocity.y)
                przyspieszenie_vector += new Vector2(przyspieszenie.y, 0);
        }
        rb.AddRelativeForce(przyspieszenie_vector);
        
    }
    //Życie 
    public int HP_START = 10;
    public int HP = 10;
    //Ostatnio hp 
    public int HP_w_poprzednej_klatce;
    //1 hp 
    public GameObject hp_1;
    //Asset serduszka 
    public GameObject hp_prefab;
    //Wszystkie hp 
    GameObject[] hps;
    //Przerwa pomiędzy serduszkami 
    public float hp_przerwa = 10;
    //Sprite pełne hp 
    public Sprite hp_sprite;
    //Sprite broken hp
    public Sprite broken_hp_sprite;
    public bool god_mode = false;
    void życie() 
    {
        if (HP != HP_w_poprzednej_klatce) 
        {
            //Upewnienie się czy postac nie ma hp na minusie 
            if (HP < 0) HP = 0;
            if (HP > HP_START) HP = HP_START;
            //Śmierć
            if (HP == 0 && !god_mode) 
            {
                assets.Dialog.GetComponent<Dialog_Controller>().który_dialog = 999;
            }

           //Zresetój wygląd wszystkich hpków 
           for(int i = 0; i < HP; i++) 
            {
                hps[i].GetComponent<Image>().sprite = hp_sprite;
            }
           //Podmienianie obrazka dobrego hp na popsute 
           for(int i = HP_START - 1; i >= HP; i--) 
            {
                hps[i].GetComponent<Image>().sprite = broken_hp_sprite;
            }
            HP_w_poprzednej_klatce = HP;
        }

    }
    //Spawnuje na starcie x kafelków 

    void życie_start() 
    {
        HP = HP_START;
        HP_w_poprzednej_klatce = HP;
       
        var życie = GameObject.Find("Życie").transform;
        var przerwa = 0f;
        for(int i = 0; i < HP; i++) 
        {
           
            hps[i] = Instantiate(hp_prefab);
            hps[i].transform.SetParent(życie);
            hps[i].transform.position = new Vector3(życie.position.x + przerwa, życie.position.y, życie.position.z);
            przerwa += hp_przerwa + hp_prefab.GetComponent<RectTransform>().rect.width/2;
        }
    }

}
