using Assets.Scripts.Player;
using UnityEngine;


public class BuffSpeed : MonoBehaviour, IBuff
{
    private float _time = 100f;
    private float _timeUsed = 0.0f;
    private float _addableSpeed = 1.0f;
    private float _step = 1.0f;

    private int _counter = 0;

    public BuffSpeed(float time, float speedAdd)
    {
        _time = time;
        _addableSpeed = speedAdd;
    }
    bool IBuff.DoAction(ref PlayerList playerList)
    {
        _timeUsed += Time.deltaTime;
        if (_timeUsed >= _time)
        {
            playerList.Speed -= _counter * _addableSpeed;
            return true;
        }

        if (_timeUsed / _step >= _counter + 1)
        {
            playerList.Speed += _addableSpeed;
            _counter++;
        }
        return false;
    }

    void IBuff.DeleteObject()
    {
        Destroy(gameObject);
    }
}
