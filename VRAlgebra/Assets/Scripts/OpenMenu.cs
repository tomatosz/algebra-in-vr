using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMenu : MonoBehaviour
{
    public SaveCameraPosition SavePosition;
    public GameObject OneObjectMenu;
    public GameObject TwoObjectMenu;
    public GameObject EmbeddedObjectMenu;
    public GameObject MainMenu;
    public GameObject Settings;
    static public bool Rotation;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SavePosition.SaveCameraPositionScript();
            MainMenu.SetActive(true);
            OneObjectMenu.SetActive(false);
            TwoObjectMenu.SetActive(false);
            EmbeddedObjectMenu.SetActive(false);
            Settings.SetActive(false);
            Rotation = false;
        }
    }
}
