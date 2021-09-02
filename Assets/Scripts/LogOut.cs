using UnityEngine;
using UnityEngine.SceneManagement;

public class LogOut : MonoBehaviour
{
    public void LogOutButton()
    {
        PlayerPrefs.SetInt("isLoggedIn", 0);
        SceneManager.LoadScene(0);
    }
}