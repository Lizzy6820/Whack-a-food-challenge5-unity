using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    
    private Rigidbody targetRb;
    private GameManager gameManager; 
    public int pointValue;
    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
      targetRb = GetComponent<Rigidbody>();
      gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

      targetRb.AddForce(Vector3.up * Random.Range(9,12), ForceMode.Impulse);
      transform.position = new Vector3(Random.Range(-4,2), 3);
      targetRb.AddTorque(Random.Range(-10,10), Random.Range(-10,10), Random.Range(-10,10), ForceMode.Impulse ); 
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown() {
    if(gameManager.isGameActive){
    Destroy(gameObject);
    gameManager.UpdateScore(pointValue);
    Instantiate (explosionParticle, transform.position, explosionParticle.transform.rotation);
    }
    }
    private void OnTriggerEnter(Collider other) {
    Destroy(gameObject);  
    if(!gameObject.CompareTag("Bad")){
     gameManager.GameOver();
    }
    
    }
}
