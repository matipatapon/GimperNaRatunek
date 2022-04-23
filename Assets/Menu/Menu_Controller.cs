using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject Menu_UI;

    public bool czy_menu = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (!czy_menu)
            {
                Time.timeScale = 0;
                Debug.Log("Freeze");
                czy_menu = true;
                Menu_UI.SetActive(true);
            }
            else 
            {
                unfreeze();
            }
        }
    }
    public  void unfreeze() 
    {
        Time.timeScale = 1;
        czy_menu = false;
        Menu_UI.SetActive(false);
    }
}
