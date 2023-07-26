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
    SpriteRenderer sprite;

    [Header("Barra de Vida")]
    public GameObject barraDaVida;
    public Transform barraVermelha;
    private Vector3 escalaBarra;
    private float porcentVida;

    // Start is called before the first frame update
    void Start()
    {
        TempoDano = 0;
        DanoSofrido = 0;
        ultimoDano = DanoSofrido;
        sprite = GetComponent<SpriteRenderer>();
        escalaBarra = barraVermelha.localScale;
        porcentVida = escalaBarra.x / LifeEnemy;
    }


    void UpdateBarraDeVida(){

        escalaBarra.x = LifeEnemy * porcentVida;
        if (escalaBarra.x < 0){

            escalaBarra.x = 0;
        }
        barraVermelha.localScale = escalaBarra;
        
    }
    // Update is called once per frame
    void Update()
    {
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
