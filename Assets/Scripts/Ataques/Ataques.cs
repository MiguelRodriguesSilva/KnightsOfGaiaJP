using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataques : MonoBehaviour
{
    [SerializeField] float dano, quantiEspecial;
    [SerializeField] string qualAtaque;
    [SerializeField] bool constante;
    private VidaEnemy inimigo;
    private PlayerAttack player;


    private void Awake()
    {
        player = FindObjectOfType<PlayerAttack>();
    }


    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Enemy")
        {
            inimigo = other.GetComponent<VidaEnemy>();
            if (inimigo != null)
            {
                if (constante == true)
                {
                    inimigo.Dano(dano * Time.deltaTime, qualAtaque);
                    player.specialATQConti += quantiEspecial * Time.deltaTime;

                }
                
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
          
        if (other.tag == "Enemy")
        {
            inimigo = other.GetComponent<VidaEnemy>();
            if (inimigo != null)
            {
                if (constante == false)
                {
                    inimigo.Dano(dano, qualAtaque);
                    player.specialATQConti += quantiEspecial;

                }
             
            }

        }
        
        
    }
}
