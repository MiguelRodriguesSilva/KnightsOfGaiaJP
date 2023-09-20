using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemy : MonoBehaviour
{
    [Header("Valores da Vida")]
    [SerializeField] bool podeSerDestruido = true;
    [SerializeField] float vidaMax, vidaAtual, resisQuant, fraqQuant;
    [SerializeField] string resisTipo, fraqTipo;

    [Header("Identificacao")]
    [SerializeField] string qualInimigo;
    [SerializeField] bool boss = false;
    public Sprite faceInimigo;
    [SerializeField] VidaInimigoHUD hud;

    private void Start()
    {
        hud = FindObjectOfType<VidaInimigoHUD>();
        vidaAtual = vidaMax;
    }

    public void Dano(float dano, string tipoDano)
    {
        if (tipoDano == resisTipo)
        {
            vidaAtual -= dano - (dano * (resisQuant / 100));
        }

        if (tipoDano == fraqTipo)
        {
            vidaAtual -= dano + (dano * (fraqQuant / 100));
        }

        if ((tipoDano != fraqTipo && tipoDano != resisTipo) || (resisTipo == "" && fraqTipo == ""))
        {
            vidaAtual -= dano;
        }
        VerificacaoMorte();
        hud.MostrarVida(boss, qualInimigo, faceInimigo, vidaMax, vidaAtual);

    }

    public void VerificacaoMorte()
    {

        if (podeSerDestruido == true)
        {
            if (vidaAtual < 0)
            {
                vidaAtual = 0;
                Destroy(this.gameObject);
            }

        }
        
    }
}
