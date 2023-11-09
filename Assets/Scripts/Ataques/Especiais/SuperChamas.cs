using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperChamas : MonoBehaviour
{
    float TempoVivo = 0f;
    public float rotacao, limiteTempo = 4f;
    private float cont;
    [SerializeField] PlayerAction action;
    [SerializeField] PlayerMove move;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player.TryGetComponent<PlayerAction>(out PlayerAction actions))
        {
            action = actions;
        }
        if (player.TryGetComponent<PlayerMove>(out PlayerMove Move))
        {
            move = Move;
        }

    }
    void Start()
    {
        TempoVivo = Time.time + 1.2f;
        transform.parent = player.transform;
        rotacao = 1f;
        cont = 0;
        move.StartCoroutine("Velocidade");
    }


    void FixedUpdate()
    {
        cont += Time.deltaTime;
        rotacao = rotacao + 0.5f * Time.deltaTime;
        if (rotacao > 1.5f)
        {


            rotacao = 1.5f;
        }

        transform.Rotate(Vector3.back * (360 * rotacao) * Time.deltaTime);
        if (Time.time > TempoVivo)
        {
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

            Destroy(this.gameObject);

        }

        if (cont > limiteTempo)
        {
            Destroy(this.gameObject);
        }
    }

}
