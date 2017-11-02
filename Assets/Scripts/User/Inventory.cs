using System.Collections.Generic;

// 내가 가지고 있는 모든 것에 대한 정보를 가지고 있는 클래스
public class Inventory
{
    private Dictionary<long, Item> _itemDic = new Dictionary<long, Item>();
    private Dictionary<long, Item> _mountingItemDic = new Dictionary<long, Item>();
    private List<TowerBase> _towerList = new List<TowerBase>();

    public void AddItem(long uid, Item item)
    {
        item.UID = uid;
        _itemDic.Add(uid, item);
    }

    public void RemoveItem(long uid)
    {
        if (_mountingItemDic.ContainsKey(uid))
            _mountingItemDic.Remove(uid);

        _itemDic.Remove(uid);
    }

    public Item FindItem(long uid)
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

    public Dictionary<long, Item>.Enumerator GetEnumerItemDic()
    {
        return _itemDic.GetEnumerator();
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

    public TowerBase FindTower(long uid)
    {
        return _towerList.Find((c) => c.UID == uid);
    }

    public T FindTower<T>(long uid) where T : TowerBase
    {
        return _towerList.Find((c) => c.UID == uid) as T;
    }

    //public T FetchTower<T>(long uid) where T : TowerBase, new()
    //{
    //    T tower = _towerList.Find((c) => c.UID == uid) as T;

    //    return new T() ;
    //}

}
