using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICountdown : MonoBehaviour
{
    private TextMeshProUGUI myText;
    private Transform myChild;

    private void Start()
    {
        myChild = transform.GetChild(0);
        myText = myChild.GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        WaveTimer.OnCountdownWave += StartCountDown;
        WaveTimer.OnCountdownEnd += EndCountDown;
    }

    private void OnDisable()
    {
        WaveTimer.OnCountdownWave -= StartCountDown;
        WaveTimer.OnCountdownEnd -= EndCountDown;
    }

    //Tampilan CountDown Pada Awal Wave
    private void StartCountDown(float value)
    {
        value = 11 - value;
        myChild.gameObject.SetActive(value < 4);
        myText.text = Mathf.FloorToInt(value).ToString();
    }

    private void EndCountDown() => myChild.gameObject.SetActive(false);
}
