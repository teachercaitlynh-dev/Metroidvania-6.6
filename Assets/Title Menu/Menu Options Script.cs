using UnityEngine;

public class MenuOptionsScript : MonoBehaviour
{

    public void Play(int sceneNumber)
    {
        Cursor.visible = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNumber);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
