using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemy : MonoBehaviour
{
    [Header("Valores da Vida")]
    [SerializeField] bool podeSerDestruido = true;
    [SerializeField] public float vidaMax, vidaAtual, resisQuant, fraqQuant;
    [SerializeField] string resisTipo, fraqTipo;

    [Header("Identificacao")]
    [SerializeField] int indexInimigo;
    [SerializeField] public bool boss = false;
    [SerializeField] public bool estaMorto = false;
    public Sprite faceInimigo;
    public VidaInimigoHUD hud;


    private void Start()
    {
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
        hud.MostrarVida(boss, faceInimigo, vidaMax, vidaAtual);

    }

    public void VerificacaoMorte()
    {

        if (podeSerDestruido == true)
        {
            if (vidaAtual < 0 && estaMorto == false)
            {
                ContagemInimigos contagem = FindObjectOfType<ContagemInimigos>();
                contagem.inimigos[indexInimigo] += 1;
                contagem.Verificacao();
                vidaAtual = 0;
                estaMorto = true;
                //Destroy(this.gameObject);
            }
            if (vidaAtual < 0)
            {
                vidaAtual = 0;
            }

        }
        
    }
}
