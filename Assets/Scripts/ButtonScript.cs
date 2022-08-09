using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private Button quit;
    [SerializeField] private Button restart;

    //Mengisi On Click Event Di Dalam Script
    private void Start()
    {
        quit.onClick.AddListener(ExitGame);
        restart.onClick.AddListener( () => SceneManager.LoadScene("GamePlay") );
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
