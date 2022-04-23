using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_controller : MonoBehaviour
{
    Assets assets;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        assets = GameObject.Find("Assets").GetComponent<Assets>();
        Player = assets.Player;
    }

    public bool czy_obserwować_gracza = true;
    void Update()
    {
        //Patrz na Gracza
        if (czy_obserwować_gracza)
        {
            var dir = new Vector2(transform.position.x, transform.position.y);
            dir -= new Vector2(assets.Player.transform.position.x, assets.Player.transform.position.y);
            var kąt = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(-kąt, Vector3.forward);
        }
    }
}
