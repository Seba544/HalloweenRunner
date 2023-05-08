using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyMagicWeaponManager : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvents;
    [SerializeField] MagicWeaponConfiguration _magicWeaponConfig;
    [SerializeField] Button _purchaseButton;
    [SerializeField] TMP_Text _amountToBuy;
    [SerializeField] TMP_Text _price;
    private Weapon _weapon;

    void Start()
    {
        _purchaseButton.onClick.AddListener(Buy);
        SetPurchaseButtonAvailability();
        _amountToBuy.text = "x "+_magicWeaponConfig.BuyAmount.ToString();
        _price.text = "x "+_magicWeaponConfig.Price.ToString();

    }


    void SetPurchaseButtonAvailability()
    {

        int treasure = PlayerPrefs.GetInt("Treasure");
        if (_magicWeaponConfig.Price >= treasure)
        {
            _purchaseButton.interactable = false;
        }
        else
        {
            _purchaseButton.interactable = true;
        }
    }

    void Buy()
    {

        _weapon = new Weapon(_magicWeaponConfig.ID,
        _magicWeaponConfig.Price,
        _magicWeaponConfig.BuyAmount,
        _magicWeaponConfig.DamagePoints,
        _magicWeaponConfig.ReloadTime,
        WeaponState.READY);

        int currentTreasure = PlayerPrefs.GetInt("Treasure");

        if (!_weapon.CanAffordBuy(currentTreasure))
            return;

        WeaponData weaponData = SaveSystem.LoadMagicWeapon();
        if (weaponData == null)
        {
            weaponData = new WeaponData(_weapon);
            SaveSystem.SaveMagicWeapon(weaponData);
        }
        else
        {
            weaponData.Ammunition += _magicWeaponConfig.BuyAmount;
            SaveSystem.SaveMagicWeapon(weaponData);
        }

        int result = currentTreasure - _magicWeaponConfig.Price;
        PlayerPrefs.SetInt("Treasure", result);
        _gameEvents.UpdateTreasureText(result.ToString());
        SetPurchaseButtonAvailability();

    }
}
