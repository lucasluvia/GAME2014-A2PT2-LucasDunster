using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI resultText;

    // Start is called before the first frame update
    void Start()
    {
        int coins = PlayerPrefs.GetInt("coins");
        int lives = PlayerPrefs.GetInt("lives");

        if (lives <= 0)
        {
            resultText.text = "You LOST!";
        }
        else
        {
            resultText.text = "You WON!";
        }

        coinsText.text = coins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
