using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffectV2 : MonoBehaviour
{
    [SerializeField] private float _parallaxSpeed;

    private Transform _cameraTransform;
    private float _startPositionX;
    private float _spriteSizeX;
   
    void Start()
    {
        _cameraTransform = Camera.main.transform;
        _startPositionX = transform.position.x;
        _spriteSizeX = GetComponent<SpriteRenderer>().bounds.size.x;
    }


    void LateUpdate()
    {
        float relativeDistance = _cameraTransform.position.x * _parallaxSpeed;
        transform.position = new Vector3(_startPositionX + relativeDistance, transform.position.y, transform.position.z);

        float relativeCameraDistance = _cameraTransform.position.x * (1 - _parallaxSpeed);
        if (relativeCameraDistance > _startPositionX + _spriteSizeX)
        {
            _startPositionX += _spriteSizeX;
        }
        else if (relativeCameraDistance < _startPositionX - _spriteSizeX)
        {
            _startPositionX -= _spriteSizeX;
        }

    }
}
