using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AbelhaRobo : MonoBehaviour
{
    [SerializeField] float danoFerrao, danoEncostar, danoAvanco, tempoAcao;
    [SerializeField] GameObject ferrao;
    [SerializeField] GameObject posicaoFerrao;
    public bool podeAtirar = false;
    public float contiAcao = 0;
    private int qualAcao = 0;
    private DanoEnemy danoAbelha;

    private void Awake()
    {
        danoAbelha = GetComponent<DanoEnemy>();
        danoEncostar = danoAbelha.danoEncostar;
    }

    private void Start()
    {
        contiAcao = 0;
        
    }

    private void FixedUpdate()
    {
        contiAcao += Time.deltaTime;
        AcaoAbelha();

    }

    void AcaoAbelha()
    {
        
        if (contiAcao > tempoAcao)
        {
            if (qualAcao == 0)
            {
                qualAcao = Random.Range(1, 3);
            }
            if (qualAcao == 1)
            {
                AtirarFerrao();
            }

            if (qualAcao == 2)
            {
                AtacarAvanco();
            }

        }
    }

    public void AtirarFerrao()
    {
        GetComponent<Animator>().Play("AtirandoEspinho");
        if (podeAtirar == true)
        {
            Debug.Log("Atirou o ferrao");
            Vector3 player = FindObjectOfType<PlayerMove>().transform.position;
            Vector2 direction = (player - transform.position).normalized;
            GameObject ferraoInst;
            ferraoInst = Instantiate(ferrao, posicaoFerrao.transform.position, Quaternion.identity);
            ferraoInst.GetComponent<Enemy_AbelhaRobo_Ferrao>().direction = direction;
            podeAtirar = false;
            qualAcao = 0;
            contiAcao = 0;
            
        }
        
    }

    void AtacarAvanco()
    {
        Debug.Log("Avancou");
        qualAcao = 0;
        contiAcao = 0;
    }
}
