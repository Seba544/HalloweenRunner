using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    private Button _button;
    // Start is called before the first frame update
    void Start()
    {
        
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Quit);
    }

    void Quit() => Application.Quit();
}
