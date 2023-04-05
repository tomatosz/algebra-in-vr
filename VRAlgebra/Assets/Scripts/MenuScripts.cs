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


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SaveCameraPositionScript();
            CallMainMenu();
            SetupScene.RotateToggle = false;
        }
    }

    public void CallMainMenu()
    {
        MainMenu.SetActive(true);
        OneObjectMenu.SetActive(false);
        TwoObjectMenu.SetActive(false);
        EmbeddedObjectMenu.SetActive(false);
        Settings.SetActive(false);
        ConfirmExitMenu.SetActive(false);
    }

    public void SaveCameraPositionScript()
    {
        PlayerPrefs.SetFloat("CamPosx", Camera.main.transform.position.x);
        PlayerPrefs.SetFloat("CamPosy", Camera.main.transform.position.y);
        PlayerPrefs.SetFloat("CamPosz", Camera.main.transform.position.z);
        PlayerPrefs.SetFloat("CamRotx", Camera.main.transform.rotation.eulerAngles.x);
        PlayerPrefs.SetFloat("CamRoty", Camera.main.transform.rotation.eulerAngles.y);
        PlayerPrefs.SetFloat("CamRotz", Camera.main.transform.rotation.eulerAngles.z);
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
            SetupScene.RotateToggle = true;
            MainMenu.SetActive(false);
        }
    }
    public void Exit()
    {
        ConfirmExitMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void CallOneTetra()
    {
        SaveCameraPositionScript();
        SceneManager.LoadScene("OneTetraeder");

    }

    public void CallOneCube()
    {
        SaveCameraPositionScript();
        SceneManager.LoadScene("OneCube");

    }

    public void CallOneOcta()
    {
        SaveCameraPositionScript();
        SceneManager.LoadScene("OneOctahedron");

    }

    public void CallOneDodeca()
    {
        SaveCameraPositionScript();
        SceneManager.LoadScene("OneDodecahedron");
    }

    public void CallOneIsoca()
    {
        SaveCameraPositionScript();
        SceneManager.LoadScene("OneIsocahedron");

    }

    public void CallTwoTetra()
    {
        SaveCameraPositionScript();
        SceneManager.LoadScene("TwoTetraeder");

    }

    public void CallTwoCube()
    {
        SaveCameraPositionScript();
        SceneManager.LoadScene("TwoCube");

    }

    public void CallTwoOcta()
    {
        SaveCameraPositionScript();
        SceneManager.LoadScene("TwoOctahedron");

    }

    public void CallTwoDodeca()
    {
        SaveCameraPositionScript();
        SceneManager.LoadScene("TwoDodecahedron");
    }

    public void CallTwoIsoca()
    {
        SaveCameraPositionScript();
        SceneManager.LoadScene("TwoIsocahedron");

    }

    public void CallTetraInCube()
    {
        SaveCameraPositionScript();
        SceneManager.LoadScene("Cube with Tetraeder");
    }

    public void CallOctaInCube()
    {
        SaveCameraPositionScript();
        SceneManager.LoadScene("Cube with Octahedron");
    }

    public void CallIsoInDodeca()
    {
        SaveCameraPositionScript();
        SceneManager.LoadScene("Isocahedron vs Dodecahedron");
    }

    public void ToggleLabels()
    {
        PlayerPrefs.SetInt("LabelVis", Labels.isOn ? 1 : 0);
    }

    public void ToggleRunningTotal()
    {
        PlayerPrefs.SetInt("RunningTotal", RunningTotal.isOn ? 1 : 0);
    }

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
