using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataques : MonoBehaviour
{
    public float Dano;
    public string qualAtaque;
    public bool Constante;
    private Enemy Inimigo;

    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Enemy"){
            Inimigo = other.GetComponent<Enemy>();
            if (Inimigo != null){
                if (Constante == true){
                    Inimigo.danoRecebido = Inimigo.danoRecebido + Dano * Time.deltaTime;
                    Inimigo.DanoSofrido = Inimigo.DanoSofrido + Dano * Time.deltaTime;
                    Inimigo.tipoAtaque = qualAtaque;

                }
                
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
          
        if (other.tag == "Enemy"){
            Inimigo = other.GetComponent<Enemy>();
            if (Inimigo != null){
                if (Constante == false){
                    Inimigo.danoRecebido = Inimigo.danoRecebido + Dano;
                    Inimigo.DanoSofrido = Inimigo.DanoSofrido + Dano;
                    Inimigo.tipoAtaque = qualAtaque;
                }
             
            }

        }
        
        
    }
}
