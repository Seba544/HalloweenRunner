using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvents;
    private Rigidbody2D _rgbd;
    private Animator _animator;
    BoxCollider2D _boxCollider;
    public float PlayerSpeed;
    public float JumpForce;
    public LayerMask GroundLayerMask;
    private Button _jumpButton;
    private Button _slideButton;
    bool isDead;
    bool isSliding;
    int currentAmountOfJumps;
    float _initialColliderSizeY;
    float _initialColliderOffsetY;
    private AudioSource _audio;
    public AudioClip JumpAudioClip;
    private float _currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _currentSpeed = PlayerSpeed;
        _audio = GetComponent<AudioSource>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _initialColliderSizeY = _boxCollider.size.y;
        _initialColliderOffsetY = _boxCollider.offset.y;
        _jumpButton = GameObject.FindGameObjectWithTag("JumpButton").gameObject.GetComponent<Button>();
        _slideButton = GameObject.FindGameObjectWithTag("SlideButton").gameObject.GetComponent<Button>();
        currentAmountOfJumps = 0;


        /*_gameEvents.OnGameOver()
            .Subscribe(_ => ReproduceDeath())
            .AddTo(this);*/

        _gameEvents.OnRevive()
            .Subscribe(_ => Revive())
            .AddTo(this);
        
        _slideButton.onClick.AddListener(Slide);

        _rgbd = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        
    }
    

    /*void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.S))
            Slide();
        if (Time.timeScale == 0 || isDead)
            return;
        _rgbd.velocity = new Vector2(_currentSpeed, _rgbd.velocity.y);

    }*/

    void ReproduceDeath()
    {
        if(isDead)
            return;
        _animator.SetTrigger("isDead");
        isDead = true;

    }

    void Revive()
    {
        _animator.SetTrigger("toRevive");
        isDead = false;
    }
    private void Slide()
    {
        if (!isDead && !isSliding)
        {
            _currentSpeed = PlayerSpeed*1.5f;
            _animator.SetBool("isSliding", true);
            _boxCollider.size = new Vector2(_boxCollider.size.x, _boxCollider.size.y / 2);
            _boxCollider.offset = new Vector2(_boxCollider.offset.x, _boxCollider.offset.y - 1.5f);
            isSliding = true;


        }
    }
    

    
}
