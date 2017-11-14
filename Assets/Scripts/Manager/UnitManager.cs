using UnityEngine;
using System.Collections.Generic;

public class UnitManager : Singleton<UnitManager>
{
    public bool ItemBuy(int index, int money)
    {
        int cost =  TableManager.i.GetTable<ItemData>(index).Cost;

        if(cost > money)
        {
            return false;
        }

        Item newItem = CreateNewItem(index);

        newItem.UID = Utility.i.GetNextUID();
        UserInformation.i.Inventory.Money -= newItem.Cost;
        UserInformation.i.Inventory.AddItem(newItem);

        return true;
    }

    public void ItemSell(long uid)
    {
        float invenCost = UserInformation.i.Inventory.GetItem(uid).Cost;
        invenCost *= 0.5f;

        UserInformation.i.Inventory.Money += (int)invenCost;
        UserInformation.i.Inventory.RemoveItem(uid);
    }

    public void MountItem(long uID)
    {
        var item = UserInformation.i.Inventory.GetItem(uID);

        UserInformation.i.Inventory.AddMountingItem(uID, item);
    }

    //public void ToMountingItem(long uID)
    //{
    //    Inventory inven = UserInformation.i.Inventory;
    //    _kindItem = inven.GetItem(uID).Kind;

    //    var enumeratorItemDic = inven.GetEnumerMountingItemDic();

    //    string findKindItem;
    //    while (enumeratorItemDic.MoveNext())
    //    {
    //        var pair = enumeratorItemDic.Current;
    //        findKindItem = inven.FindMountingItem(pair.Key).Kind;

    //        if (findKindItem == _kindItem)
    //        {
    //            if (findKindItem != "Ring")
    //            {
    //                inven.RemoveMountingItem(pair.Key);
    //            }
    //            else if (findKindItem == "Ring")
    //            {
    //                if(_isMountingRing)
    //                {
    //                    inven.RemoveMountingItem(pair.Key);
    //                }
    //                else
    //                {
    //                    _isMountingRing = true;
    //                }
    //            }
    //            break;
    //        }
    //    }
    //    UserInformation.i.Inventory.AddMountingItem(uID, inven.GetItem(uID));
    //}

    public void RealeaseItem(long uID)
    {
        if (uID == 0) return;
        var findItem = UserInformation.i.Inventory.FindMountingItem(uID);

        UserInformation.i.Inventory.RemoveMountingItem(uID);
    }

    public Item ItemCombination(Item upgradeItem, Item consumableItem, int probabilityNum)
    {
        if (upgradeItem.Level >= 10) return null;

        Inventory inven = UserInformation.i.Inventory;

        inven.RemoveItem(consumableItem.UID);

        int ranNum = Random.Range(1, 101);
        int compareNum = 100 - probabilityNum;

        if (ranNum >= compareNum)
        {
            int nextLevel = upgradeItem.LocalIndex + 1;

            Item ee = new Item(nextLevel, Utility.i.GetNextUID());

            inven.AddItem(ee);

            Item newItem = inven.GetItem(Utility.i.ItemUID);

            if (inven.FindMountingItem(upgradeItem.UID) != null)
            {
                inven.AddMountingItem(newItem.UID, newItem);
            }

            inven.RemoveItem(upgradeItem.UID);

            return newItem;
        }

        else
        {
            return upgradeItem;
        }
    }

    public void UITowerBuy<T>(int index) where T : TowerBase
    {
        GameObject tempObject = new GameObject();

        T newTower = tempObject.AddComponent<T>();

        newTower.LocalIndex = index;

            UserInformation.i.Inventory.AddTower(newTower);
    }

    public int UITowerUpgrade(long uid)
    {
        var tower = UserInformation.i.Inventory.GetTower(uid);

        int nextIndex = tower.LocalIndex++;

        tower.LocalIndex = nextIndex;

        return tower.LocalIndex;
    }


    private Item CreateNewItem(int index)
    {
        Item newItem = new Item(index);

        return newItem;
    }

}
