using System.Collections;
using System.Collections.Generic;
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


        _gameEvents.OnGameOver()
            .Subscribe(_ => ReproduceDeath())
            .AddTo(this);

        _gameEvents.OnRevive()
            .Subscribe(_ => Revive())
            .AddTo(this);
        
        _jumpButton.onClick.AddListener(Jump);
        _slideButton.onClick.AddListener(Slide);

        _rgbd = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

    }
    

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W))
            Jump();
        
        if(Input.GetKeyDown(KeyCode.S))
            Slide();
        if (Time.timeScale == 0 || isDead)
            return;
        _rgbd.velocity = new Vector2(_currentSpeed, _rgbd.velocity.y);

        if (IsGrounded())
        {
            _animator.SetBool("isRunning", true);
        }else{
            _animator.SetBool("isRunning", false);
        }
        
    }

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

    private void Jump()
    {
        
        
        if (isSliding)
        {
            _animator.SetBool("isSliding", false);
            _boxCollider.size = new Vector2(_boxCollider.size.x, _initialColliderSizeY);
            _boxCollider.offset = new Vector2(_boxCollider.offset.x, _initialColliderOffsetY);
            isSliding = false;
            _currentSpeed = PlayerSpeed;
            return;
        }
        if ((IsGrounded() || currentAmountOfJumps < 1) && !isDead)
        {
            
            _animator.SetTrigger("isJumping");
            _rgbd.velocity = new Vector2(_rgbd.velocity.x, JumpForce);
            _audio.PlayOneShot(JumpAudioClip);
            currentAmountOfJumps++;
            _currentSpeed = PlayerSpeed;

        }
        

    }
    private void Slide()
    {
        if (IsGrounded() && !isDead && !isSliding)
        {
            _currentSpeed = PlayerSpeed*1.5f;
            _animator.SetBool("isSliding", true);
            _boxCollider.size = new Vector2(_boxCollider.size.x, _boxCollider.size.y / 2);
            _boxCollider.offset = new Vector2(_boxCollider.offset.x, _boxCollider.offset.y - 1.5f);
            isSliding = true;


        }
    }
    bool IsGrounded()
    {
        float extraHeightText = 0.5f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0f, Vector2.down, extraHeightText, GroundLayerMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(_boxCollider.bounds.center + new Vector3(_boxCollider.bounds.extents.x, 0), Vector2.down * (_boxCollider.bounds.extents.y + extraHeightText), rayColor);
        Debug.DrawRay(_boxCollider.bounds.center - new Vector3(_boxCollider.bounds.extents.x, 0), Vector2.down * (_boxCollider.bounds.extents.y + extraHeightText), rayColor);
        Debug.DrawRay(_boxCollider.bounds.center - new Vector3(_boxCollider.bounds.extents.x, _boxCollider.bounds.extents.y + extraHeightText), Vector2.down * (_boxCollider.bounds.extents.y + extraHeightText), rayColor);

        if (raycastHit.collider != null)
            currentAmountOfJumps = 0;
        return raycastHit.collider != null;
    }

    
}
