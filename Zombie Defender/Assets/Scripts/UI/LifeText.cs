using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeText : MonoBehaviour
{
    private TextMeshProUGUI livesText;

    // Start is called before the first frame update
    void Start()
    {
        livesText = gameObject.GetComponent<TextMeshProUGUI>();
        livesText.text = "Lives: " + Player.lives.ToString();
    }

    public void UpdateLivesText()
    {
        livesText = gameObject.GetComponent<TextMeshProUGUI>();
        livesText.text = "Lives: " + Player.lives.ToString();
    }
}
