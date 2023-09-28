using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataques : MonoBehaviour
{
    [SerializeField] float dano, quantiEspecial;
    [SerializeField] string qualAtaque;
    [SerializeField] bool constante;
    private VidaEnemy inimigo;
    [SerializeField] PlayerAttack player;

    private void Awake()
    {
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
        if (playerGO.TryGetComponent<PlayerAttack>(out PlayerAttack pa))
        {
            player = pa;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Enemy")
        { 
            if (other.TryGetComponent<VidaEnemy>(out VidaEnemy inimigo))
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
            if (other.TryGetComponent<VidaEnemy>(out VidaEnemy inimigo))
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
