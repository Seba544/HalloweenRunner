using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] AudioEvents _audioEvents;
    public GameObject ExplotionEffect;
    private float _explotionOffsetSpawnY=2f;
    private Enemy _enemy;
    void Start()
    {
        _enemy = GetComponent<EnemyInitializer>()._enemy;
    }
    public void ReceiveDamage(int damage){
        _enemy.ReceiveDamage(damage);

        if(_enemy.IsDead)
        {
            DoExplotionEffect();
            _audioEvents.OnEnemyDeath();
            DestroyObject();
        }
        
        
    }

    public void DoExplotionEffect()
    {
        Instantiate(ExplotionEffect,new Vector3(transform.position.x,transform.position.y+_explotionOffsetSpawnY),Quaternion.identity);
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
