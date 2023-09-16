using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedregulho : MonoBehaviour
{
    [SerializeField] float speed, quantiEspecial;
    private PlayerAttack player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerAttack>();
    }
    private void Start()
    {
        player.specialATQConti += quantiEspecial;

    }
    void FixedUpdate()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

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
