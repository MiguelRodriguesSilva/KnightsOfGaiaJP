using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDeInimigos : MonoBehaviour
{
    public GameObject qualInimigo;
    public int inimigosRestantes = 3;
    public int quantidadeInimigosJuntos;
    float localSpawn;
    float tempoSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempoSpawn = tempoSpawn + 1 * Time.deltaTime;
        Spawn();
    }

    public void Spawn()
    {
        
        if (tempoSpawn > 3)
        {

            tempoSpawn = 0;
            localSpawn = Random.Range(4f , -4f);
            if (inimigosRestantes > 0){
                Instantiate(qualInimigo, new Vector3(transform.position.x, localSpawn, 0), Quaternion.identity);
                inimigosRestantes = inimigosRestantes - 1;
            }
                   
        }

        
    }
}
