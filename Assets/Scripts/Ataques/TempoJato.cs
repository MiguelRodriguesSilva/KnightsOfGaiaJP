using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoJato : MonoBehaviour
{

    public float TempoVivo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetAxisRaw("Tiro") == 0){
            transform.localScale = transform.localScale + new Vector3(0.3f,0,0) * Time.deltaTime;
        }
    }
}
