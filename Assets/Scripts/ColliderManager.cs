using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    private Rigidbody2D _rgbd;
    private BoxCollider2D _boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        _rgbd = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _boxCollider.isTrigger = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        _rgbd.isKinematic = true;
        _boxCollider.isTrigger=true;
        
    }
}
