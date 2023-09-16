using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AguaPlus : MonoBehaviour
{
    private PlayerVida player;
    [SerializeField] int curaTotal, curaPorSegundo;
    private float cura;

    private void Awake()
    {
        player = FindObjectOfType<PlayerVida>();
    }

    private void Start()
    {
        StartCoroutine(VidaPorSegundo());
    }

    IEnumerator VidaPorSegundo()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i <= curaTotal; i++)
        {
            player.Curar(curaPorSegundo);
            yield return new WaitForSeconds(0.05f);

        }
        Destroy(this.gameObject);
    }
}
