using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Player : MonoBehaviour
{
    [Header("Movimento")]
    public float velocidade = 0.0f ;
    public float entradaHorizontal ;
    public float entradaVertical ;
    public float EstaAtirando;
    private Rigidbody2D CorpoElemento;
    private SpriteRenderer SpriteGeral;

    [Header("Objeto Tiros")]
    
    public GameObject Chamas;
    public GameObject Jato;
    public GameObject Pedregulho;
    public GameObject Corte;

    [Header("Sprite Jogador")]
    public Sprite water;
    public Sprite fire;
    public Sprite leaf;
    public Sprite rock;
    public float Element = 0f;
    float Cooldown = 0f;
    float[] podeDisparar = new float[4];

    float tempoJatoTotal;
    float tempoJato;
    bool jatoEstaVivo = false;


    // Start is called before the first frame update
    void Start()
    {
        podeDisparar[0] = Time.time;
        podeDisparar[1] = Time.time;
        podeDisparar[2] = Time.time;
        podeDisparar[3] = Time.time;
        
        Debug.Log("Start de "+this.name);
        velocidade = 8.0f ;
        transform.position = new Vector3(0,0,0);
        CorpoElemento = GetComponent<Rigidbody2D>();
        SpriteGeral = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        MudancaSprite();
        EstaAtirando = Input.GetAxisRaw("Tiro");

        entradaHorizontal = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right*Time.deltaTime*velocidade*entradaHorizontal);

        if ( transform.position.x  > 8f) {
            transform.position = new Vector3(8f,transform.position.y,0);
        }

        if ( transform.position.x  < -8f  ) {
            transform.position = new Vector3(-8f,transform.position.y,0);
        
        }

        entradaVertical = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.up*Time.deltaTime*(velocidade/1.2f)*entradaVertical);

        if ( transform.position.y  > 4.1f ) {
            transform.position = new Vector3(transform.position.x,4.1f,0);
        }

        if ( transform.position.y  < -4.1f  ) {
            transform.position = new Vector3(transform.position.x,-4.1f,0);
        }


        MudancaTiros();
            

    }

    private void MudancaSprite(){


        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Cooldown < Time.time)
            {
                Element = 1;
                Cooldown = Time.time + 0.7f;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Cooldown < Time.time)
            {
                Element = 2;
                Cooldown = Time.time + 0.7f;
            }

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Cooldown <= Time.time)
            {
                Element = 3;
                Cooldown = Time.time + 0.7f;
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Cooldown <= Time.time)
            {
                Element = 0;
                Cooldown = Time.time + 0.7f;
            }
        }



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

   private void MudancaTiros(){
    //Chamas
    if (Element == 0){
       if (Input.GetButton("Tiro")){

            
        if ( Time.time > podeDisparar[0] ){

        Instantiate(Chamas, transform.position + new Vector3(0,-0.2f,0), Quaternion.identity);
        podeDisparar[0] = Time.time + 1f;
                }
        podeDisparar[0] = Time.time + 1f;
            }
        }

    // Pedregulhos
    if (Element == 1){
       if (Input.GetButton("Tiro")){

            
        if ( Time.time > podeDisparar[1] ){

        Instantiate( Pedregulho, transform.position + new Vector3(0,0,0), Quaternion.identity);
        podeDisparar[1] = Time.time + 1f;

                }
            }
        }


    //Jato
    if (Element == 2){
            if (Input.GetButtonDown("Tiro")){  
                if (jatoEstaVivo == false){
                        Instantiate(Jato, transform.position + new Vector3(0,0,0), Quaternion.identity);
                        tempoJato = 0.2f;
                        jatoEstaVivo = true;
                        tempoJatoTotal = 0f;
                    }
            }

            tempoJatoTotal = tempoJatoTotal + 1 * Time.deltaTime;

            if (tempoJatoTotal < 5f)
            {
                if (Input.GetAxisRaw("Tiro") == 1)
                {
                    tempoJato = tempoJato + 3f * Time.deltaTime;
                    if (tempoJato > 3f)
                    {
                        tempoJato = 3f;
                    }
                }

                if (Input.GetAxisRaw("Tiro") == 0)
                {
                    tempoJato = tempoJato - 4f * Time.deltaTime;
                    if (tempoJato < 0f)
                    {
                        jatoEstaVivo = false;
                    }
                }
            }
            else if (tempoJatoTotal > 5f)
            {
                tempoJato = tempoJato - 4f * Time.deltaTime;
                if (tempoJato < -1f)
                {
                    jatoEstaVivo = false;
                }
            }
            
        }
        
    // Cortes
    if (Element == 3){
        if (Input.GetButton("Tiro")){
            if (Corte.GetComponent<Corte>().JaFoiSpawnado == false){
                if ( Time.time > podeDisparar[3] ){

                    Instantiate( Corte, transform.position + new Vector3(2,0,0), Quaternion.identity);
                    podeDisparar[3] = Time.time + 0.3f;
                    Corte.GetComponent<Corte>().JaFoiSpawnado = true;
                    }
                }

            if (Corte.GetComponent<Corte>().JaFoiSpawnado == true){
                if ( Time.time > podeDisparar[3] ){

                    Instantiate( Corte, transform.position + new Vector3(2,0,0), Quaternion.identity);
                    podeDisparar[3] = Time.time + 0.3f;
                    Corte.GetComponent<Corte>().JaFoiSpawnado = false;
                    }

                }
            }
        }
    } 
}