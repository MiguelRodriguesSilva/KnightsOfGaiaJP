using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chamas : MonoBehaviour
{
    float TempoVivo = 0f;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(1.5f,1.5f,1.5f);
        TempoVivo = Time.time + 1.2f;
        this.transform.parent = GameObject.Find("Jogador").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.back);
        if (Time.time > TempoVivo){
            Destroy(this.gameObject);

        }
        if (Input.GetButton("Tiro")){
                TempoVivo = Time.time + 1f;
            }
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.E)){

            TempoVivo = Time.time - 2f;
        
        }        
    }
}
