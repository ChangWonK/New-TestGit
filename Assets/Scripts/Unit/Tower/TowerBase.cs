using UnityEngine;

public abstract class TowerBase : MonoBehaviour
{
    public enum States { WATING = 0, IDLE, MOVE, ATTACK }

    private States _currentState = States.IDLE;

    public States CurrentState
    {
        set
        {
            _currentState = value;
        }
    }

    public long UID;
    public int LocalIndex;
    public string Name;
    public string Kind;
    public string Rank;
    public int intRank;
    public int Level;
    public int Cost;

    public float AtkPower;
    public float AtkSpeed;
    public float AtkRange;
    public float MoveSpeed;

    public int FirstSkillIndex;
    public int SecondSkillIndex;
    public int ThirdSkillIndex;

    void Start()
    {
        var table = TableManager.i.GetTable<TowerData>(LocalIndex);
        UID = (LocalIndex + 11) / 10;

        Name = table.Name;
        Kind = table.Species;
        Rank = table.Rank;
        Level = table.Level;
        Cost = table.Cost;

        AtkPower = table.AtkPower;
        AtkSpeed = table.AtkSpeed;
        AtkRange = table.AtkRange;
        MoveSpeed = table.MoveSpeed;

        FirstSkillIndex = table.FirstSkillIndex;
        SecondSkillIndex = table.SecondSkillIndex;
        ThirdSkillIndex = table.ThirdSkillIndex;

        SetAility();
    }

    public abstract void SetAility();

    public abstract void Attack(EnemyBase enemy);

    public abstract void Destroy();


}
