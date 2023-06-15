using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    // Definição das variaveis
    // teste github
    public float velocidade = 0.0f;
    public float reposicao = 15f;
    public Vector3 posicaoInicial;
    // Start is called before the first frame update
    void Start()
    {
        reposicao = 17.75f;
       posicaoInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float novaPosicao = Mathf.Repeat(Time.time * velocidade , reposicao );
        transform.position = posicaoInicial + Vector3.left * novaPosicao ;
    }
}
