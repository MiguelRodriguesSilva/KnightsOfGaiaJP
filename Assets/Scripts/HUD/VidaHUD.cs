using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaHUD : MonoBehaviour
{
    [SerializeField] PlayerVida player;
    private Vector2 tamanhoBase;
    [SerializeField] Transform barraVida;
    [SerializeField] Transform tamanhoBTrans;
    private float porcent;

    private void Awake()
    {
        tamanhoBase = tamanhoBTrans.localScale;
        porcent = tamanhoBase.x / player.vidaMax;
    }

    public void TrocaPorcent()
    {
        porcent = tamanhoBase.x / player.vidaMax;
    }

    private void FixedUpdate()
    {
        barraVida.localScale = new Vector2((porcent * player.vidaAtual), barraVida.localScale.y);

    }
}
