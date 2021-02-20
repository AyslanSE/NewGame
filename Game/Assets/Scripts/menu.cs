using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public string sceneselected;
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
        sceneselected = scene;
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}