using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerMove _movement;

    [SerializeField] private GameObject _winMenuUI;
    [SerializeField] private GameObject _loseMenuUI;

    private void Start()
    {
        Time.timeScale = 1;
    }

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Win()
    {
        Time.timeScale = 0;
        _winMenuUI.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
