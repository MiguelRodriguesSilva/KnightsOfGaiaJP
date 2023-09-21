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
        
       posicaoInicial = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*float novaPosicao = Mathf.Repeat(Time.time * velocidade , reposicao );
        transform.position = posicaoInicial + Vector3.left * novaPosicao ;*/

        transform.Translate(Vector2.left * velocidade * Time.deltaTime);

        if (transform.position.x < posicaoInicial.x - reposicao)
        {
            transform.position = new Vector2(posicaoInicial.x, transform.position.y);
        }
    }
}
