using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = gameObject.GetComponent<TextMeshProUGUI>();
        scoreText.text = Player.score.ToString();
    }

    public void UpdateScoreText()
    {
        scoreText.text = Player.score.ToString();
    }
}
