using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class ValidatePlayerCurrentSkinTest
{
    
    private SkinConfiguration _skinConfiguration;
    PlayerSkinData _playerSkinData;
    GameObject _purchaseButton = new GameObject();
    GameObject _currentSkinCheckImage = new GameObject();
    
    ValidatePlayerCurrentSkin _command;
    [SetUp]
    public void Setup(){
        _purchaseButton.AddComponent<Button>();
        _skinConfiguration = ScriptableObject.CreateInstance<SkinConfiguration>();
        _skinConfiguration.SkinID = "testSkin";
        _playerSkinData = new PlayerSkinData("testSkin",new List<string>{"testSkin"});
        _command = new ValidatePlayerCurrentSkin(
            _playerSkinData,
            _skinConfiguration,
            _currentSkinCheckImage,
            _purchaseButton.GetComponent<Button>());
    }

    [Test]
    public void disable_purchase_button_if_skin_is_in_use(){
        
        _command.Execute();

        Assert.AreEqual(_purchaseButton.gameObject.activeSelf,false);
    }

    [Test]
    public void enable_check_current_skin_image_if_skin_is_in_use(){

        _command.Execute();

        Assert.AreEqual(_currentSkinCheckImage.activeSelf,true);
    }
}
