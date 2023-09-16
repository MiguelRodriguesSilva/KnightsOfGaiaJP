using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoEnemy : MonoBehaviour
{
    private PlayerVida player;
    [SerializeField] int DanoAttack, DanoEncostar;


    private void Awake()
    {
        player = FindObjectOfType<PlayerVida>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.SofrerDano(DanoEncostar);
    }
}
