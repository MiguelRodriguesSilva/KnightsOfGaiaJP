using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jato : MonoBehaviour
{
    float TempoVivo;
    [SerializeField] float quantiEspecial;
    private PlayerAction action;
    private PlayerAttack player;


    private void Awake()
    {
        action = FindObjectOfType<PlayerAction>();
        player = FindObjectOfType<PlayerAttack>();
    }
    void Start()
    {
        TempoVivo = 0;
        transform.position = transform.position + new Vector3(0.5f,0,0);
        this.transform.parent = GameObject.Find("Jogador").transform;

    }


    void FixedUpdate()
    {
        player.specialATQConti += quantiEspecial * Time.deltaTime;
        TempoVivo = TempoVivo + 1 * Time.deltaTime;

        if (TempoVivo < 5f)
        {
            if (action.input.PlayerMove.Tiro.IsPressed())
            {

                if (transform.localScale.x >= 3)
                {
                    transform.localScale = new Vector3(3, transform.localScale.y, 1);
                }

                if (transform.localScale.x <= 3)
                {
                    transform.localScale = transform.localScale + new Vector3(3, 0, 0) * Time.deltaTime;
                }
            }
        }

        if (!action.input.PlayerMove.Tiro.IsPressed()){
            transform.localScale = transform.localScale + new Vector3(-4,0,0) * Time.deltaTime;
            
        }

        else if (TempoVivo > 5f)
        {
            transform.localScale = transform.localScale + new Vector3(-4, 0, 0) * Time.deltaTime;

        }
        if (transform.localScale.x <= 0){
                Destroy(this.gameObject);
            }

        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.R)){
            Destroy(this.gameObject);
        }
        
    }
}
