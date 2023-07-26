using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataques : MonoBehaviour
{
    public float Dano;
    float cooldownzin;
    public string qualAtaque;
    public bool Constante;
    bool EstaDentro;
    Enemy Inimigo;


    // Start is called before the first frame update
    void Start()
    {
        cooldownzin = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Enemy"){
            Inimigo = other.GetComponent<Enemy>();
            if (Inimigo != null){
                if (Constante == true){
                    Inimigo.LifeEnemy = Inimigo.LifeEnemy - Dano * Time.deltaTime;
                    Inimigo.DanoSofrido = Inimigo.DanoSofrido + Dano * Time.deltaTime;

                }
                
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
          
        if (other.tag == "Enemy"){
            Inimigo = other.GetComponent<Enemy>();
            if (Inimigo != null){
                if (Constante == false){
                    Inimigo.LifeEnemy = Inimigo.LifeEnemy - Dano;
                    Inimigo.DanoSofrido = Inimigo.DanoSofrido + Dano;

                }

                //if (Constante == true){

              //      cooldownzin = cooldownzin + 1 * Time.deltaTime;
               // }
                
            }

        }
        
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        
    }
    
}
