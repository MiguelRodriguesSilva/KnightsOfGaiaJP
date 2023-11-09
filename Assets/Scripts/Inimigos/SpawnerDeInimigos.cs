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
    [SerializeField] VidaInimigoHUD HUDInimigo;

    private void Start()
    {
        
    }
    void FixedUpdate()
    {
        tempoSpawn = tempoSpawn + cdSpawn * Time.deltaTime;
        SpawnAbelha();
    }

    public void SpawnAbelha()
    {
        
        if (tempoSpawn > cdSpawn)
        {
                if (inimigosRestantes[0] > 0)
                {
                    tempoSpawn = 0;
                    localSpawn = Random.Range(2, -4);
                    GameObject inimigo;
                    if (GameObject.FindGameObjectsWithTag("Enemy") != null)
                {
                    if (GameObject.FindGameObjectsWithTag("Enemy").Length < 3)
                    {
                        inimigo = Instantiate(qualInimigo[0], new Vector3(transform.position.x, localSpawn, 0), Quaternion.identity);
                        if (inimigo.TryGetComponent<VidaEnemy>(out VidaEnemy ve))
                        {
                            ve.hud = HUDInimigo;
                        }
                        inimigosRestantes[0] -= 1;
                    }
                }
                }

        }

    }
}