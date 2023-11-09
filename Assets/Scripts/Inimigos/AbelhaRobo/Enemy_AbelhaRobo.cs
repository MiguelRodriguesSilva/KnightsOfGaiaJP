using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_AbelhaRobo : MonoBehaviour
{
    [SerializeField] float danoFerrao, danoEncostar, danoAvanco, tempoAcao, acaocd;
    [SerializeField] GameObject ferrao;
    [SerializeField] GameObject posicaoFerrao;
    [SerializeField] float speedAbelha;
    public bool podeAtirar = false;
    public float contiAcao = 0;
    public int qualAcao = 0;
    [SerializeField] DanoEnemy danoAbelha;
    [SerializeField] Enemy_AbelhaRobo_Avanco avanco;
    [SerializeField] VidaEnemy vidaAbelha;
    [SerializeField] GameObject Smoke;
    [SerializeField] private MovEnemy movimento;
    private bool estaMorto = false;

    private void Awake()
    {
        danoEncostar = danoAbelha.danoEncostar;
    }

    private void Start()
    {
        contiAcao = 0;

        MudarTempo();
    }

    private void FixedUpdate()
    {
        contiAcao += Time.deltaTime;

        if (vidaAbelha.estaMorto == false)
        {
            AcaoAbelha();
        }
        

        if (vidaAbelha.estaMorto == true)
        {
            GetComponent<Animator>().Play("Morte");
            Smoke.SetActive(true);
            transform.Translate(Vector2.one * -1f * 3f * Time.deltaTime);
            if (transform.position.y < -6.3f)
            {
                Destroy(movimento);
                Destroy(avanco);
                Destroy(this.gameObject);
            }
        } 

    }

    private void Update()
    {
        if (vidaAbelha.estaMorto == true)
        {
            estaMorto = true;
            contiAcao = 0;
        }
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
                avanco.enabled = true;
            }

        }
    }

    public void AtirarFerrao()
    {
        GetComponent<Animator>().Play("AtirandoEspinho");
        if (podeAtirar == true)
        {
            Vector3 player = FindObjectOfType<PlayerMove>().transform.position;
            Vector2 direction = (player - transform.position).normalized;
            GameObject ferraoInst;
            ferraoInst = Instantiate(ferrao, posicaoFerrao.transform.position, Quaternion.identity);
            ferraoInst.GetComponent<Enemy_AbelhaRobo_Ferrao>().direction = direction;
            podeAtirar = false;
            MudarTempo();
            qualAcao = 0;
            contiAcao = 0;
            
        }
        
    }

    public void MudarTempo()
    {
        tempoAcao = Random.Range(acaocd - 2f, acaocd + 2f);
    }
}
