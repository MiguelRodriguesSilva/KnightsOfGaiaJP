using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tufao : MonoBehaviour
{
    [SerializeField] float contador, limiteVida, veloc;
    [SerializeField] GameObject inimigo;
    Vector2 distance;

    private void Start()
    {
        if (FindObjectOfType<VidaEnemy>() == true)
        {
            inimigo = FindObjectOfType<VidaEnemy>().gameObject;
        }
        else
        {
            distance = Vector2.right;
        }

    }

    private void FixedUpdate()
    {
        contador += Time.deltaTime;
        if (inimigo != null)
        {
            distance = (inimigo.transform.position - transform.position).normalized;
        }
        transform.Translate(distance * Time.deltaTime * veloc);
    }

    private void Update()
    {
        if (inimigo == null)
        {
            if (FindObjectOfType<VidaEnemy>() == true)
            {
                inimigo = FindObjectOfType<VidaEnemy>().gameObject;
            }
            
        }

        if (contador > limiteVida)
        {
            Destroy(this.gameObject);
        }
    }
}
