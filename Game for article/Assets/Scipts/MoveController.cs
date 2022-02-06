using UnityEngine;
public class MoveController : MonoBehaviour
{
    private Camera _camera;
    [Header("Передвижние")]
    [SerializeField] private Transform _bucket;
    [SerializeField] private float _borderValue, _speed;
    [HideInInspector] public bool CanDrag;
    private void Start() => _camera = Camera.main;
    private void OnMouseDrag()
    {
        if (CanDrag)
        {
            Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition); // Получаем координаты мыши
            
            mousePosition.x = mousePosition.x > _borderValue
                ? _borderValue
                : mousePosition.x; // Проверяем, вышел ли курсор за границу 
            mousePosition.x = mousePosition.x < -_borderValue 
                ? -_borderValue 
                : mousePosition.x; // Проверяем, вышел ли курсор за границу 
            
            _bucket.position = Vector3.Lerp(_bucket.position, new Vector2(mousePosition.x, _bucket.position.y),
                _speed * Time.deltaTime); // Перемещаем корзину
        }
    }
}
