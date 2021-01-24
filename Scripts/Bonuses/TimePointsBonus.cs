using Assets.Scripts.Player;

public class TimePointsBonus : IAction
{
    protected TimeEffect _effectOfBonus;
    protected float _addedPointsForDelete =0.0f;

    protected bool _ifThetemporary = false;
    public TimePointsBonus(TimeEffect effectOfBonus) 
    {
        _effectOfBonus = effectOfBonus;
    }
    public void DoAction(ref PlayerList _playerList)
    {
        _playerList.MyPoints += _effectOfBonus.AddableStepPoints;
        _addedPointsForDelete += _effectOfBonus.AddableStepPoints;
    }


    public void StopMyEffects(ref PlayerList _playerList)
    {
        if (_ifThetemporary)
        {
            _playerList.MyPoints -= _addedPointsForDelete;
        }
    }
}
