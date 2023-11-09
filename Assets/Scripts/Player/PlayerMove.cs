using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] PlayerAction action;
    private float x, y;

    private void FixedUpdate()
    {
        x = action.input.PlayerMove.Movimentacao.ReadValue<Vector2>().x;
        y = action.input.PlayerMove.Movimentacao.ReadValue<Vector2>().y;

        transform.Translate(new Vector2(x * 0.7f,y) * ( speed * Time.deltaTime * 0.5f));

        if (transform.position.x < -8.2f)
        {
            transform.position = new Vector2(-8.2f, transform.position.y);
        }

        if (transform.position.x > 8.2f)
        {
            transform.position = new Vector2(8.2f, transform.position.y);
        }

        if (transform.position.y < -4.25f)
        {
            transform.position = new Vector2(transform.position.x, -4.25f);
        }

        if (transform.position.y > 2.81f)
        {
            transform.position = new Vector2(transform.position.x, 2.81f);
        }

    }

    public IEnumerator Velocidade()
    {
        speed = 30f;
        yield return new WaitForSeconds(7f);

        speed = 15f;
    }
}
