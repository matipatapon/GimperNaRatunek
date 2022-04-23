using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class start_button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(nowa_gra);
        Debug.Log("Dodano");
    }

    // Update is called once per frame
    void nowa_gra()
    {
        Destroy(gameObject);
        SceneManager.LoadSceneAsync("SampleScene");
       
    }
}
