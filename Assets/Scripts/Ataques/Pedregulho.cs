using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedregulho : MonoBehaviour
{
    [SerializeField] float speed;

    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if ( transform.position.x > 10.5f)
        {
            Destroy(this.gameObject);
        }
    
    }
    

    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.tag == "Enemy")
        {

            Destroy(this.gameObject);
        }
    }
}
