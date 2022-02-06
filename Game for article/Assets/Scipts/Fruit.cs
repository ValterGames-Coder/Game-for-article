using UnityEngine;
public class Fruit : MonoBehaviour
{
    public enum VariableFruits // Тип фрукта
    {
        Bad,
        Good
    }
    
    public VariableFruits VariableFruit;
    private ScoreManager _scoreManager;

    private void Start()
    {
        Destroy(gameObject, 3);
        _scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (VariableFruit == VariableFruits.Good) 
        {
            _scoreManager.Score++;
            if (_scoreManager.Score >= 1)
            {
                _scoreManager.StateLose = 1;
            }
        }
        else if(VariableFruit == VariableFruits.Bad)
        {
            if(_scoreManager.Score > 0) _scoreManager.Score--; 
            else _scoreManager.StateLose = -1; // Если очков 0 то проигрываем
        }
        Destroy(gameObject);
    }
}
