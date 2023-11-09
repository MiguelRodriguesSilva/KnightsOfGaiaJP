using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaCenario : MonoBehaviour
{
    public static int levelAtual;
    [SerializeField] GameObject levelsController, arvores;
    [SerializeField] float velocSubindo;
    [SerializeField] int[] l1, l2, l3;
    [SerializeField] BackGround ceu;
    [SerializeField] SpawnerDeInimigos spawns;
    [SerializeField] ContagemInimigos conti;
    private float speedCeu;

    private void Start()
    {
        arvores.SetActive(false);
        levelAtual = 1;
        TrocarLevel(1);
        speedCeu = ceu.velocidade;
    }
    public void TrocarLevel(int levelNovo)
    {
        levelAtual = levelNovo;
        if (levelAtual == 1)
        {
            arvores.SetActive(false);
            spawns.inimigosRestantes[0] = l1[0];
            conti.inimNecessario[0] = l1[0];

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
        if (levelAtual == 4)
        {
            StartCoroutine(FinalDoJogo());

        }
        levelsController.GetComponent<ContagemInimigos>().ResetQuanti();
    }

    IEnumerator Level2()
    {
        while (transform.position.y > -14.4f)
        {
            transform.Translate(Vector2.down * velocSubindo * Time.deltaTime);
            ceu.velocidade += Time.deltaTime;
            if (ceu.velocidade > 3)
            {
                ceu.velocidade = 3;
            }
            yield return new WaitForSeconds(Time.deltaTime);
            
        }
        for (int i = 0; i < l2.Length; i++)
        {
            spawns.inimigosRestantes[i] = l2[i];
            conti.inimNecessario[i] = l2[i];

        }
        
    }

    IEnumerator Level3()
    {
        while (transform.position.y < -0.7f)
        {
            transform.Translate(Vector2.up * velocSubindo * Time.deltaTime);
            ceu.velocidade -= Time.deltaTime;
            if (ceu.velocidade < 0.1f)
            {
                ceu.velocidade = 0.1f;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }

        for (int i = 0; i < l2.Length; i++)
        {
            spawns.inimigosRestantes[i] = l3[i];
            conti.inimNecessario[i] = l3[i];

        }
    }

    IEnumerator FinalDoJogo()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Final");
    }
}
