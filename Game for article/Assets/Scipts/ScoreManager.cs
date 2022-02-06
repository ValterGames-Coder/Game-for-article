using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    public int StateLose; // -1 - Проигрышь, 0 - ничего, 1 Победа
    public bool Lose;
    public int Score;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private GameObject _losePanel, _winPanel;
    [SerializeField] private MoveController _moveController;

    private void Start() => StateLose = 0;
    private void Update()
    {
        _scoreText.text = $"Score: {Score}";
        _losePanel.SetActive(Lose);
        _moveController.CanDrag = !Lose;
        _winPanel.SetActive(StateLose == 1);
        IsItALose();
    }
    
    private void IsItALose()
    {
        if (StateLose == -1) Lose = true;
        else if (Score >= 1) Lose = false;
        else Lose = false;
    }
    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
