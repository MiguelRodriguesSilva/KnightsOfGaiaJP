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
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.back);
        if (Time.time > TempoVivo){
            Destroy(this.gameObject);

        }
        
    }
}
