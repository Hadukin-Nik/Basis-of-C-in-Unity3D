using Assets.Scripts.Player;
using UnityEngine;
public class BaseBonus : MonoBehaviour
{
    [SerializeField] private float _timeLiveOfBuff = 10.0f;
    [SerializeField] private float _forceOfBuff = 1.0f;
    [SerializeField] private int _addablePoints = 0;

    private GameObject Row1;
    private enum BuffType { BuffPoints = 1, BuffSpeed = 2 };
    [SerializeField] private BuffType buffType;

    public void DoAction(ref PlayerList _playerList)
    {
        _playerList.MyPoints += _addablePoints;
        Row1 = new GameObject();
        IBuff ibuff;
        if ((int)buffType == 0)
        {
            BuffPoints newBuff = Row1.AddComponent<BuffPoints>();
            newBuff = new BuffPoints(_timeLiveOfBuff, _forceOfBuff);
            ibuff = newBuff;
            
        } else
        {
            BuffSpeed newBuff = Row1.AddComponent<BuffSpeed>();
            newBuff = new BuffSpeed(_timeLiveOfBuff, _forceOfBuff);
            ibuff = newBuff;
        }

        _playerList._buffs.Add(ibuff);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            DoAction(ref playerController._playerList);
            Destroy(gameObject);
        }
    }
}
