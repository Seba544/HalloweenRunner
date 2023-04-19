using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] AudioEvents _audioEvents;
    public Transform BulletSpawnPoint;
    public GameObject Bullet;
    private Weapon _weapon;
    // Start is called before the first frame update
    void Start()
    {
        _weapon = new Weapon("magic_projectile",5,1);
       
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.E)){
            if(!_weapon.IsOutOfAmmo){
                _weapon.Shoot();
                var bullet = Instantiate(Bullet,BulletSpawnPoint.transform.position,Quaternion.identity);
                bullet.GetComponent<Bullet>().DamagePoints = _weapon.DamagePoints;
                _audioEvents.OnPlayPlayerShoot();
            }else{
                //Empty weapon;
            }
            
       } 
    }
}
