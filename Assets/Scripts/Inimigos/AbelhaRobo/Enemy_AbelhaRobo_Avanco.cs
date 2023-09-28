using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AbelhaRobo_Avanco : MonoBehaviour
{
    [SerializeField] float Avanco;
    private bool possoAvancar = false;
    private bool possoRecuar = false;
    private Vector3 player, direction, posicaoInicial;
    [SerializeField] Enemy_AbelhaRobo controller;

    private void OnEnable()
    {
        possoAvancar = false;
        possoRecuar = false;
        player = FindObjectOfType<PlayerMove>().transform.position;
        posicaoInicial = transform.position;
        GetComponent<Animator>().Play("PreparandoAtaque");
        StartCoroutine(EsperaAtaque());
    }

    IEnumerator EsperaAtaque()
    {
        yield return new WaitForSeconds(0.6f);
        direction = (player - new Vector3(0,-0.5f,0) - transform.position).normalized;
        GetComponent<Animator>().Play("Atacando");
        possoAvancar = true;

    }

    private void FixedUpdate()
    {
        if (possoAvancar == true)
        {
            transform.Translate(direction * (Avanco * Time.deltaTime));
            if (transform.position.x < -9.5f)
            {
                possoAvancar = false;
                StartCoroutine(EsperaRecuar());
            }
        }

        if (possoRecuar == true)
        {
            transform.Translate(direction * (7 * Time.deltaTime));
            if (transform.position.x > posicaoInicial.x)
            {
                controller.MudarTempo();
                controller.contiAcao = 0;
                controller.qualAcao = 0;
                GetComponent<Animator>().Play("DepoisDeRetornar");
                enabled = false;
            }
        }
    }

    IEnumerator EsperaRecuar()
    {
        yield return new WaitForSeconds(2f);
        GetComponent<Animator>().Play("Retornando");
        direction = (posicaoInicial - transform.position).normalized;
        possoRecuar = true;

    }
}
