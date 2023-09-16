using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed;
    private PlayerAction action;
    private float x, y;
    private void Awake()
    {

        action = GetComponent<PlayerAction>();

    }

    private void FixedUpdate()
    {
        x = action.input.PlayerMove.Movimentacao.ReadValue<Vector2>().x;
        y = action.input.PlayerMove.Movimentacao.ReadValue<Vector2>().y;

        transform.Translate(new Vector2(x * 0.7f,y) * ( speed * Time.deltaTime * 0.5f));

    }
}
