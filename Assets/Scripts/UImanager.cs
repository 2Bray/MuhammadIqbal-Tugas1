using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UImanager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countDown;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private GameObject gameOverPanel;

    //Tampilan CountDown Pada Awal Wave
    public void StartCountDown(float value)
    {
        value = 11 - value;
        countDown.gameObject.SetActive(value >= 1 && value < 4);
        countDown.text = Mathf.FloorToInt(value).ToString();
    }

    public void UpdateScore(int value)
    {
        score.text = "Score : " + value;
    }

    public void SetGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
}
