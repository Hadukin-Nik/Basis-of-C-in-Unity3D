using Assets.Scripts.Player;
using UnityEngine;

public class BuffPoints : MonoBehaviour, IBuff
{
    private float _time = 100f;
    private float _timeUsed = 0.0f;
    private float _addablePoints = 1.0f;
    private float _step = 1.0f;

    int counter = 0;

    public BuffPoints (float time, float pointsAdd)
    {
        _time = time;
        _addablePoints = pointsAdd;
    }
    bool IBuff.DoAction(ref PlayerList playerList)
    {
        _timeUsed += Time.deltaTime;
        if (_time <= _timeUsed)
        {
            return true;
        }

        if (_timeUsed / _step >= counter + 1)
        {
            playerList.MyPoints += _addablePoints;
            counter++;
        }
        return false;
    }

    void IBuff.DeleteObject()
    {
        Destroy(gameObject);
    }
}
