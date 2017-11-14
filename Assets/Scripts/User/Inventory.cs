using System.Collections.Generic;

// 내가 가지고 있는 모든 것에 대한 정보를 가지고 있는 클래스
public class Inventory
{
    private Dictionary<long, Item> _itemDic = new Dictionary<long, Item>();
    private Dictionary<long, Item> _mountingItemDic = new Dictionary<long, Item>();
    private List<TowerBase> _towerList = new List<TowerBase>();
    public int Money = 411110;
    public int Cash;
    private string _toMountItemKind;

    public void AddItem(Item item)
    {
        _itemDic.Add(item.UID, item);
    }

    public void RemoveItem(long uid)
    {
        if (_mountingItemDic.ContainsKey(uid))
            _mountingItemDic.Remove(uid);

        _itemDic.Remove(uid);
    }

    public Item GetItem(long uid)
    {
        return _itemDic[uid];
    }

    public int GetItemCount()
    {
        return _itemDic.Count;
    }

    public List<Unit> GetKindItemList(string kind)
    {
        List<Unit> returnItemList = new List<Unit>();
        var enumer = _itemDic.GetEnumerator();

        while (enumer.MoveNext())
        {
            var pair = enumer.Current;

            if (pair.Value.Kind == kind)
                returnItemList.Add(pair.Value);
        }

        return returnItemList;
    }

    public void AddMountingItem(long uid, Item item)
    {
        _mountingItemDic.Add(uid, item);
    }

    public void RemoveMountingItem(long uid)
    {
        _mountingItemDic.Remove(uid);
    }

    public int GetIMountingtemCount()
    {
        return _mountingItemDic.Count;
    }

    public Item FindMountingItem(long uid)
    {
        if (_mountingItemDic.ContainsKey(uid))
        {
            return _mountingItemDic[uid];
        }

        return null;
    }
    string findItemKindStr;
    public long GetCheckMountItemUID(long uid)
    {
        int ringCount = 0;
        long returnValue = 0;
        _toMountItemKind = _itemDic[uid].Kind;

        var erator = _mountingItemDic.GetEnumerator();

        while (erator.MoveNext())
        {
            var pair = erator.Current;

            findItemKindStr = _mountingItemDic[pair.Key].Kind;

            if(_toMountItemKind == findItemKindStr)
            {
                returnValue = pair.Key;
                if(findItemKindStr == "Ring")
                {
                    ringCount++;
                }
            }
        }

        if(_toMountItemKind == "Ring")
        {
            if (ringCount < 2)
                returnValue = 0;
        }


        return returnValue;
    }

   

    public Dictionary<long, Item>.Enumerator GetEnumerMountingItemDic()
    {
        return _mountingItemDic.GetEnumerator();
    }

    public void AddTower(TowerBase tower)
    {
        _towerList.Add(tower);
    }

    public void RemoveTower(TowerBase tower)
    {
        _towerList.Remove(tower);
    }

    public TowerBase GetTower(long uid)
    {
        return _towerList.Find((c) => c.UID == uid);
    }
    public TowerBase GetTower(int index)
    {
        return _towerList.Find((c) => c.LocalIndex == index);
    }

    public T GetTower<T>(long uid) where T : TowerBase
    {
        return _towerList.Find((c) => c.UID == uid) as T;
    }

    public List<TowerBase> GetTower<T>() where T : TowerBase
    {
       List<TowerBase> tower = _towerList.FindAll((c) => c is T);

        tower.Sort((c, d) =>
        {
            if (c.LocalIndex > d.LocalIndex) return 1;
            else if (c.LocalIndex < d.LocalIndex) return -1;
            else return 0;
        });

        return tower;
    }
       

}
