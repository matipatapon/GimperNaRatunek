using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    public int HP = 1000;
    public int Max_HP = 1000;
    // Start is called before the first frame update
    void Start()
    {
        HP = Max_HP;
    }

 
}
