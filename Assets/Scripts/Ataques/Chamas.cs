using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chamas : MonoBehaviour
{
    float TempoVivo = 0f;
    public float rotacao;
    private PlayerAction action;

    private void Awake()
    {
        action = FindObjectOfType<PlayerAction>();
    }
 
    void Start()
    {
        TempoVivo = Time.time + 1.2f;
        this.transform.parent = GameObject.Find("Jogador").transform;
        rotacao = 1f;
    }

    
    void FixedUpdate()
    {
        rotacao = rotacao + 0.5f * Time.deltaTime;
        if (rotacao > 1.5f){

            rotacao = 1.5f;
        }

        transform.Rotate(Vector3.back * (360 * rotacao) * Time.deltaTime);
        if (Time.time > TempoVivo){
            Destroy(this.gameObject);

        }


        if (action.input.PlayerMove.Tiro.IsPressed())
        {
                TempoVivo = Time.time + 1f;
        }


        if (action.input.TrocarElement.Agua.WasPressedThisFrame() || 
            action.input.TrocarElement.Folha.WasPressedThisFrame() || 
            action.input.TrocarElement.Pedra.WasPressedThisFrame())
        {

            TempoVivo = Time.time - 2f;
        
        }        
    }

}
