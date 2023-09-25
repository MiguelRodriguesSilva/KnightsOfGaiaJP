using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocaCenario : MonoBehaviour
{
    public static int levelAtual;
    [SerializeField] GameObject levelsController, arvores;
    [SerializeField] float velocSubindo;
    [SerializeField] BackGround ceu;
    [SerializeField] Level01[] levels;
    [SerializeField] SpawnerDeInimigos spawns;
    private float speedCeu;

    private void Awake()
    {
        levelsController = GameObject.Find("Levels");
    }

    private void Start()
    {
        arvores.SetActive(false);
        levelAtual = 1;
        speedCeu = ceu.velocidade;
    }
    public void TrocarLevel(int levelNovo)
    {
        levelAtual = levelNovo;
        if (levelAtual == 1)
        {
            arvores.SetActive(false);
            spawns.
        }

        if (levelAtual == 2)
        {
            Debug.Log("Teoricamente deu certo");
            StartCoroutine(Level2());
        }

        if (levelAtual == 3)
        {
            StartCoroutine(Level3());
            arvores.SetActive(true);
        }
        levelsController.GetComponent<ContagemInimigos>().ResetQuanti();
    }

    IEnumerator Level2()
    {
        while (transform.position.y > -13f)
        {
            transform.Translate(Vector2.down * velocSubindo * Time.deltaTime);
            ceu.velocidade += Time.deltaTime;
            if (ceu.velocidade > 3)
            {
                ceu.velocidade = 3;
            }
            yield return new WaitForSeconds(Time.deltaTime);
            
        }
    }

    IEnumerator Level3()
    {
        while (transform.position.y < 1f)
        {
            transform.Translate(Vector2.up * velocSubindo * Time.deltaTime);
            ceu.velocidade -= Time.deltaTime;
            if (ceu.velocidade < 0.1f)
            {
                ceu.velocidade = 0.1f;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    private void Update()
    {
        
    }
}
