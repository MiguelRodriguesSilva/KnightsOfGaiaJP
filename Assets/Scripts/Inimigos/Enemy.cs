using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Vida")]
    public float originalLifeEnemy = 0;
    public float lifeAtual = 0;
    public float DanoSofrido = 0;
    public float danoRecebido = 0;
    public float danoSentido = 0;
    float ultimoDano;
    public float TempoDano = 0;
    public bool podeSerDestruido = true;
    SpriteRenderer sprite;

    [Header("Movimentacao")]
    public float velocidadeEnemy = 9f;
    public bool seraParado = false;
    public bool vaiMudarVelocidade = false;

    [Header("Barra de Vida")]
    public GameObject barraDaVida;
    public Transform barraVermelha;
    private Vector3 escalaBarra;
    private float porcentVida;

    [Header("Resistencia e Fraqueza")]
    public string resistenciaElemento;
    public float valorResistencia;
    public string fraquezaElemento;
    public float valorFraqueza;
    public string tipoAtaque;
    public float quantidadeEscudo;
    bool estaComEscudo;
    

    // Start is called before the first frame update
    void Start()
    {
        danoRecebido = 0;
        TempoDano = 0;
        DanoSofrido = 0;
        ultimoDano = DanoSofrido;
        sprite = GetComponent<SpriteRenderer>();
        escalaBarra = barraVermelha.localScale;
        lifeAtual = originalLifeEnemy;
        porcentVida = escalaBarra.x / lifeAtual;
        if (quantidadeEscudo > 0){

            estaComEscudo = true;
        }
    
    }

    private void OnDestroy() {
        Debug.Log("Teste");
    }

    void UpdateBarraDeVida(){

        if (escalaBarra.x < 0){
            escalaBarra.x = 0;            
        }

        escalaBarra.x = porcentVida * lifeAtual;
        barraVermelha.localScale = escalaBarra;
        
    }

    void MorteEnemy(){

        Destroy(this.gameObject);
    }

    void MovimentoEnemy(){
        if (seraParado == false){
            transform.Translate(Vector3.left * velocidadeEnemy * Time.deltaTime);

        }

        
    }
    // Update is called once per frame
    void Update()
    {
        MovimentoEnemy();
        CalculoDeDano();
        

        if (lifeAtual <= 0){

            MorteEnemy();
        }



        if (danoRecebido != 0){
            TempoDano = TempoDano + 1f * Time.deltaTime;
            UpdateBarraDeVida();

        }
        if (ultimoDano != DanoSofrido){

            sprite.color = Color.red;
            TempoDano = 0;
            ultimoDano = DanoSofrido;
        }
        if (TempoDano > 0.25f){

            sprite.color = Color.white;
        }

        if (TempoDano > 3f){

            DanoSofrido = 0;
            ultimoDano = DanoSofrido;
            TempoDano = 0;
        }

    }

    void CalculoDeDano () {
        if (tipoAtaque != resistenciaElemento && tipoAtaque != fraquezaElemento){

            lifeAtual = originalLifeEnemy - danoRecebido;
            Debug.Log("Ataque Normal");

        }

        if (tipoAtaque == resistenciaElemento){

            lifeAtual = originalLifeEnemy - (danoRecebido - (danoRecebido * (valorResistencia / 100)));
            Debug.Log("Ataque Com Resistencia");
        }

        if (tipoAtaque == fraquezaElemento){

            lifeAtual = originalLifeEnemy - (danoRecebido + (danoRecebido * (valorFraqueza / 100)));
            Debug.Log("Ataque Com Fraqueza");
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Player"){


        }
    }
}
