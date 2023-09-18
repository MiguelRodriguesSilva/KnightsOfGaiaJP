using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AbelhaRobo_Ferrao : MonoBehaviour
{
    private DanoEnemy danoFerrao;
    public float danoDoFerrao, speed;
    public Vector2 direction;

    private void Awake()
    {
        danoFerrao = GetComponent<DanoEnemy>();
    }

    private void FixedUpdate()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
