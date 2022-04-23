using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exit_button : MonoBehaviour
{
    //Assets assets;
    // Start is called before the first frame update
    void Start()
    {
        //assets = GameObject.Find("Assets").GetComponent<Assets>();
        GetComponent<Button>().onClick.AddListener(exit);
    }

    void exit()
    {
        Debug.Log("Welcmome");
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
