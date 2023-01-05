using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private Transform _cameraTransform;
    private Vector3 _previousCameraPosition;
    public float ParallaxSpeed;
    private float _spriteWidth, _startPosition;
    // Start is called before the first frame update
    void Start()
    {
        _cameraTransform = Camera.main.transform;
        _previousCameraPosition = _cameraTransform.position;
        _spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x; 
        _startPosition = transform.position.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float deltaX = (_cameraTransform.position.x - _previousCameraPosition.x) * ParallaxSpeed;
        float moveAmount = _cameraTransform.position.x * (1.1f - ParallaxSpeed);
        transform.Translate(new Vector3(deltaX,0,0));
        _previousCameraPosition = _cameraTransform.position;

        if(moveAmount > _startPosition + _spriteWidth){
            transform.Translate(new Vector3(_spriteWidth,0,0));
            _startPosition += _spriteWidth;
        }
        else if(moveAmount < _startPosition - _spriteWidth){
            transform.Translate(new Vector3(-_spriteWidth,0,0));
            _startPosition -= _spriteWidth;
        }
    }
}
