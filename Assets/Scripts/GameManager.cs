using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerMove _movement;

    [SerializeField] private GameObject _winMenuUI;
    [SerializeField] private GameObject _loseMenuUI;

    public void GameOver()
    {
        _movement.enabled = false;
        _loseMenuUI.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void LoadNextLevel()
    {
        _movement.enabled = false;
        _winMenuUI.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
