using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    private GameObject myChild;

    private void Start()
    {
        myChild = transform.GetChild(0).gameObject;
    }

    private void OnEnable()
    {
        GameManager.OnGameOver += SetGameOverPanel;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= SetGameOverPanel;
    }

    private void SetGameOverPanel()
    {
        myChild.SetActive(true);
    }
}
