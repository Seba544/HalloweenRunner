using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvents;
    [SerializeField] Button _purchaseButton;
    [SerializeField] SkinConfiguration _skinConfiguration;
    [SerializeField] TMP_Text _price;
    [SerializeField] Image _showcaseImage;
    [SerializeField] GameObject _purchasedPanel;
    // Start is called before the first frame update
    void Start()
    {
        _price.text = "x" + _skinConfiguration.SkinPrice.ToString();
        _showcaseImage.sprite = _skinConfiguration.Sprite;
        _showcaseImage.preserveAspect = true;
        //_showcaseImage.SetNativeSize();
        //_showcaseImage.rectTransform.localScale = new Vector3(0.5f,0.5f,1);
        //RectTransform imageTransform = _showcaseImage.GetComponent<RectTransform>();
        //imageTransform.position = new Vector3(imageTransform.position.x,imageTransform.position.y-3f,imageTransform.position.z);
        _purchasedPanel.SetActive(false);
        _purchaseButton.onClick.AddListener(PurchaseSkin);
        SetPurchaseButtonAvailability();
        CheckPlayerPurchases();
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
        PlayerSkinData playerSkinData = SaveSystem.LoadPlayerSkins();
        if(playerSkinData!=null && playerSkinData.SkinsPurchased.Contains(_skinConfiguration.SkinID)){
            _purchasedPanel.SetActive(true);
            _purchaseButton.gameObject.SetActive(false);
        }
    }
    void PurchaseSkin()
    {
        PlayerSkinData playerSkinData = SaveSystem.LoadPlayerSkins();
        if (playerSkinData != null)
        {
            if (!playerSkinData.SkinsPurchased.Contains(_skinConfiguration.SkinID))
            {

                playerSkinData.SkinsPurchased.Add(_skinConfiguration.SkinID);
                playerSkinData.CurrentSkin = _skinConfiguration.SkinID;
                SaveSystem.SavePlayerSkin(playerSkinData);

                int treasure = PlayerPrefs.GetInt("Treasure");
                int result = treasure - _skinConfiguration.SkinPrice;
                PlayerPrefs.SetInt("Treasure", result);
                _gameEvents.UpdateTreasureText(result.ToString());
            }
        }
        else
        {
            playerSkinData = new PlayerSkinData(_skinConfiguration.SkinID,new List<string>{_skinConfiguration.SkinID});
            SaveSystem.SavePlayerSkin(playerSkinData);

            int treasure = PlayerPrefs.GetInt("Treasure");
            int result = treasure - _skinConfiguration.SkinPrice;
            PlayerPrefs.SetInt("Treasure", result);
            _gameEvents.UpdateTreasureText(result.ToString());
        }
        _purchasedPanel.SetActive(true);
        _purchaseButton.gameObject.SetActive(false);
    }
}

