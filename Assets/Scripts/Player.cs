using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade = 0.0f ;
    public float entradaHorizontal ;
    public float entradaVertical ;

    public GameObject Ataque;
    public Sprite water;
    public Sprite fire;
    public Sprite leaf;
    public Sprite rock;
    public float Element = 0f;
    float Cooldown = 0f;
    float podeDisparar = 0f;
    //public SpriteRenderer spriteRenderer;
    //public Sprite newSprite;

    
    // Start is called before the first frame update
    void Start()
    {
        
        //spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Debug.Log("Start de "+this.name);
        velocidade = 8.0f ;
        transform.position = new Vector3(0,0,0);
        podeDisparar = Time.time;
        //m_SpriteRenderer = water;
    }


    // Update is called once per frame
    void Update()
    {
        MudancaSprite();

        entradaHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right*Time.deltaTime*velocidade*entradaHorizontal);

        if ( transform.position.x  > 8f) {
            transform.position = new Vector3(8f,transform.position.y,0);
        }

        if ( transform.position.x  < -8f  ) {
            transform.position = new Vector3(-8f,transform.position.y,0);
        
        }

        entradaVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up*Time.deltaTime*(velocidade/1.2f)*entradaVertical);

        if ( transform.position.y  > 4.1f ) {
            transform.position = new Vector3(transform.position.x,4.1f,0);
        }

        if ( transform.position.y  < -4.1f  ) {
            transform.position = new Vector3(transform.position.x,-4.1f,0);
        }

        if (Input.GetKeyDown(KeyCode.Space)){

            
            //Instantiate(pfLaser, transform.position + new Vector3(0,1.1f,0),Quaternion.identity);
        }

        if(Input.GetKeyDown(KeyCode.Q)){
            if(Cooldown < Time.time){
                Element = 1;
                Cooldown = Time.time + 0.7f;
            }
        }
        
        if(Input.GetKeyDown(KeyCode.E)){
            if (Cooldown < Time.time){
                Element = 2;
                Cooldown = Time.time + 0.7f;
            }

        }

        if(Input.GetKeyDown(KeyCode.R)){
            if (Cooldown <= Time.time) {
                Element = 3;
                Cooldown = Time.time + 0.7f;
            }
        }

        if(Input.GetKeyDown(KeyCode.F)){
            if (Cooldown <= Time.time) {
                Element = 0;
                Cooldown = Time.time + 0.7f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ){

            
            if ( Time.time > podeDisparar ){

            Instantiate( Ataque, transform.position + new Vector3(1f,0,0), Quaternion.identity);
            podeDisparar = Time.time + 1f;

            
        }
        }

   }

    private void MudancaSprite(){

       if (Element == 0){
           this.gameObject.GetComponent<SpriteRenderer>().sprite = fire;
       }

        if (Element == 1){
           this.gameObject.GetComponent<SpriteRenderer>().sprite = rock;
       }

        if (Element == 2){
           this.gameObject.GetComponent<SpriteRenderer>().sprite = water;
       }

        if (Element == 3){
           this.gameObject.GetComponent<SpriteRenderer>().sprite = leaf;
       }
   }    
}