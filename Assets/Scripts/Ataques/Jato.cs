using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jato : MonoBehaviour
{
    float TempoVivo;
    public GameObject PlayerParaJato;
    // Start is called before the first frame update
    void Start()
    { 
        TempoVivo = Time.time + 0.3f;
        transform.position = transform.position + new Vector3(0.5f,0,0);
        this.transform.parent = GameObject.Find("Jogador").transform;
        PlayerParaJato = GameObject.Find("Jogador");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerParaJato.GetComponent<Player>().XJatoPlayer = transform.localScale.x;
        TempoVivo = Time.time + transform.localScale.x;

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
        
    }
}
