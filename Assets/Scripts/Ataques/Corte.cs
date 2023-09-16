using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Corte : MonoBehaviour
{
    private float Nasceu;
    private SpriteRenderer SCorte;
    static bool JaFoiSpawnado = false;

    void Start()
    {
        MudancaSprite();
    }

    void Update()
    {
        if (Time.time > Nasceu)
        {

            if (JaFoiSpawnado == false)
            {
                JaFoiSpawnado = true;
            }
            else
            {
                JaFoiSpawnado = false;
            }

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
