using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContagemInimigos : MonoBehaviour
{
    public int[] inimigos;
    // 0 = Abelhas robos

    public void Reset()
    {
        for (int i = 0; i < inimigos.Length; i++)
        {
            inimigos[i] = 0;
        }
        
    }
}
