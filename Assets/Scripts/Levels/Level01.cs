using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level01 : MonoBehaviour
{
    [SerializeField] int[] quantiIinimigos;
    [SerializeField] ContagemInimigos conti;
    [SerializeField] TrocaCenario troca;
    private void Awake()
    {
        conti = GetComponent<ContagemInimigos>();
        troca = FindObjectOfType<TrocaCenario>();
    }
    private void Update()
    {
        if (quantiIinimigos[0] == conti.inimigos[0])
        {
            troca.TrocarLevel(2);
            conti.Reset();
            enabled = false;
        }
    }
}
