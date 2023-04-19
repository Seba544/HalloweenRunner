using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    public float RotationSpeed;
    public int DamagePoints;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy")){
            var enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.ReceiveDamage(DamagePoints);
            Destroy(gameObject);
        }
    }
}
