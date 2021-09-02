using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneWhenUserAuthenticated : MonoBehaviour
{
    [SerializeField] private int sceneToLoad = 1;

    private void Start()
    {
        var isLoggedIn = PlayerPrefs.GetInt("isLoggedIn", 0) == 1;
        if (isLoggedIn)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}