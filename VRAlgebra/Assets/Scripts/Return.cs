using UnityEngine;
using UnityEngine.SceneManagement;

public class Return : MonoBehaviour
{
    public GameObject OneObjectMenu;
    public GameObject TwoObjectMenu;
    public GameObject EmbeddedObjectMenu;
    public GameObject MainMenu;
    public GameObject Settings;
    public void CallMainMenu()
    {
        MainMenu.SetActive(true);
        OneObjectMenu.SetActive(false);
        TwoObjectMenu.SetActive(false);
        EmbeddedObjectMenu.SetActive(false);
        Settings.SetActive(false);

    }
}
