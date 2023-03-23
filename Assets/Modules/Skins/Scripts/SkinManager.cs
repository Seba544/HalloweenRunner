using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class SkinManager : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvents;
    [SerializeField] Button _purchaseButton;
    [SerializeField] SkinConfiguration _skinConfiguration;
    [SerializeField] TMP_Text _price;
    [SerializeField] GameObject _currentSkinCheckImage;
    [SerializeField] Button _selectSkinButton;
    private PlayerSkinData _playerSkinData;
    // Start is called before the first frame update
    void Start()
    {
        _gameEvents.OnSelectSkin()
            .Subscribe(skin => {
                if(skin==_skinConfiguration.SkinID){
                    _currentSkinCheckImage.SetActive(true);
                }else{
                    _currentSkinCheckImage.SetActive(false);
                }
            })
            .AddTo(this);
            
        _selectSkinButton.interactable=false;
        _price.text = "x" + _skinConfiguration.SkinPrice.ToString();
        
        

        _currentSkinCheckImage.SetActive(false);
        _playerSkinData = SaveSystem.LoadPlayerSkins();
        _selectSkinButton.onClick.AddListener(SelectSkin);
        
        _purchaseButton.onClick.AddListener(PurchaseSkin);
        SetPurchaseButtonAvailability();
        CheckPlayerPurchases();
        var validatePlayerCurrentSkinCmd = new ValidatePlayerCurrentSkin(_playerSkinData,_skinConfiguration,_currentSkinCheckImage,_purchaseButton);
        validatePlayerCurrentSkinCmd.Execute();
        
    }

    void SetPurchaseButtonAvailability()
    {
        
        int treasure = PlayerPrefs.GetInt("Treasure");
        if (_skinConfiguration.SkinPrice >= treasure)
        {
            _purchaseButton.interactable = false;
        }
        else
        {
            _purchaseButton.interactable = true;
        }
    }
    void CheckPlayerPurchases(){
        
        if(_playerSkinData!=null && _playerSkinData.SkinsPurchased.Contains(_skinConfiguration.SkinID)){
            
            _purchaseButton.gameObject.SetActive(false);
            _selectSkinButton.interactable=true;
        }
    }
    
    void SelectSkin(){
        PlayerSkinData playerSkinData = SaveSystem.LoadPlayerSkins();
        if(playerSkinData.CurrentSkin!=_skinConfiguration.SkinID){
            _currentSkinCheckImage.SetActive(true);
            playerSkinData.CurrentSkin = _skinConfiguration.SkinID;
            SaveSystem.SavePlayerSkin(playerSkinData);
            _gameEvents.SelectSkin(playerSkinData.CurrentSkin);
        }
    }
    void PurchaseSkin()
    {
        
        if (_playerSkinData != null)
        {
            if (!_playerSkinData.SkinsPurchased.Contains(_skinConfiguration.SkinID))
            {

                _playerSkinData.SkinsPurchased.Add(_skinConfiguration.SkinID);
                _playerSkinData.CurrentSkin = _skinConfiguration.SkinID;
                SaveSystem.SavePlayerSkin(_playerSkinData);

                int treasure = PlayerPrefs.GetInt("Treasure");
                int result = treasure - _skinConfiguration.SkinPrice;
                PlayerPrefs.SetInt("Treasure", result);
                _gameEvents.UpdateTreasureText(result.ToString());
            }
        }
        else
        {
            _playerSkinData = new PlayerSkinData(_skinConfiguration.SkinID,new List<string>{_skinConfiguration.SkinID});
            SaveSystem.SavePlayerSkin(_playerSkinData);

            int treasure = PlayerPrefs.GetInt("Treasure");
            int result = treasure - _skinConfiguration.SkinPrice;
            PlayerPrefs.SetInt("Treasure", result);
            _gameEvents.UpdateTreasureText(result.ToString());
        }
        
        _purchaseButton.gameObject.SetActive(false);
        _selectSkinButton.interactable=true;
        _gameEvents.SelectSkin(_skinConfiguration.SkinID);
    }
}

