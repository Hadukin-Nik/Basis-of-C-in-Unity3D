using Assets.Scripts.Player;
using UnityEngine;
public class BaseBonus : MonoBehaviour
{
    [SerializeField] private int _addablePoints = 0;
    private GameObject Row1;
    private enum BuffType { BuffPoints = 1, BuffSpeed = 2 };
    [SerializeField] private BuffType buffType;

    public void DoAction(ref PlayerList _playerList)
    {
        _playerList.MyPoints += _addablePoints;
        Row1 = new GameObject();
        Row1 = Instantiate(Row1, transform.position, Quaternion.identity);
        IBuff ibuff;
        if ((int)buffType == 0)
        {
            Row1.AddComponent<BuffPoints>();
            ibuff = Row1.GetComponent<BuffPoints>();
            
        } else
        {
            Row1.AddComponent<BuffSpeed>();
            ibuff = Row1.GetComponent<BuffPoints>();
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
