using UnityEngine;
using UnityEngine.SceneManagement;

public class Congratulation31 : MonoBehaviour
{
    public void NextlevelGameButton()
    {
        Debug.Log("Next Level");
        SceneManager.LoadScene("Level4");
    }
    public void ReplayGameButtonn()
    {
        Debug.Log("Replay");
        SceneManager.LoadScene("Level3");
    }
    public void returnButton()
    {
        Debug.Log("return");
        SceneManager.LoadScene("Start");
    }

}
