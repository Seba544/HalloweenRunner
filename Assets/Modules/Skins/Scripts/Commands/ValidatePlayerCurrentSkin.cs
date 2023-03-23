using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValidatePlayerCurrentSkin : ICommand
{
    PlayerSkinData _playerSkinData;
    SkinConfiguration _skinConfiguration;
    GameObject _currentSkinCheckImage;
    Button _purchaseSkinButton;
    public ValidatePlayerCurrentSkin(PlayerSkinData playerSkinData
    ,SkinConfiguration skinConfiguration,
    GameObject currentSkinCheckImage,
    Button purchaseSkinButton){
        _playerSkinData = playerSkinData;
        _skinConfiguration = skinConfiguration;
        _currentSkinCheckImage = currentSkinCheckImage;
        _purchaseSkinButton = purchaseSkinButton;
    }
    public void Execute()
    {
        if(_playerSkinData!=null && _playerSkinData.CurrentSkin == _skinConfiguration.SkinID){
            _currentSkinCheckImage.SetActive(true);
            _purchaseSkinButton.gameObject.SetActive(false);
        }
    }
}
