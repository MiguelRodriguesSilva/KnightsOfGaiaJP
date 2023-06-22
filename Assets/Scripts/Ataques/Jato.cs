using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jato : MonoBehaviour
{
    float TempoVivo;
    bool AindaVive;
    // Start is called before the first frame update
    void Start()
    {
        AindaVive = True;
        TempoVivo = Time.time + 0.3f;
        transform.position = transform.position + new Vector3(0.5f,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Tiro") != 0){
            transform.localScale = transform.localScale + new Vector3(0.3f,0,0) * Time.deltaTime;

        }
        else if (Input.GetAxisRaw("Tiro") == 0){
            transform.localScale = transform.localScale + new Vector3(-0.3f,0,0) * Time.deltaTime;
            
        }
        if (transform.localScale.x <= 0){
                AindaVive = false;
                Destroy(this);
            }
    }
}
