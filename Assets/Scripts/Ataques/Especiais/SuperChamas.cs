using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperChamas : MonoBehaviour
{

    [SerializeField] PlayerVida vida;
    private GameObject player;
    [SerializeField] float tempoDoShiled;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.SetParent(player.transform);
        if (player.TryGetComponent<PlayerVida>(out PlayerVida Vida))
        {
            vida = Vida;
        }
        vida.estaComEscudo = true;
        StartCoroutine(TempoDoShield());

    }
    
    IEnumerator TempoDoShield()
    {
        yield return new WaitForSeconds(tempoDoShiled);
        vida.estaComEscudo = false;
        Destroy(this.gameObject);
    }


}
