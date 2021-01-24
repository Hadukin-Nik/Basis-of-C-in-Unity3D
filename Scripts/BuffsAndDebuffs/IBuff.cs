using Assets.Scripts.Player;

public interface IBuff
{
    bool DoAction(ref PlayerList playerList);
    void DeleteObject();
}
