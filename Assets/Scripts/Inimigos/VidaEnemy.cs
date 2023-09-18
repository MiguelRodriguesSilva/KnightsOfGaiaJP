using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemy : MonoBehaviour
{
    [SerializeField] float vidaMax, vidaAtual, resisQuant, fraqQuant;
    [SerializeField] string resisTipo, fraqTipo;
    [SerializeField] bool podeSerDestruido = true;

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
        
    }

    public void VerificacaoMorte()
    {
        if (podeSerDestruido == true)
        {
            if (vidaAtual < 0)
            {
                Destroy(this.gameObject);
            }

        }
        
    }
}
