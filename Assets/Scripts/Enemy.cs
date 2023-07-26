using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Vida")]
    public float LifeEnemy = 0;
    public float DanoSofrido = 0;
    float ultimoDano;
    public float TempoDano = 0;
    public bool podeSerDestruido = true;
    SpriteRenderer sprite;

    [Header("Movimentacao")]
    float velocidadeEnemy

    [Header("Barra de Vida")]
    public GameObject barraDaVida;
    public Transform barraVermelha;
    private Vector3 escalaBarra;
    private float porcentVida;

    // Start is called before the first frame update
    void Start()
    {
        Random.Range(2f,10f) = velocidadeEnemy;
        TempoDano = 0;
        DanoSofrido = 0;
        ultimoDano = DanoSofrido;
        sprite = GetComponent<SpriteRenderer>();
        escalaBarra = barraVermelha.localScale;
        porcentVida = escalaBarra.x / LifeEnemy;
    
    }

    private void OnDestroy() {
        Debug.Log("Teste");
    }

    void UpdateBarraDeVida(){

        if (escalaBarra.x < 0){
            escalaBarra.x = 0;            
        }

        barraVermelha.localScale = escalaBarra;
        
    }

    void MorteEnemy(){

        Destroy(this.gameObject);
    }

    void MovimentoEnemy(){

        
    }
    // Update is called once per frame
    void Update()
    {

        MovimentoEnemy

        if (LifeEnemy <= 0){

            MorteEnemy();
        }


        if (DanoSofrido != 0){
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
}
