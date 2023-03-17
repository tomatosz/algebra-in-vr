using UnityEngine;
using UnityEngine.SceneManagement;

public class Return : MonoBehaviour
{
    public void CallMainMenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }
}
