
public class TowerBase : Unit
{
    public float AtkPower;
    public float AtkSpeed;
    public float AtkRange;
    public float MoveSpeed;

    public TowerBase(int index)
    {
        var table = TableManager.i.GetTable<TowerData>(index);

        UID = (index + 11) / 10;
        LocalIndex = index;
        Name = table.Name;
        Kind = table.Species;
        Rank = table.Rank;
        //intRank = table.intRank;
        Level = table.Level;
        Cost = table.Cost;

        AtkPower = table.AtkPower;
        AtkSpeed = table.AtkSpeed;
        AtkRange = table.AtkRange;
        MoveSpeed = table.MoveSpeed;
    }

    public TowerBase()
    {
    }

    public virtual void SetAtkPower() { }
    public virtual void SetAtkSpeed() { }
    public virtual void SetAtkMoveSpeed() {  }


}
