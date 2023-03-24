using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMenu : MonoBehaviour
{
    public SaveCameraPosition SavePosition;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SavePosition.SaveCameraPositionScript();
            SceneManager.LoadScene("MainMenu");
        }
    }
}
