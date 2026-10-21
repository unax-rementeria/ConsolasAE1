using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }

    public void gameStart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void gameMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
