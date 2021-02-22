using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float padding;
    

    private Vector2 _minBoundary;
    private Vector2 _maxBoundary;

    private void Start()
    {
        SetupBoundaries();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        var position = transform.position;
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var newXPos = Mathf.Clamp(position.x + deltaX, _minBoundary.x, _maxBoundary.x);
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        var newYPos = Mathf.Clamp(position.y + deltaY, _minBoundary.y, _maxBoundary.y);

        transform.position = new Vector2(newXPos, newYPos);
    }
    
    private void SetupBoundaries()
    {
        var camera = Camera.main;

        var leftBotCorner = camera.ViewportToWorldPoint(new Vector2(0, 0));
        var rightTopCorner = camera.ViewportToWorldPoint(new Vector2(1, 1));

        _minBoundary = new Vector2(leftBotCorner.x + padding, leftBotCorner.y + padding);
        _maxBoundary = new Vector2(rightTopCorner.x - padding, rightTopCorner.y - padding);
    }
}
