using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade = 0.0f ;
    public float entradaHorizontal ;
    public float entradaVertical ;

    public GameObject pfLaser ;
    public Sprite water;
    public Sprite fire;
    public Sprite leaf;
    public Sprite rock;
    public float Element = 0f;
    float Cooldown = 0f;
    //public SpriteRenderer spriteRenderer;
    //public Sprite newSprite;

    
    // Start is called before the first frame update
    void Start()
    {
        
        //spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Debug.Log("Start de "+this.name);
        velocidade = 8.0f ;
        transform.position = new Vector3(0,0,0);
        //m_SpriteRenderer = water;
    }


    // Update is called once per frame
    void Update()
    {
        MudancaSprite();

        entradaHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right*Time.deltaTime*velocidade*entradaHorizontal);

        if ( transform.position.x  > 9.85f) {
            transform.position = new Vector3(-9.85f,transform.position.y,0);
        }

        if ( transform.position.x  < -9.85f  ) {
            transform.position = new Vector3(9.85f,transform.position.y,0);
        
        }

        entradaVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up*Time.deltaTime*(velocidade/2)*entradaVertical);

        if ( transform.position.y  > 0 ) {
            transform.position = new Vector3(transform.position.x,0,0);
        }

        if ( transform.position.y  < -3.95f  ) {
            transform.position = new Vector3(transform.position.x,-3.95f,0);
        }

        if (Input.GetKeyDown(KeyCode.Space)){

            
            //Instantiate(pfLaser, transform.position + new Vector3(0,1.1f,0),Quaternion.identity);
        }

        if(Input.GetKeyDown(KeyCode.1)){
            if(Cooldown < Time.time){
                Element = 1;
                Cooldown = Time.time + 1;
            }
        }
        
        if(Input.GetKeyDown(KeyCode.2)){
            if (Cooldown < Time.time){
                Element = 2;
                Cooldown = Time.time + 1;
            }

        }

        if(Input.GetKeyDown(KeyCode.3)){
            if (Cooldown <= Time.time) {
                Element = 3;
                Cooldown = Time.time + 1;
            }
        }

        if(Input.GetKeyDown(KeyCode.4)){
            if (Cooldown <= Time.time) {
                Element = 0;
                Cooldown = Time.time + 1;
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