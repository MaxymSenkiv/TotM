using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreCounter;

    public int Score = 0;
    
    void Start()
    {
        _scoreCounter = this.GetComponent<TextMeshProUGUI>();
    }

    public void ChangeScore(int addition)
    {
        Score += addition;
        _scoreCounter.SetText("Score: {0}", Score);
    }
}
