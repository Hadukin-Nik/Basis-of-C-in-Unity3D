using Assets.Scripts.Player;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
    private const string _horizontalAxisString = "Horizontal", _verticalAxisString = "Vertical";
    [System.NonSerialized] public PlayerList _playerList = new PlayerList(0.0f);
    [SerializeField] private float _speed = 1.0f;

    private Rigidbody _rigidbody;

    private Vector3 _directionOfMove;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerList.Speed = _speed;
    }

    private void Update()
    {
        UpdateDirectionOfMove();
    }

    private void FixedUpdate()
    {
        Move();
        UpdateBuffs();
    }

    private void UpdateDirectionOfMove()
    {
        float moveHorizontal = Input.GetAxis(_horizontalAxisString);
        float moveVertical = Input.GetAxis(_verticalAxisString);

        _directionOfMove = new Vector3(moveHorizontal, 0.0f, moveVertical);
    }

    private void Move()
    {
        _rigidbody.AddForce(_directionOfMove * _playerList.Speed);
    }

    private void UpdateBuffs()
    {
        for (int i =0; i < _playerList._buffs.Count; i++)
        {
            IBuff buff = _playerList._buffs[i];
            if (buff.DoAction(ref _playerList))
            {
                IBuff temp = buff;
                _playerList._buffs.RemoveAt(i);
                temp.DeleteObject();
            }
        }
    }
}
