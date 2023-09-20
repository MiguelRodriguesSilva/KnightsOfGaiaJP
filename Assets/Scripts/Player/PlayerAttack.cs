using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] int tipoElemento = 0;
    /*0 = fogo
     * 1 = rocha
     * 2 = agua
     * 3 = folha*/

    public GameObject[] tipoAtaque, ataqueEspecial, ataqueNormal;
    private PlayerAction action;
    private float trocaCont, tiroCont;
    [SerializeField] float[] cooldownTiros;
    public bool podeAtirar = true;
    [SerializeField] GameObject tiro;
    private SpriteRenderer sr;
    [SerializeField] Sprite[] srElements;

    [SerializeField] float specialAttack;
    private GameObject barraAttackPai;
    private Transform barraAttack;
    private float porcent;
    public float specialATQConti;
    private bool tiroEspecial = false;


    private void Awake()
    {
        podeAtirar = true;
        action = FindObjectOfType<PlayerAction>();
        sr = GetComponent<SpriteRenderer>();

        barraAttackPai = GameObject.Find("BarraAttackPai");
        barraAttack = GameObject.Find("BarraAttack").transform;
        porcent = barraAttack.localScale.x / specialAttack;
    }

    private void Start()
    {
        specialATQConti = 0;
    }

    private void Update()
    {
        TrocaDeElemento();

        TiroPlayer();

        BarraAttackEspecial();
    }

    void TrocaDeElemento()
    {
        trocaCont += Time.deltaTime;
        if (trocaCont > 1f)
        {
            if (action.input.TrocarElement.Fogo.IsPressed())
            {
                tipoElemento = 0;
                trocaCont = 0;
            }

            if (action.input.TrocarElement.Pedra.IsPressed())
            {
                tipoElemento = 1;
                trocaCont = 0;
            }

            if (action.input.TrocarElement.Agua.IsPressed())
            {
                tipoElemento = 2;
                trocaCont = 0;
            }

            if (action.input.TrocarElement.Folha.IsPressed())
            {
                tipoElemento = 3;
                trocaCont = 0;
            }

            sr.sprite = srElements[tipoElemento];
        }
    }

    void TiroPlayer()
    {
        tiroCont += Time.deltaTime;
        if (action.input.PlayerMove.Tiro.WasPressedThisFrame())
        { 
            if (tiroCont > cooldownTiros[tipoElemento])
            {
                if (podeAtirar == true)
                {

                    if (tiroEspecial == false)
                    {
                        tiro = Instantiate(tipoAtaque[tipoElemento], transform.position, Quaternion.identity);
                        tiroCont = 0;
                        if (!(tipoElemento == 1))
                        {
                            podeAtirar = false;
                        }
                    }

                    if (tiroEspecial == true)
                    {
                        GameObject ataqueMudado = tipoAtaque[tipoElemento];
                        int qualElementoMudado = tipoElemento;
                        tipoAtaque[tipoElemento] = ataqueEspecial[tipoElemento];
                        tiro = Instantiate(tipoAtaque[tipoElemento], transform.position, Quaternion.identity);
                        podeAtirar = false;
                        tipoAtaque[qualElementoMudado] = ataqueMudado;
                        tiroEspecial = false;
                        specialATQConti = 0;
                    }
                    
                        
                }
                
            }

        }

        if (tiro == null)
        {
            podeAtirar = true;
        }

        if (tiro != null)
        {
            if (tiro.GetComponent<AguaPlus>() == true)
            {
            tiro = null;
            }
        }
        
    }

    void BarraAttackEspecial()
    {
        barraAttack.localScale = new Vector2(porcent * specialATQConti, barraAttack.localScale.y);

        if (specialATQConti <= 0)
        {
            barraAttackPai.SetActive(false);
        }
        else
        {
            barraAttackPai.SetActive(true);
        }


        if (specialATQConti > specialAttack)
        {
            specialATQConti = specialAttack;
        }


        if (specialATQConti == specialAttack)
        {
            tiroEspecial = true;
        }

    }

}
