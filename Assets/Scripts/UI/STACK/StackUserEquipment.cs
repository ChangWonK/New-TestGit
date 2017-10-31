using System.Collections.Generic;
using UnityEngine.UI;

public class StackUserEquipment : UIPopupBase
{
    private enum EquipmentKind { PITCHING=0, WEAPON, GLOVES, FIRSTRING, SECONDRING,SHOES}

    private List<Unit> _showItemList = new List<Unit>();

    private InfinityScrollView _scrollView;
    private TabButton _tabButton;

    private ItemContent[] _equipmentContentArray= new ItemContent[5];

    private string _preSelectKind;
    private bool _isMountingRing = false;

    void Awake()
    {
        _equipmentContentArray = GetComponentsInChildren<ItemContent>();
        _scrollView = GetComponentInChildren<InfinityScrollView>();
        _tabButton = GetComponentInChildren<TabButton>();
    }

    void Start()
    {
        CreateContent();

        _tabButton.AddListener(0, () => SetContentInfo("Pitching"));
        _tabButton.AddListener(1, () => SetContentInfo("Weapon"));
        _tabButton.AddListener(2, () => SetContentInfo("Gloves"));
        _tabButton.AddListener(3, () => SetContentInfo("Ring"));
        _tabButton.AddListener(4, () => SetContentInfo("Shoes"));

        _tabButton.Initialize(0);
    }

    private void CreateContent()
    {
        _scrollView.CreateContent(ContentIndex.ITEM);
    }

    private void SetContentInfo(string kind)
    {
        _preSelectKind = kind;

        DisuniteKindItem(kind);

        _scrollView.SetScrollView<ItemContent>(_showItemList);

        SetEquipmentContentInfo();
    }

    private void DisuniteKindItem(string kind)
    {
        var enumer = UserInformation.i.Inventory.GetEnumerMountingItemDic();

        _showItemList = UserInformation.i.Inventory.GetKindItemList(kind);

        while (enumer.MoveNext())
        {
            if(enumer.Current.Value.Kind == kind)
            {
                _showItemList.Remove(enumer.Current.Value);
            }
        }
    }

    private void SetEquipmentContentInfo()
    {
        for (int i = 0; i < _equipmentContentArray.Length; i++)
        {
            _equipmentContentArray[i].SetUIData(0);
            _equipmentContentArray[i].GetComponent<Button>().enabled = false;
        }

        if (UserInformation.i.Inventory.GetIMountingtemCount() <= 0) return;

        _isMountingRing = false;

        var enumeratorItemDic = UserInformation.i.Inventory.GetEnumerMountingItemDic();

        while (enumeratorItemDic.MoveNext())
        {
            var pair = enumeratorItemDic.Current;

            int index = UserInformation.i.Inventory.FindMountingItem(pair.Key).LocalIndex;
            long uid = UserInformation.i.Inventory.FindMountingItem(pair.Key).UID;

            if (index <= 100)
            {
                _equipmentContentArray[(int)EquipmentKind.PITCHING].GetComponent<Button>().enabled = true;
                _equipmentContentArray[(int)EquipmentKind.PITCHING].SetUIData(index, uid);
            }
            if (index <= 200 && index > 100)
            {
                _equipmentContentArray[(int)EquipmentKind.WEAPON].GetComponent<Button>().enabled = true;
                _equipmentContentArray[(int)EquipmentKind.WEAPON].SetUIData(index, uid);
            }
            if (index <= 300 && index > 200)
            {
                _equipmentContentArray[(int)EquipmentKind.GLOVES].GetComponent<Button>().enabled = true;
                _equipmentContentArray[(int)EquipmentKind.GLOVES].SetUIData(index, uid);
            }
            if (index <= 400 && index > 300)
            {
                if (_isMountingRing == false)
                {
                    _equipmentContentArray[(int)EquipmentKind.FIRSTRING].GetComponent<Button>().enabled = true;
                    _equipmentContentArray[(int)EquipmentKind.FIRSTRING].SetUIData(index, uid);
                    _isMountingRing = true;
                }
                else if(_isMountingRing == true)
                {
                    _equipmentContentArray[(int)EquipmentKind.SECONDRING].GetComponent<Button>().enabled = true;
                    _equipmentContentArray[(int)EquipmentKind.SECONDRING].SetUIData(index, uid);
                }
            }
            if (index <= 500 && index > 400)
            {
                _equipmentContentArray[(int)EquipmentKind.SHOES].GetComponent<Button>().enabled = true;
                _equipmentContentArray[(int)EquipmentKind.SHOES].SetUIData(index, uid);
            }
        }
    }

    public override void ResetUIUpdata()
    {
        base.ResetUIUpdata();
        SetContentInfo(_preSelectKind);
    }
}
