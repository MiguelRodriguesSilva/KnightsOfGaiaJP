using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool andaReto = true;
    [SerializeField] bool zigizage = false;
    [SerializeField] float speedCimaBaixo = 1;
    [SerializeField] float CimaOuBaixo;
    [SerializeField] float tempoTroca;
    private float contador;

    private void FixedUpdate()
    {
        if (andaReto == true)
        {
            if (zigizage == false)
            {
                transform.Translate(Vector2.left * (speed * Time.deltaTime));
            }

            if (zigizage == true)
            {
                contador += Time.deltaTime;
                transform.Translate(Vector2.left * (speed * Time.deltaTime));
                transform.Translate((Vector2.up * CimaOuBaixo) * speedCimaBaixo * Time.deltaTime);

                if (contador > tempoTroca)
                {
                    contador = 0;
                    if (CimaOuBaixo == 1)
                    {
                        CimaOuBaixo = -1;
                    }else if (CimaOuBaixo == -1)
                    {
                        CimaOuBaixo = 1;
                    }
                }

            }
            
        }

        if (andaReto == false)
        {
            transform.Translate(new Vector2(1, CimaOuBaixo) * (speed * Time.deltaTime));
        }
    }
}
