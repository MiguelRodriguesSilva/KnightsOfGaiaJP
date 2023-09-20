using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Corte : MonoBehaviour
{
    private float Nasceu;
    [SerializeField] SpriteRenderer SCorte;
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
        Nasceu = Time.time + 0.3f;
        SCorte.flipY = JaFoiSpawnado;

    }
}
