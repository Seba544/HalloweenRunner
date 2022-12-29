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
    public float DoubleJumpForce;
    public LayerMask GroundLayerMask;
    [SerializeField] Button _jumpButton;
    bool isDead;
    int currentAmountOfJumps;
    // Start is called before the first frame update
    void Start()
    {
        currentAmountOfJumps = 0;
        _gameEvents.OnGameOver()
            .Subscribe(_ => ReproduceDeath())
            .AddTo(this);

        _gameEvents.OnRevive()
            .Subscribe(_ => Revive())
            .AddTo(this);
        _jumpButton.onClick.AddListener(Jump);
        _boxCollider = GetComponent<BoxCollider2D>();
        _rgbd = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        if(Time.timeScale==0 || isDead)
            return;
        _rgbd.velocity = new Vector2(PlayerSpeed * 1, _rgbd.velocity.y);

        if(IsGrounded()){
            _animator.SetBool("isJumping",false);
        }else{
            _animator.SetBool("isJumping",true);
        }

        if(Input.GetKeyDown(KeyCode.W)){
            Jump();
        }
    }

    void ReproduceDeath(){
        _animator.SetTrigger("isDead");
        
        isDead=true;
  
        
    }

    void Revive(){
        _animator.SetTrigger("toRevive");
        isDead = false;
    }

    private void Jump(){
        if((IsGrounded()|| currentAmountOfJumps<1) && !isDead){
            _rgbd.velocity = new Vector2(_rgbd.velocity.x,JumpForce);
         
            currentAmountOfJumps++;
        }
            
    }
    bool IsGrounded(){
        float extraHeightText = 0.5f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(_boxCollider.bounds.center,_boxCollider.bounds.size,0f, Vector2.down, extraHeightText,GroundLayerMask);
        Color rayColor;
        if(raycastHit.collider !=null){
            rayColor = Color.green;
        }else{
            rayColor = Color.red;
        }
        Debug.DrawRay(_boxCollider.bounds.center + new Vector3(_boxCollider.bounds.extents.x,0),Vector2.down * (_boxCollider.bounds.extents.y + extraHeightText),rayColor);
        Debug.DrawRay(_boxCollider.bounds.center - new Vector3(_boxCollider.bounds.extents.x,0),Vector2.down * (_boxCollider.bounds.extents.y + extraHeightText),rayColor);
        Debug.DrawRay(_boxCollider.bounds.center - new Vector3(_boxCollider.bounds.extents.x,_boxCollider.bounds.extents.y + extraHeightText),Vector2.down * (_boxCollider.bounds.extents.y + extraHeightText),rayColor);

        if(raycastHit.collider != null)
            currentAmountOfJumps = 0;
        return raycastHit.collider != null;
    }
}
