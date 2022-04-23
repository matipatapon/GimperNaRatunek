using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dialog_Controller : MonoBehaviour
{
    GameObject Dialog_UI;
    Text text;
    Image Postać;
    Text Nazwa;
    GameObject Kontynuacja_info;
    Assets assets;
    [Serializable]
    public class Postać_class 
    {
        public Sprite sprite;
        public string nazwa;
    }

    public List<Postać_class> Postacie = new List<Postać_class>();
    // Start is called before the first frame update
    void Start()
    {
        //Upewniam się że po śmierci Time.scale jest ustawiiony na 1 
        Time.timeScale = 1;

        assets = GameObject.Find("Assets").GetComponent<Assets>();
        Dialog_UI = GameObject.Find("Dialog_UI");
        text = Dialog_UI.transform.GetChild(1).GetComponent<Text>();
        Postać = Dialog_UI.transform.GetChild(2).GetComponent<Image>();
        Nazwa = Dialog_UI.transform.GetChild(3).GetComponent<Text>();
        Kontynuacja_info = Dialog_UI.transform.GetChild(4).gameObject;

    }

    public int który_dialog = 0;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.timeScale);
        //Jeśli menu jest włączone nic nie rób ! 
        if (assets.Menu.GetComponent<Menu_Controller>().czy_menu) return;
        dialog(który_dialog);
    }

    

    void dialog(int który = 0) 
    {


        if (który == 0) 
        {
        
            Dialog_UI.SetActive(false);
            return;
        } 
        string kwestia = "";
        bool space = Input.GetKeyDown(KeyCode.Space);
        //Wstrzymanie rozgrywki 
        Time.timeScale = 0;
        switch (który) 
        {
            case 1 :
                Postać.sprite = Postacie[0].sprite;
                Nazwa.text = Postacie[0].nazwa;
                kwestia = "W końcu namierzyliśmy kryjówkę Sasina.\n\nNajprawdopodobniej tam przetrzymywane są twoje psy !";
                if (space )
                {
                    który_dialog++;

                }
                break;
            case 2:
                Postać.sprite = Postacie[0].sprite;
                Nazwa.text = Postacie[0].nazwa;
                kwestia = "Armia koto-hejterów pilnuje całego podwórka uważaj\n\nTo są elitarni żołnierze a ponad to znają starożytne zaklęcie demonetyzacji !";
                if (space)
                {
                    który_dialog++;

                }
                break;
            case 3:
                Postać.sprite = Postacie[1].sprite;
                Nazwa.text = Postacie[1].nazwa;
                kwestia = "Spokojnie dzięki mojemu Banhammerowi zbanuje ich wszystkie multikonta.\n\nUniemożliwi im to rzucania tego czaru.";
                if (space)
                {
                    który_dialog++;

                }
                break;
            case 4:
                Postać.sprite = Postacie[0].sprite;
                Nazwa.text = Postacie[0].nazwa;
                kwestia = "Pamiętaj ! \nWASD - poruszanie się.\nShift - sprint(tylko do przodu)\nR - przeładowywanie.\nLewy przycisk myszy - strzał (można przytrzymać)\nESC - menu\nNiektórzy o tym zapominają !";
                if (space)
                {
                    który_dialog++;

                }
                break;
            case 5:
                Postać.sprite = Postacie[1].sprite;
                Nazwa.text = Postacie[1].nazwa;
                kwestia = "Wiem spokojnie.\n\nDam sobie radę !";
                if (space )
                {
                    który_dialog++;
                }
                break;
            case 6:
                Postać.sprite = Postacie[0].sprite;
                Nazwa.text = Postacie[0].nazwa;
                kwestia = "Powodzenia !\n\nBędę zabezpieczał tyły gdy ty będziesz włamywał się do rezydencji ...\n\ni będę mówił policji że wszystko gra !";
                if (space) 
                {
                    który_dialog = 0;
                    Time.timeScale = 1;
                }
                break;

            //Wejście do domu
            case 10:
                Postać.sprite = Postacie[3].sprite;
                Nazwa.text = Postacie[3].nazwa;
                kwestia = "Proszę proszę któż to w końcu raczył się zjawić !\n\nWidzę że pokonałeś moją armię !\n\nAle ze mną nie pójdzie ci tak łatwo !";
                if (space)
                {
                    który_dialog++;

                }
                break;
            case 11:
                Postać.sprite = Postacie[1].sprite;
                Nazwa.text = Postacie[1].nazwa;
                kwestia = "Czemu porwałeś moje psy ?!?!?!";
                if (space)
                {
                    który_dialog++;

                }
                break;
            case 12:
                Postać.sprite = Postacie[3].sprite;
                Nazwa.text = Postacie[3].nazwa;
                kwestia = "Ponieważ nie mam nic lepszego do roboty !!!\n\nBUHAHAHAHAHA!!!!";
                if (space)
                {
                    który_dialog++;

                }
                break;
            case 13:
                Postać.sprite = Postacie[3].sprite;
                Nazwa.text = Postacie[3].nazwa;
                kwestia = "Dodatkowo dodam iż twój banhammer na mnie nie zadziała !\n\nJuż mnie zbanowali na wszystkich możliwych serwisach !\n\nAle nadal mogę zdemonetyzować twój kanał !";
                if (space)
                {
                    który_dialog++;

                }
                break;
            case 14:
                Postać.sprite = Postacie[1].sprite;
                Nazwa.text = Postacie[1].nazwa;
                kwestia = "Przygotowałem się na taki rozwój sytuacji !\n\n(Gimper dobywa pistolet)";
                if (space)
                {
                    assets.Player.GetComponent<Player_Controller>().HP = assets.Player.GetComponent<Player_Controller>().HP_START;
                    assets.Weapon.GetComponent<Weapon_Controller>().zmiana_broni(Weapon_Controller.rodzaj_broni.pistolet);
                    assets.czy_wszedl_do_komnaty_z_bosem = true;
                    assets.sasin.GetComponent<CircleCollider2D>().enabled = true;
                    który_dialog = 0;
                    Time.timeScale = 1;

                }
                break;
                //Pokonanie sasina ! 
            case 100:
                Postać.sprite = Postacie[1].sprite;
                Nazwa.text = Postacie[1].nazwa;
                kwestia = "Niepotrzebnie porywałeś moje psy !";
                if (space)
                {
                    assets.Player.GetComponent<Player_Controller>().HP = assets.Player.GetComponent<Player_Controller>().HP_START;
                    assets.Piesely.GetComponent<CircleCollider2D>().enabled = true;
                    assets.klatka.gameObject.SetActive(false);
                    który_dialog = 0;
                    Time.timeScale = 1;
                }
                break;
            case 200:
                Postać.sprite = Postacie[1].sprite;
                Nazwa.text = Postacie[1].nazwa;
                kwestia = "Wracajmy do domu.";
                if (space) 
                {
                    SceneManager.LoadSceneAsync("Menu");
                }
                break;
            //Po co robić osobny system śmierći jeśli można wykorzystać to co już jest ? 
            case 999:
                Postać.sprite = Postacie[2].sprite;
                Nazwa.text = Postacie[2].nazwa;
                kwestia = "Nie podawaj się !\n\nOżywię cię !!!\n\nMusisz uratować swoje psy !";
                if(space) 
                {
                    SceneManager.LoadSceneAsync("Menu");
                }
                break;
        }
       
        Dialog_UI.SetActive(true);
        text.text = wypisz_text(kwestia);
    }
    //Co ile ma się pojawiać 1 litera ?
    public float przerwa_text = 0.2f;
    //Która obecnie litera jest wypisywana ? 
    int litera = 1;
    //ile mineło od czasu wypisania ostatniej litery 
    float przerwa_timer = 0;

    string kwestia_buffor = "";
    //Jeśli zdanie się zmieniło zresetuj litere 
    string ostatni_string = "";
    //Zmiena upewnia się żeby gracz nie pominoł niechcący napisów 
    //bool czy_można_kontynuować = false;
    string wypisz_text(string kwestia) 
    {
        if (ostatni_string != kwestia) litera = 1;
        przerwa_timer += Time.unscaledDeltaTime;
        if (przerwa_timer > przerwa_text)
        {
            kwestia_buffor = "";
            for (int i = 0; i < litera; i++)
            {
                kwestia_buffor += kwestia[i];
            }
            
           
            litera++;
            przerwa_timer = 0;
            if (litera > kwestia.Length) 
            {
                litera = kwestia.Length;
                Kontynuacja_info.GetComponent<Text>().text = "Naciśnij spacje aby kontynuować";
            
            }
            else
            {
                kwestia_buffor += " I ";
                Kontynuacja_info.GetComponent<Text>().text = "Naciśnij spacje aby pominąć";
         
            }
        }
        ostatni_string = kwestia;
        return kwestia_buffor;
    }
}
