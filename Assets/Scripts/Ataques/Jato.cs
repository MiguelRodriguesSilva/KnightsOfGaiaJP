using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jato : MonoBehaviour
{
    float TempoVivo;
    // Start is called before the first frame update
    void Start()
    { 
        TempoVivo = 0.2f;
        transform.position = transform.position + new Vector3(0.5f,0,0);
        this.transform.parent = GameObject.Find("Jogador").transform;

    }

    // Update is called once per frame
    void Update()
    {
        TempoVivo = TempoVivo + 1 * Time.deltaTime;

        if (Input.GetButton("Tiro")){

            if (transform.localScale.x >= 3){
            transform.localScale = new Vector3(3,transform.localScale.y,1);
            }
            
            if (transform.localScale.x <= 3){
            transform.localScale = transform.localScale + new Vector3(1,0,0) * Time.deltaTime;
            }            
        }

        else{
            transform.localScale = transform.localScale + new Vector3(-2,0,0) * Time.deltaTime;
            
        }
        if (transform.localScale.x <= 0){
                Destroy(this.gameObject);
            }

        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.R)){
            Destroy(this.gameObject);
        }
        
    }
}
