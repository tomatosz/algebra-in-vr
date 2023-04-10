using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScripts : MonoBehaviour

{
    public Toggle Labels;
    public Toggle RunningTotal;
    public GameObject OneObjectMenu;
    public GameObject TwoObjectMenu;
    public GameObject EmbeddedObjectMenu;
    public GameObject MainMenu;
    public GameObject Settings;
    public GameObject ConfirmExitMenu;
    public TMP_Dropdown RotationMode;
    public GameObject Player;

    // function to open menu when pressing the correct button
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SavePlayerPositionScript();
            CallMainMenu();
            SetupScene.RotateToggle = false;  // make object in the room non-interactible while the menu is open
        }
    }

    // function to save player position before scene switch so the position can be used in the new scene
    public void SavePlayerPositionScript()
    {
        PlayerPrefs.SetFloat("PlayerPosx", Player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerPosy", Player.transform.position.y);
        PlayerPrefs.SetFloat("PlayerPosz", Player.transform.position.z);
        PlayerPrefs.SetFloat("PlayerRotx", Player.transform.rotation.eulerAngles.x);
        PlayerPrefs.SetFloat("PlayerRoty", Player.transform.rotation.eulerAngles.y);
        PlayerPrefs.SetFloat("PlayerRotz", Player.transform.rotation.eulerAngles.z);
    }

    // functions to open and close different menus


    public void CallMainMenu()
    {
        MainMenu.SetActive(true);
        OneObjectMenu.SetActive(false);
        TwoObjectMenu.SetActive(false);
        EmbeddedObjectMenu.SetActive(false);
        Settings.SetActive(false);
        ConfirmExitMenu.SetActive(false);
    }


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
            SetupScene.RotateToggle = true; // make the object interactible again when the menu is closed
            MainMenu.SetActive(false);
            OneObjectMenu.SetActive(false);
            TwoObjectMenu.SetActive(false);
            EmbeddedObjectMenu.SetActive(false);
            Settings.SetActive(false);
            ConfirmExitMenu.SetActive(false);
        }
    }
    public void Exit()
    {
        ConfirmExitMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    // functions to either close the program or go back to main menu.

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


    // functions to load scenes with one object

    public void CallOneTetra()
    {
        SavePlayerPositionScript(); // save player position so new scene can start in same position
        SceneManager.LoadScene("OneTetraeder");

    }

    public void CallOneCube()
    {
        SavePlayerPositionScript(); // save player position so new scene can start in same position
        SceneManager.LoadScene("OneCube");

    }

    public void CallOneOcta()
    {
        SavePlayerPositionScript(); // save player position so new scene can start in same position
        SceneManager.LoadScene("OneOctahedron");

    }

    public void CallOneDodeca()
    {
        SavePlayerPositionScript(); // save player position so new scene can start in same position
        SceneManager.LoadScene("OneDodecahedron");
    }

    public void CallOneIsoca()
    {
        SavePlayerPositionScript(); // save player position so new scene can start in same position
        SceneManager.LoadScene("OneIsocahedron");

    }

    // functions to load scenes with two objects

    public void CallTwoTetra()
    {
        SavePlayerPositionScript(); // save player position so new scene can start in same position
        SceneManager.LoadScene("TwoTetraeder");

    }

    public void CallTwoCube()
    {
        SavePlayerPositionScript(); // save player position so new scene can start in same position
        SceneManager.LoadScene("TwoCube");

    }

    public void CallTwoOcta()
    {
        SavePlayerPositionScript(); // save player position so new scene can start in same position
        SceneManager.LoadScene("TwoOctahedron");

    }

    public void CallTwoDodeca()
    {
        SavePlayerPositionScript(); // save player position so new scene can start in same position
        SceneManager.LoadScene("TwoDodecahedron");
    }

    public void CallTwoIsoca()
    {
        SavePlayerPositionScript(); // save player position so new scene can start in same position
        SceneManager.LoadScene("TwoIsocahedron");

    }

    // functions to load scenes with two different objects inside each other


    public void CallTetraInCube()
    {
        SavePlayerPositionScript(); // save player position so new scene can start in same position
        SceneManager.LoadScene("Cube with Tetraeder");
    }

    public void CallOctaInCube()
    {
        SavePlayerPositionScript(); // save player position so new scene can start in same position
        SceneManager.LoadScene("Cube with Octahedron");
    }

    public void CallIsoInDodeca()
    {
        SavePlayerPositionScript(); // save player position so new scene can start in same position
        SceneManager.LoadScene("Isocahedron vs Dodecahedron");
    }


    // functions to change different settings


    public void ToggleLabels()
    {
        // Save the label toggle, this is referenced in LabelVisiblity.cs
        PlayerPrefs.SetInt("LabelVis", Labels.isOn ? 1 : 0); 
    }

    public void ToggleRunningTotal()
    {
        // Save the runningtotal toggle, this is referenced in RunningTotalVisibility.cs
        PlayerPrefs.SetInt("RunningTotal", RunningTotal.isOn ? 1 : 0);
    }

    public void ToggleRotationMode()
    {
        // enable objects with freerotation tag or fixedrotation tag depending on dropdown option chosen. also adjust running total tracker
        if (RotationMode.value == 0)
        {

            foreach (GameObject freerot in SetupScene.freerotation)
                freerot.SetActive(true);

            foreach (GameObject fixedrot in SetupScene.fixedrotation)
                fixedrot.SetActive(false);

            foreach (GameObject trackrot in SetupScene.rotationtracker)
                trackrot.SetActive(false);

        }
        else if (RotationMode.value == 1)
        {
            foreach (GameObject freerot in SetupScene.freerotation)
                freerot.SetActive(false);
            foreach (GameObject fixedrot in SetupScene.fixedrotation)
                fixedrot.SetActive(true);
            foreach (GameObject trackrot in SetupScene.rotationtracker)
                trackrot.SetActive(RunningTotal.isOn);

        }

    }

}
