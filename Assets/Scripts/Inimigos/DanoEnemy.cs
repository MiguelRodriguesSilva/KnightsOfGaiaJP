using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoEnemy : MonoBehaviour
{
    private PlayerVida player;
    public int danoAttack, danoEncostar;



    private void Awake()
    {
        player = FindObjectOfType<PlayerVida>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.SofrerDano(danoEncostar);
        }
        
    }
}
