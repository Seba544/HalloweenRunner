using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UniRx;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] AudioEvents _audioEvents;
    [SerializeField] GameEvent _gameEvents;
    private Transform BulletSpawnPoint;
    public GameObject Bullet;
    private Weapon _weapon;
    [SerializeField] Button _shootButton;
    [SerializeField] TMP_Text _ammoCounter;
    [SerializeField] Image _iconFillRadial;
    bool isNotReloading;
    // Start is called before the first frame update
    void Start()
    {
        _gameEvents.OnEndOfLevel()
            .Subscribe(_ => SaveWeapon())
            .AddTo(this);

        WeaponData weaponData = SaveSystem.LoadMagicWeapon();
        if(weaponData==null){
            _weapon = new Weapon("magic_projectile",5, 0, 1, 1, WeaponState.NO_AMMO);
        }else{
            _weapon = new Weapon(weaponData.Id,weaponData.Price,weaponData.Ammunition,weaponData.DamagePoints,weaponData.ReloadTime,WeaponState.READY);
            SetWeaponState(weaponData);
        }
        
        
        _shootButton.onClick.AddListener(Shoot);
        isNotReloading = true;
        _ammoCounter.text = _weapon.Ammunition.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {

            Shoot();
        }
    }
    void SetWeaponState(WeaponData weaponData){
        if(weaponData.Ammunition<=0){
            _weapon.WeaponState = WeaponState.NO_AMMO;
        }else{
            _weapon.WeaponState = WeaponState.READY;
        }
    }
    void Shoot()
    {
        
        if (BulletSpawnPoint == null)
        {
            BulletSpawnPoint = GameObject.FindGameObjectWithTag("BulletSpawnPoint").transform;
        }

        if (_weapon.WeaponState == WeaponState.READY)
        {
            _weapon.Shoot();
            var bullet = Instantiate(Bullet, BulletSpawnPoint.transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().DamagePoints = _weapon.DamagePoints;
            _audioEvents.OnPlayPlayerShoot();
            UpdateAmmoCounter();
            Reload();
        }
        else
        {
            //Empty weapon;
        }
    }
    void SaveWeapon(){
        WeaponData weaponData = SaveSystem.LoadMagicWeapon();
        if(weaponData!=null){
            weaponData.Ammunition = _weapon.Ammunition;
            SaveSystem.SaveMagicWeapon(weaponData);
        }
    }
    void UpdateAmmoCounter() => _ammoCounter.text = _weapon.Ammunition.ToString();
    void Reload()
    {
        if (_weapon.WeaponState == WeaponState.NO_AMMO)
            return;
        _weapon.WeaponState = WeaponState.RELOADING;
        _iconFillRadial.fillAmount = 0;
        _iconFillRadial.DOFillAmount(1, _weapon.ReloadTime).OnComplete(() =>
        {

            _weapon.WeaponState = WeaponState.READY;

        });
    }
}
