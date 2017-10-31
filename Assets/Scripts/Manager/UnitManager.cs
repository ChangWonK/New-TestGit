﻿using UnityEngine;

public class UnitManager : Singleton<UnitManager>
{
    private bool _isMountingRing = false;
    private string _kindItem = "";

    public void ItemBuy(int index)
    {
        Item newItem = new Item(index);

        Utility.i.GetNextUID();

        UserInformation.i.Inventory.AddItem(Utility.i.ItemUID, newItem);
    }

    public void ItemSell(long uID)
    {
        UserInformation.i.Inventory.RemoveItem(uID);
    }

    public void ItemMounting(long uID)
    {
        Inventory inven = UserInformation.i.Inventory;
        _kindItem = inven.FindItem(uID).Kind;

        var enumeratorItemDic = inven.GetEnumerMountingItemDic();

        string findKindItem;
        while (enumeratorItemDic.MoveNext())
        {
            var pair = enumeratorItemDic.Current;
            findKindItem = inven.FindMountingItem(pair.Key).Kind;

            if (findKindItem == _kindItem)
            {
                if (findKindItem != "Ring")
                {
                    inven.RemoveMountingItem(pair.Key);
                }
                else if (findKindItem == "Ring")
                {
                    if(_isMountingRing)
                    {
                        inven.RemoveMountingItem(pair.Key);
                    }
                    else
                    {
                        _isMountingRing = true;
                    }
                }
                break;
            }
        }
        UserInformation.i.Inventory.AddMountingItem(uID, inven.FindItem(uID));
    }
    
    public void ItemRealease(long uID)
    {
        if(UserInformation.i.Inventory.FindMountingItem(uID).Kind == "Ring")
            _isMountingRing = false;

        UserInformation.i.Inventory.RemoveMountingItem(uID);
    }

    public Item ItemCombination(Item upgradeItem, Item consumableItem, int probabilityNum)
    {
        if (upgradeItem.Level >= 10) return null;

        UserInformation.i.Inventory.RemoveItem(consumableItem.UID);

        int ranNum = Random.Range(1, 101);
        int compareNum = 100 - probabilityNum;

        if (ranNum >= compareNum)
        {
            int nextLevel = upgradeItem.LocalIndex + 1;

            ItemBuy(nextLevel);

            Item newItem = UserInformation.i.Inventory.FindItem(Utility.i.ItemUID);

            if (UserInformation.i.Inventory.FindMountingItem(upgradeItem.UID) != null)
            {
                UserInformation.i.Inventory.AddMountingItem(newItem.UID, newItem);
            }

            UserInformation.i.Inventory.RemoveItem(upgradeItem.UID);

            return newItem;
        }

        else
        {
            return upgradeItem;
        }
    }

    public void TowerBuy(int index)
    {
        TowerBase newTower = new TowerBase(index);

        UserInformation.i.Inventory.AddTower(newTower);
    }

    public int TowerUpgrade(long uid)
    {
        var tower = UserInformation.i.Inventory.FindTower(uid);
        tower.LocalIndex++;
        tower.Level++;

        return tower.LocalIndex;
    }


}