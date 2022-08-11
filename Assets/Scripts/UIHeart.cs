using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHeart : MonoBehaviour
{
    private TextMeshProUGUI myText;

    private void Start()
    {
        myText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        GameManager.OnHeartUpdate += UpdateHeart;
        GameManager.OnGameOver += SetFalseHeart;
    }

    private void OnDisable()
    {
        GameManager.OnHeartUpdate -= UpdateHeart;
        GameManager.OnGameOver -= SetFalseHeart;
    }

    public void UpdateHeart(int value)
    {
        SetFalseHeart();

        for (int j = 0; j < value; j++)
        {
            transform.GetChild(2 - j).gameObject.SetActive(true);
        }
    }

    public void SetFalseHeart()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
