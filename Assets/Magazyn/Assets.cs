using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assets : MonoBehaviour
{
    //Słuzy jako magazyn assetów po co czegoś 10 razy szukać ? 

    //Gracz 
    public GameObject Player;
    //Weapon
    public GameObject Weapon;
    //Barykada 
    public Sprite popsuta_barykada;
    public Sprite popsute_drzwi;
    //Brama
    public Sprite popsuta_brama;
    //Mag 
    public GameObject kula_demonetyzacji;
    public Sprite mag_dead_sprite;
    //Menu 
    public GameObject Menu;
    //Dialog
    public GameObject Dialog;
    //Sasin
    public Sprite sasin_dead_sprite;
    public GameObject sasin;
    //Pieseły 
    public GameObject Piesely;
    //Klatka 
    public GameObject klatka;
    //Czy wejście do bosa się odbyło ? 
    public bool czy_wszedl_do_komnaty_z_bosem = false;
    void Awake()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
