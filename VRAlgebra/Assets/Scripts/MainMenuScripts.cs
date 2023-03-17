using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScripts : MonoBehaviour
{
    public void CallOneObjectMenu()
    {
        SceneManager.LoadScene("OneObjectMenu");
    }

    public void CallTwoObjectMenu()
    {
        SceneManager.LoadScene("TwoObjectMenu");
    }

    public void CallEmbeddedObjectMenu()
    {
        SceneManager.LoadScene("EmbeddedObjectMenu");
    }
}
