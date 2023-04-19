using UnityEngine;
using UniRx;

public class RunAttack : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvents;
    private Rigidbody2D _rgbd;

    bool isMoving;
    private Animator _animator;
    private Enemy _enemy;
    
    void Start()
    {
        _enemy = GetComponent<EnemyInitializer>()._enemy;
        isMoving = true;
        _rgbd = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _gameEvents.OnGameOver()
            .Subscribe(_ => {
                isMoving = false;
            })
            .AddTo(this);
        _gameEvents.OnRevive()
            .Subscribe(_ => {
                isMoving = true;
            })
            .AddTo(this);
    }
    void FixedUpdate()
    {

        if(isMoving){
            _animator.SetBool("isRunning",true);
        }else{
            _animator.SetBool("isRunning",false);
        }

        if(Time.timeScale==0 || !isMoving){
            _rgbd.velocity = Vector2.zero;
            return;
        }
             

        _rgbd.velocity = new Vector2(_enemy.Speed * -1, _rgbd.velocity.y);
    }
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            _gameEvents.GameOver();
        }
    }
    
}
