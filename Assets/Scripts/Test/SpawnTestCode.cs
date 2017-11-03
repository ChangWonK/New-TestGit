using UnityEngine;

public class SpawnTestCode : MonoBehaviour
{
    private GameObject _towerPrefab;

    void Start()
    {
        _towerPrefab = Resources.Load<GameObject>(Utility.TowerPrefabPath);

        UnitManager.i.UITowerBuy<HumanTower>(1);
        UnitManager.i.UITowerBuy<MachineTower>(101);

        UnitManager.i.ItemBuy(1);
        UnitManager.i.ItemBuy(101);

        UnitManager.i.ItemMounting(1);
        UnitManager.i.ItemMounting(2);

        UserInformation.i.Character.Init();
    }

    private void BuildTower<T>(int index) where T : TowerBase, new()
    {
        var towerObj = Instantiate(_towerPrefab);

        Tower newTower = towerObj.AddComponent<Tower>();

        newTower = SpawnManager.i.BuildTower<T>(newTower, index);
    }

    private void DestroyTower(Tower tower)
    {
        SpawnManager.i.DestroyTower(tower);
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 100), "human ADD"))
        {
            BuildTower<HumanTower>(1);
        }

        if (GUI.Button(new Rect(0, 200, 100, 100), "machine ADD"))
        {
            BuildTower<MachineTower>(11);
        }

        if (GUI.Button(new Rect(0, 400, 100, 100), "human Remove"))
        {
            var tower = SpawnManager.i.GetTower<HumanTower>();
            SpawnManager.i.DestroyTower(tower);
        }

        if (GUI.Button(new Rect(0, 600, 100, 100), "machine Remove"))
        {
            var tower = SpawnManager.i.GetTower<MachineTower>();
            SpawnManager.i.DestroyTower(tower);
        }

        if (GUI.Button(new Rect(1180, 000, 100, 100), "human Attack"))
        {
            SpawnManager.i.GetTower<HumanTower>().Attack();
        }
        if (GUI.Button(new Rect(1180, 200, 100, 100), "machine Attack"))
        {
            SpawnManager.i.GetTower<MachineTower>().Attack();
        }
    }
}
