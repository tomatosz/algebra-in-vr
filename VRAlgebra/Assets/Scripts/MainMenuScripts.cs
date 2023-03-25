using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScripts : MonoBehaviour

{
    
    public GameObject OneObjectMenu;
    public GameObject TwoObjectMenu;
    public GameObject EmbeddedObjectMenu;
    public GameObject MainMenu;
    public GameObject Settings;
    public GameObject ConfirmExitMenu;

    public void CallOneObjectMenu()
    {
        OneObjectMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void CallTwoObjectMenu()
    {
        TwoObjectMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void CallEmbeddedObjectMenu()
    {
        EmbeddedObjectMenu.SetActive(true);
        MainMenu.SetActive(false);
    }


    public void CallSettings()
    {
        Settings.SetActive(true);
        MainMenu.SetActive(false);
    }


    public void Close()
    {
        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            SetupScene.RotateToggle = true;
            MainMenu.SetActive(false);
        }
    }

    public void Exit()
    {
        ConfirmExitMenu.SetActive(true);
        MainMenu.SetActive(false);
    }
}
