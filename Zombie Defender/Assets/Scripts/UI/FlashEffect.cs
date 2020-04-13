using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlashEffect : MonoBehaviour
{
    public float delayTime;

    private void Start()
    {
        Debug.Log("Script started");
        StartCoroutine(StartFlash(delayTime));
    }

    IEnumerator StartFlash(float theDelayTime)
    {
        TextMeshProUGUI text = gameObject.GetComponent<TextMeshProUGUI>();
        string oldText = text.text;

        while(true)
        {
            text.text = oldText;
            yield return new WaitForSeconds(theDelayTime);
            text.text = "";
            yield return new WaitForSeconds(theDelayTime);
        }
    }
}
