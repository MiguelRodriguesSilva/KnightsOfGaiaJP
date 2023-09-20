using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaInimigoHUD : MonoBehaviour
{
    [SerializeField] Transform barraFundo, barraVida;
    [SerializeField] Image faceInimigo;
    [SerializeField] GameObject painel;
    [SerializeField] Text nome;
    private Coroutine contagem;

    private void Start()
    {
        painel.SetActive(false);
    }
    public void MostrarVida(bool EBoss, string nomeInimigo, Sprite face, float Max, float Atual)
    {
        if (EBoss == false)
        {
            if (contagem != null)
            {
                StopCoroutine(contagem);
            }
            painel.SetActive(true);
            nome.text = nomeInimigo;
            faceInimigo.sprite = face;
            float porcent = barraFundo.localScale.x / Max;
            barraVida.localScale = new Vector2(porcent * Atual, barraVida.localScale.y);
            contagem = StartCoroutine(ContagemSumir());
        }
    }

    IEnumerator ContagemSumir()
    {
        yield return new WaitForSeconds(3f);
        painel.SetActive(false);
        barraVida.localScale = barraFundo.localScale;
        faceInimigo.sprite = null;
        nome.text = "";

    }
}
