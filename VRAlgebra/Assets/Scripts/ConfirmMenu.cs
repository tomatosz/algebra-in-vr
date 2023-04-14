using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmMenu : MonoBehaviour
{
    public GameObject ConfirmExitMenu;
    public GameObject MainMenu;

    public void ConfirmExit()
    {
        Debug.Log("EXIT");
        Application.Quit();
    }

    public void CancelExit()
    {
        MainMenu.SetActive(true);
        ConfirmExitMenu.SetActive(false);
    }
}
