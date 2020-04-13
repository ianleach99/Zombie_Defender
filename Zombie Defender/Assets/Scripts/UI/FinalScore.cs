using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
    public static int finalScore;

    void Start()
    {
        TextMeshProUGUI text = gameObject.GetComponent<TextMeshProUGUI>();
        text.text = "Final Score: " + finalScore;
    }
}
