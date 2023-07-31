using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedregulho : Ataques
{
    // Start is called before the first frame update
    void Start()
    {
        Dano = 32;
        Constante = false;
        qualAtaque = "Pedregulho";
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * 20 * Time.deltaTime);

            if ( transform.position.x > 10.5f){
            Destroy(this.gameObject);
        }
    
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.tag == "Enemy"){

            Destroy(this.gameObject);
        }
    }
}
