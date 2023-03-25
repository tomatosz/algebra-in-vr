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
    public bool Rotation;

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


    public void Exit()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            ConfirmExitMenu.SetActive(true);
            MainMenu.SetActive(false);
        }
        else
        {
            Rotation = true;
            MainMenu.SetActive(false);
        }
    }
}
