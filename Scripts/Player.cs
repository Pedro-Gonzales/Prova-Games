using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forceMultiplier = 4f; 
    public float maximumVelocity = 6f;
    public ParticleSystem deathParticles;
    
    private Rigidbody rb;

    void Start()
    {
        rb =  GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");

        if(rb.velocity.magnitude <= maximumVelocity){
            rb.AddForce(new Vector3(horizontalInput * forceMultiplier, 0 , 0));
        }
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Hazard")){
            GameManager.GameOver();
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
