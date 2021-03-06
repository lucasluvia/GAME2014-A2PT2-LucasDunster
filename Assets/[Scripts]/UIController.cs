// UIController.cs
// Lucas Dunster 101230948
// DLM: 12/12/21
// Controls UI-related functions

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject onscreenControls;
    [SerializeField] private TextMeshProUGUI LivesText;
    [SerializeField] private TextMeshProUGUI CoinsText;
    [SerializeField] private PlayerBehaviour player;
    public static bool isJumpButtonPressed;

    void Start()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.Android:
            case RuntimePlatform.IPhonePlayer:
                onscreenControls.SetActive(true);
                break;
            case RuntimePlatform.WebGLPlayer:
            case RuntimePlatform.WindowsPlayer:
                onscreenControls.SetActive(false);
                break;
        }
    }

    void Update()
    {
        LivesText.text = player.GetLives().ToString();
        CoinsText.text = player.GetCoins().ToString();
    }

    public void OnJumpButton_Down()
    {
        isJumpButtonPressed = true;
    }

    public void OnJumpButton_Up()
    {
        isJumpButtonPressed = false;
    }

}
