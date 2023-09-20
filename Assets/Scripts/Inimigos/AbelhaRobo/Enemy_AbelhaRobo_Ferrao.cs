using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AbelhaRobo_Ferrao : MonoBehaviour
{
    private DanoEnemy danoFerrao;
    public float danoDoFerrao, speed;
    public Vector2 direction;
    private Vector3 player;
    private void Awake()
    {
        danoFerrao = GetComponent<DanoEnemy>();
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerMove>().transform.position;
        player.z = 0;
        transform.right = -(player - transform.position);
    }


    private void FixedUpdate()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -9)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if(collision.GetComponent<Chamas>() == true)
            {
                Destroy(this.gameObject);
            }

            if (collision.tag == "Player")
            {
                this.gameObject.SetActive(false);
            }
        }
        
    }
}
