using UnityEngine;
using UnityEngine.SceneManagement;

public class Congratulation4 : MonoBehaviour
{
    public void NextlevelGameButton()
    {
        Debug.Log("Next Level");
        SceneManager.LoadScene("Level5");
    }
    public void ReplayGameButtonn()
    {
        Debug.Log("Replay");
        SceneManager.LoadScene("Level4");
    }
    public void returnButton()
    {
        Debug.Log("return");
        SceneManager.LoadScene("Start");
    }

}
