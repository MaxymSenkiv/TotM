using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]  private PlayerMove movement;
    [SerializeField] private float RestartDelay = 1f;
    public void GameOver()
    {
        movement.enabled = false;
        Debug.Log("GAME OVER");
        Invoke("Restart", RestartDelay);
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        movement.enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
