using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDeInimigos : MonoBehaviour
{
    public GameObject[] qualInimigo;
    public int[] inimigosRestantes;
    public int quantidadeInimigosJuntos;
    [SerializeField] float cdSpawn;
    int localSpawn;
    float tempoSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempoSpawn = tempoSpawn + cdSpawn * Time.deltaTime;
        SpawnAbelha();
    }

    public void SpawnAbelha()
    {
        
        if (tempoSpawn > 3)
        {
            int ultimoSpawn = localSpawn;
            tempoSpawn = 0;
            localSpawn = Random.Range(4 , -4);
            if (inimigosRestantes[0] > 0){
                Instantiate(qualInimigo[0], new Vector3(transform.position.x, localSpawn, 0), Quaternion.identity);
                inimigosRestantes[0] -= 1;
            }
            
                   
        }

        
    }
}
