using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvents;
    private GameObject _player;
    private float SmoothSpeed = 3f;
    private Vector3 Offset = new Vector3(5,0,0);
    bool followsPlayer;
    // Start is called before the first frame update
    void Start()
    {
        _gameEvents.OnFollowPlayer()
            .Subscribe(_ => {
                _player = GameObject.FindGameObjectWithTag("Player");
                followsPlayer = true;
            })
            .AddTo(this);

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
    void Update()
    {
        if(Time.timeScale==0 || !followsPlayer)
            return;
        Vector3 desiredPosition = new Vector3(_player.transform.position.x + Offset.x,transform.position.y,transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position,desiredPosition,SmoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
