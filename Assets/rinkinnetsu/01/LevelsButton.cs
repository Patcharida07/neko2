using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsButton : MonoBehaviour
{
    public void GameButton()
    {
        Debug.Log("1");
        SceneManager.LoadScene("Level1");
    }
    public void erGameButton()
    {
        Debug.Log("2");
        SceneManager.LoadScene("Level2");
    }
    public void sannGameBotton()
    {
        Debug.Log("3");
        SceneManager.LoadScene("Level3");
    }
    public void siGameBotton()
    {
        Debug.Log("4");
        SceneManager.LoadScene("Level4");
    }
    public void wuGameBotton()
    {
        Debug.Log("5");
        SceneManager.LoadScene("Level5");
    }
    public void returnButton()
    {
        Debug.Log("return");
        SceneManager.LoadScene("Start");
     }
}
