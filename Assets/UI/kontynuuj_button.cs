using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kontynuuj_button : MonoBehaviour
{
    Assets assets;
    // Start is called before the first frame update
    void Start()
    {
        assets = GameObject.Find("Assets").GetComponent<Assets>();

        GetComponent<Button>().onClick.AddListener(kontynuuj);
    }

    void kontynuuj() 
    {
        assets.Menu.GetComponent<Menu_Controller>().unfreeze();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
