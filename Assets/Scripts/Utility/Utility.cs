using UnityEngine;
using System.Text;
using System.Collections.Generic;

public class Utility : SingleTone<Utility>
{
    public  StringBuilder TextBuilder = new StringBuilder(256);
    public long ItemUID = 0;

    public long GetNextUID()
    {
        ItemUID++;
        return ItemUID;
    }

    public const string Name = "이름 : ";
    public const string Kind = "종류 : ";
    public const string Rank = "등급 : ";
    public const string Level = "레벨 : ";
    public const string Cost = "비용 : ";

    public const string LevelGrade = "Lv.";

    public const string ImagePath = "Texture/Item/";
    public const string ImageName = "Item";

    public const string TowerPath = "Texture/Tower/";
    public const string TowerName = "Tower";

    public const string TowerContentPath = "Prefabs/UI/ScrollItem/TowerContent";
    public const string ItemContentPath = "Prefabs/UI/ScrollItem/ItemContent";

    public const string ItemNull = "Cancle";

    public const string UpgradeQuestion = "업그레이드를 진행하시겠습니까?";
    public const string SellQuestion = "판매를 진행하시겠습니까?";
    public const string BuyQuestion = "구입을 진행하시겠습니까?";

    public const string TowerPrefabPath = "Prefabs/3DObject/Tower/TowerPrefab";



}


