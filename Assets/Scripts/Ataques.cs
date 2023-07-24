using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataques : MonoBehaviour
{
    
    public float TipoAtaque = 1f;
    public Sprite Pedregulho;
    public Sprite Chamas;
    public Sprite Jato;
    public Sprite Corte;
    float TempoVivo = 0f;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(1,1,1);
        //TipoAtaque = Player.GetComponent<Player>().Element;
        if (TipoAtaque == 3){
            TempoVivo = Time.time + 0.3f;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Corte;
            transform.position = transform.position + new Vector3(2f,1f,0);
        }

        if (TipoAtaque == 2){
            transform.localScale = new Vector3(0,1,1);
            TempoVivo = Time.time + 0.3f;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Jato;
            transform.position = transform.position + new Vector3(2f,1f,0);
        }

        if (TipoAtaque == 1){

            this.gameObject.GetComponent<SpriteRenderer>().sprite = Pedregulho;
        }

        if (TipoAtaque == 0){
            transform.localScale = new Vector3(2,2,2);
            transform.position = transform.position + new Vector3(-1f,0,0);
            TempoVivo = Time.time + 1.2f;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Chamas;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (TipoAtaque == 1){
            //transform.Rotate(Vector3.back);
            transform.Translate(Vector3.right * 10 * Time.deltaTime);

            if ( transform.position.x > 10.5f){
            Destroy(this.gameObject);
         }    

        }

    
        if (TipoAtaque == 2){
            if (Input.GetKey(KeyCode.Space)){
                if ( transform.localScale.x < 1){

                    transform.localScale = transform.localScale + new Vector3(0.3f,0,0) * Time.deltaTime;
                }
            }
            
        }


        if (TipoAtaque == 3){

            if (Time.time > TempoVivo){
                Destroy(this.gameObject);
            }
        }

        if (TipoAtaque == 0){
            transform.Rotate(Vector3.back);
            if (Time.time > TempoVivo){
                Destroy(this.gameObject);
            }
        }



        //TipoAtaque = Player.GetComponent<Player>().Element;
        
        
        //TipoAtaque = Element;
    }
}
