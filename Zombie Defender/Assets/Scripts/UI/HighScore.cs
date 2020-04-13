using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    private TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        highScoreText = gameObject.GetComponent<TextMeshProUGUI>();
        highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void RefreshHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}
