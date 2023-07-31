using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Corte : Ataques
{
    private float Nasceu;
    private SpriteRenderer SCorte;
    public bool JaFoiSpawnado;
    // Start is called before the first frame update
    void Start()
    {
        Dano = 15f;
        Constante = false;
        qualAtaque = "Corte";
        MudancaSprite();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > Nasceu){
            Destroy(this.gameObject);

        }
    }

    void MudancaSprite()
    {
        SCorte = GetComponent<SpriteRenderer>();
        Nasceu = Time.time + 0.3f;
        if (JaFoiSpawnado == true)
        {
            SCorte.flipY = true;
        }
        if (JaFoiSpawnado == false)
        {
            SCorte.flipY = false;
        }

    }
}
