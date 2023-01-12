using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JumpAttack : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvents;
    public float JumpForce;
    public float Offset;
    private Rigidbody2D _rgbd;
    
    // Start is called before the first frame update
    void Start()
    {
        _rgbd = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(transform.position.x,transform.position.y+1,transform.position.z);
        StartCoroutine(Attack());
    }


    IEnumerator Attack(){
        while(true){
            
            
            _rgbd.velocity = new Vector2(_rgbd.velocity.x, JumpForce);
            yield return new WaitForSeconds(3f);
            
        }
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            _gameEvents.GameOver();
            Destroy(gameObject);
        }
            
    }
}
