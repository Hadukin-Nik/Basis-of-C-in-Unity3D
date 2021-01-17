using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
    private const string _horizontalAxisString = "Horizontal", _verticalAxisString = "Vertical";

    [SerializeField] private float _speed = 1.0f;

    private Rigidbody _rigidbody;

    private Vector3 _directionOfMove;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        UpdateDirectionOfMove();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void UpdateDirectionOfMove()
    {
        float moveHorizontal = Input.GetAxis(_horizontalAxisString);
        float moveVertical = Input.GetAxis(_verticalAxisString);

        _directionOfMove = new Vector3(moveHorizontal, 0.0f, moveVertical);
    }

    private void Move()
    {
        _rigidbody.AddForce(_directionOfMove * _speed);
    }
}
