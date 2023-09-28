using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContagemInimigos : MonoBehaviour
{
    public int[] inimigos, inimNecessario;
    private int level;
    [SerializeField] TrocaCenario troca;
    // 0 = Abelhas robos

    private void Start()
    {
        level = 1;
    }
    public void Verificacao()
    {
        int value = 0;
        for (int i = 0; i < inimigos.Length; i++)
        {
            if (inimigos[i] == inimNecessario[i])
            {
                value += 1;
            }
        }
        if (value == inimigos.Length)
        {
            level += 1;
            troca.TrocarLevel(level);
        }
    }

    public void ResetQuanti()
    {
        for (int i = 0; i < inimigos.Length; i++)
        {
            inimigos[i] = 0;
        }
        
    }
}
