using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chamas : Ataques
{
    float TempoVivo = 0f;
    public float rotacao;
    // Start is called before the first frame update
    void Start()
    {
        qualAtaque = "Chamas";
        Dano = 30f;
        Constante = true;
        transform.localScale = new Vector3(1.5f,1.5f,1.5f);
        TempoVivo = Time.time + 1.2f;
        this.transform.parent = GameObject.Find("Jogador").transform;
        rotacao = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        rotacao = rotacao + 0.5f * Time.deltaTime;
        if (rotacao > 1.5f){

            rotacao = 1.5f;
        }
        transform.Rotate(Vector3.back * (360 * rotacao) * Time.deltaTime);
        if (Time.time > TempoVivo){
            Destroy(this.gameObject);

        }
        if (Input.GetButton("Tiro")){
                TempoVivo = Time.time + 1f;
            }
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.E)){

            TempoVivo = Time.time - 2f;
        
        }        
    }

}
