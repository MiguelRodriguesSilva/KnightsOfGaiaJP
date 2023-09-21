using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocaCenario : MonoBehaviour
{
    public static int levelAtual;
    [SerializeField] GameObject levelsController, arvores;
    [SerializeField] Level01 l1;

    private void Awake()
    {
        levelsController = GameObject.Find("Levels");
        l1 = levelsController.GetComponent<Level01>();
    }

    private void Start()
    {
        arvores.SetActive(false);
        levelAtual = 1;
    }
    public void TrocarLevel(int levelNovo)
    {
        levelAtual = levelNovo;
        if (levelAtual == 1)
        {
            arvores.SetActive(false);
            l1.enabled = true;
        }

        if (levelAtual == 2)
        {
            Debug.Log("Teoricamente deu certo");
        }

        if (levelAtual == 3)
        {
            arvores.SetActive(true);
        }
    }

    private void Update()
    {
        
    }
}
