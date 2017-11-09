public class GameTowerInformation : UIObject
{
    public void GetTowerInfo(Tower tower)
    {
        TowerBase GetTowerBase = tower.TowerBase;

        GetText("Txt_Name").text = GetTowerBase.Name;
        GetText("Txt_Kind").text = GetTowerBase.Kind;
        GetText("Txt_Level").text = GetTowerBase.Level.ToString();
        GetText("Txt_Rank").text = GetTowerBase.Rank;
        GetText("Txt_AtkPower").text = GetTowerBase.AtkPower.ToString();
        GetText("Txt_AtkSpeed").text = GetTowerBase.AtkSpeed.ToString();
        GetText("Txt_AtkRange").text = GetTowerBase.AtkRange.ToString();
        GetText("Txt_MoveSpeed").text = GetTowerBase.MoveSpeed.ToString();
    }
}
