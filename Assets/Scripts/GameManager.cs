using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerMove _movement;

    [SerializeField] private float _restartDelay = 1f;

    public void GameOver()
    {
        _movement.enabled = false;
        Debug.Log("GAME OVER");
        Invoke("Restart", _restartDelay);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        _movement.enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
