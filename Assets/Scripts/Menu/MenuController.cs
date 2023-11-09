using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject comoJogar, menuInicial;

    public void ComecarJogo()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ComoJogar()
    {
        menuInicial.SetActive(false);
        comoJogar.SetActive(true);
    }

    public void Voltar()
    {
        menuInicial.SetActive(true);
        comoJogar.SetActive(false);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
