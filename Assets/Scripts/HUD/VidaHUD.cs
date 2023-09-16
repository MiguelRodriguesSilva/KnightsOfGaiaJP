using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaHUD : MonoBehaviour
{
    private PlayerVida player;
    private Vector2 tamanhoBase;
    private Transform barraVida;
    private float porcent;

    private void Awake()
    {
        player = FindObjectOfType<PlayerVida>();
        barraVida = GameObject.Find("BarraDeVidaPlayer").transform;
        tamanhoBase = GameObject.Find("BarraFundoPlayer").transform.localScale;
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
