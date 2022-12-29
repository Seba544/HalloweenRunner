using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvents;
    public Transform Player;
    public float SmoothSpeed;
    public Vector3 Offset;
    bool followsPlayer;
    // Start is called before the first frame update
    void Start()
    {
        followsPlayer = true;
        _gameEvents.OnGameOver()
            .Subscribe(_ => {
                followsPlayer = false;
            })
            .AddTo(this);
        _gameEvents.EndWave()
            .Subscribe(_ => {
                followsPlayer = false;
            })
            .AddTo(this);
        _gameEvents.OnRevive()
            .Subscribe(_ => {
                followsPlayer = true;
            })
            .AddTo(this);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Time.timeScale==0 || !followsPlayer)
            return;
        Vector3 desiredPosition = new Vector3(Player.position.x + Offset.x,transform.position.y,transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position,desiredPosition,SmoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
