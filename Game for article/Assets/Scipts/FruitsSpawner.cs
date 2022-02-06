using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FruitsSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _fruits;
    [SerializeField] private Vector2 _maxValue;
    [SerializeField] private float _timeSpawn;
    [SerializeField] private ScoreManager _scoreManager;
    private void Start() => StartCoroutine(Spawn());
    
    private IEnumerator Spawn()
    {
        while (_scoreManager.Lose == false) // Спавнить пока очков не больше 10 или не проиграли 
        {
            var fruitIndex = Random.Range(0, _fruits.Count);
            var spawnPosition = new Vector2(Random.Range(-_maxValue.x, _maxValue.x), _maxValue.y);
            Instantiate(_fruits[fruitIndex], spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(_timeSpawn);
        }
    }
}
