using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{

    [SerializeField] GameObject Touch2Play;
    [SerializeField] GameObject RestartMenu;
    [SerializeField] Image JoystickBG;
    [SerializeField] Image JoystickHandle;



    public static UImanager instance;




    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        
        Time.timeScale = 0;

    }

    public void GameOver()
    {
        RestartMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Play()
    {
        Time.timeScale = 1;
        Touch2Play.SetActive(false);
        JoystickBG.enabled = true;
        JoystickHandle.enabled = true;


    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void hidejoystick()
    {
        JoystickBG.enabled = false;
        JoystickHandle.enabled = false;
    }
}
