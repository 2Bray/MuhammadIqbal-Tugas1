using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScore : MonoBehaviour
{
    private TextMeshProUGUI myText;

    private void Start()
    {
        myText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        GameManager.OnScoreUpdate += UpdateScore;
    }

    private void OnDisable()
    {
        GameManager.OnScoreUpdate -= UpdateScore;
    }

    private void UpdateScore(int value)
    {
        myText.text = "Score : " + value;
    }
}
