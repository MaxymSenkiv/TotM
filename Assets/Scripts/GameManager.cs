using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _winMenuUI;
    [SerializeField] private GameObject _loseMenuUI;

    private void Start()
    {
        Time.timeScale = 1;
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1.5f);
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
