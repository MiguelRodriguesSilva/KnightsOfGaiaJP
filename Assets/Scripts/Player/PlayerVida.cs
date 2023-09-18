using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVida : MonoBehaviour
{
    public float vidaAtual, vidaMax;
    private VidaHUD hud;
    [SerializeField] float tempoInvuneravel;
    private Animator barraDeVida;
    private float contador;


    private void Awake()
    {
        hud = FindObjectOfType<VidaHUD>();
        barraDeVida = GameObject.Find("VidaPlayer").GetComponent<Animator>();
    }

    private void Start()
    {
        contador = 0;
    }

    private void FixedUpdate()
    {
        if (contador > tempoInvuneravel)
        {
            contador = tempoInvuneravel;
        }
        if (contador < tempoInvuneravel)
        {
            contador += Time.deltaTime;
        }
    }

    public void Curar(int vidaCurada)
    {
        vidaAtual += vidaCurada;
        VerificacaoVida();
    }

    public void SofrerDano(int dano)
    {
        if (!(contador < tempoInvuneravel))
        {
            vidaAtual -= dano;
            VerificacaoVida();
        }
        
    }

    public void AumentoVida(int aumentoVida)
    {

        vidaMax += aumentoVida;
        vidaAtual += aumentoVida;
        hud.TrocaPorcent();
    }

    void VerificacaoVida()
    {
        if (vidaAtual > vidaMax)
        {
            vidaAtual = vidaMax;
        }

        if (vidaAtual < 0)
        {
            vidaAtual = 0;
        }
    }
}
