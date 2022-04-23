using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;

using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class Weapon_Controller : MonoBehaviour
{

    public enum rodzaj_broni
    {
        brak,
        pistolet,
        nóż,
        banhammer,
        banhammer_shotgun,
    }
    //Zmiena mówi jaka jest obecnie zadeklarowana broń na wyposażeniu
    public rodzaj_broni broń = rodzaj_broni.brak;
    //Nr obecnej broni 
    public int nr_broń = 0;
    //Czas od ostatniego strzału 
    [SerializeField] float czas_od_ostatniego_strzału = 0;
    //Ilość amonicji w magazynku
    [SerializeField] private float ilość_amonicji_w_magazynku = 0;



    [Serializable]
    public class class_weapon
    {
        [SerializeField] public rodzaj_broni typ_broni;
        [SerializeField] public Sprite sprite;
        //Pocisk
        [SerializeField] public GameObject bullet;
        [SerializeField] public float cooldown;
        [SerializeField] public float reload_czas;
        [SerializeField] public float rozmiar_magazynka;
        [SerializeField] public float rozrzut_broni;
        [SerializeField] public int obrażenia;
        [SerializeField] public bool czy_pokazywać_ilość_amonicji;
        [SerializeField] public float impuls;

    }
    public List<class_weapon> bronie = new List<class_weapon>();

    private class_weapon weapon;



    void Start()
    {
        
        UI_ammo = GameObject.Find("Ammo");
        zmiana_broni(rodzaj_broni.banhammer);

    }
    bool R = false;
    void Update()
    {
        if (Time.timeScale == 0) return;
        //Tymczasowa obsługa zmiana broni 
        //if (Input.GetKeyDown(KeyCode.F1))
       // zmiana_broni(rodzaj_broni.banhammer);
        // if (Input.GetKeyDown(KeyCode.F2))
        //   zmiana_broni(rodzaj_broni.pistolet);
        //if (Input.GetKeyDown(KeyCode.F3))
        // zmiana_broni(rodzaj_broni.banhammer);


        //Akcja po kliknięciu przycisku myszy 
        if (Input.GetKey(KeyCode.Mouse0) && weapon.cooldown <= czas_od_ostatniego_strzału && ilość_amonicji_w_magazynku > 0 && !R)
        {
            
            switch (broń)
            {
                case rodzaj_broni.pistolet:
                    strzał();
                   

                    break;
                case rodzaj_broni.banhammer:
                    strzał();
                    break;
                case rodzaj_broni.banhammer_shotgun:
                    strzał();
                    break;
            }
        }
        //Liczy czas jaki minoł od ostatniego strzału 
        czas_od_ostatniego_strzału += Time.deltaTime;
        //Przeładowanie 
        if (Input.GetKey(KeyCode.R) && ilość_amonicji_w_magazynku != weapon.rozmiar_magazynka) R = true;
        if (ilość_amonicji_w_magazynku <= 0 || R) reload();

    }
    void strzał() 
    {
        //rozrzut 
        var x = transform.rotation;
        var y = Random.Range(-weapon.rozrzut_broni, weapon.rozrzut_broni);
        x.eulerAngles += new Vector3(0, 0, y);
        //Tworzy pocisk 
        var bullet = Instantiate(weapon.bullet, transform.position, x);
        bullet.GetComponent<bullet_controll>().obrażenia = weapon.obrażenia;
        bullet.GetComponent<bullet_controll>().impuls = weapon.impuls;
        czas_od_ostatniego_strzału = 0;
        ilość_amonicji_w_magazynku--;

        //
        aktualizuj_magazynek();
    }
    public void zmiana_broni(rodzaj_broni na_co_zmienić = rodzaj_broni.brak)
    {
        
        broń = na_co_zmienić;
        nr_broń = zwróć_nr_broń(broń);
        weapon = bronie[nr_broń];
        GetComponent<SpriteRenderer>().sprite = weapon.sprite;
        czas_od_ostatniego_strzału = weapon.cooldown;
        ilość_amonicji_w_magazynku = weapon.rozmiar_magazynka;
        
        //UI
        aktualizuj_magazynek();
        if(weapon.czy_pokazywać_ilość_amonicji) UI_ammo.SetActive(true);
        else UI_ammo.SetActive(false);

    }
    //Zwraca pod jakim numerem w liście znajduje się broń o danym typie 
    int zwróć_nr_broń(rodzaj_broni jaką_broń)
    {
        for (int i = 0; i < bronie.Count; i++)
        {
            if (bronie[i].typ_broni == jaką_broń)
            {
                return i;
            }
        }
        return 0;
    }
    [SerializeField] private float timer_reload = 0;
    void reload()
    {
        timer_reload += Time.deltaTime;
        aktualizuj_magazynek(true);
        if (timer_reload >= weapon.reload_czas)
        {
            ilość_amonicji_w_magazynku = weapon.rozmiar_magazynka;
            aktualizuj_magazynek();
            timer_reload = 0;
            R = false;
        }
    }
    //UI
    //Magazynek
    GameObject UI_ammo;
    void aktualizuj_magazynek(bool czy_reload = false) 
    {
        if (!weapon.czy_pokazywać_ilość_amonicji) return;
        if (!czy_reload)
            UI_ammo.GetComponent<Text>().text = ilość_amonicji_w_magazynku + " / " + weapon.rozmiar_magazynka;
        else
            UI_ammo.GetComponent<Text>().text = "przeładowywanie...";
    }
}
