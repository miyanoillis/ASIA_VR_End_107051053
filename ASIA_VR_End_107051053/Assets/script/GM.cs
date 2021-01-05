using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public enmy boolstart;

    public void restart()
    {
        SceneManager.LoadScene("vrgame1");
    }

    public void exit()
    {
        Application.Quit();
    }
    public void start()
    {
        boolstart.start = true;
    }
}
