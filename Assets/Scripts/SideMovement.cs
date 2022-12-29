using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMovement : MonoBehaviour
{
    private Rigidbody2D _rgbd;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        _rgbd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale==0)
            return;
        _rgbd.velocity = new Vector2(Speed * -1, _rgbd.velocity.y);
    }
}
