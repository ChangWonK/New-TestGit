using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageGame : UIPopupBase
{
    private List<GameTowerContent> _towerContentList = new List<GameTowerContent>();

    private GameTowerInformation _towerInfo;
    private Tower _getTower;

    private GameObject _contentParent;
    private GameObject _towerKindParent;
    private GameObject _towerRealatedParent;
    private GameObject _enemyRealatedParent;
    private GameObject _towerPrefab;  
    private GameObject _enemyPrefab;

    private Transform _towerParent;
    private Transform _enemyParent;

    private Text _modeTxt;
    private Text _stageTxt;
    private Text _moneyTxt;

    private int _towerMaxCount = 5;
    private int _currentGameLevel = 1;

    void Awake()
    {
        _towerPrefab = Resources.Load<GameObject>(Utility.TowerPrefabPath);
        _enemyPrefab = Resources.Load<GameObject>(Utility.EnemyPrefabPath);

        _towerInfo = GetComponentInChildren<GameTowerInformation>();

        Transform textTrans = transform.Find("Text");
        _modeTxt = GetText("Txt_Mode");
        _stageTxt = GetText("Txt_Stage");
        _moneyTxt = GetText("Txt_Money");

        _towerParent = GameObject.Find("TowerList").transform;
        _enemyParent = GameObject.Find("EnemyList").transform;

        _contentParent = transform.Find("TowerContent").gameObject;
        _towerKindParent = transform.Find("Button").GetChild(0).gameObject;
        _towerRealatedParent = transform.Find("Button").GetChild(1).gameObject;
        _enemyRealatedParent = transform.Find("Button").GetChild(2).gameObject;

        RegistAllButtonOnClickEvent();
    }
    void Start ()
    {
        _modeTxt.text = GameManager.i.GameMode.ToString();
        _stageTxt.text = GameManager.i.GameStageLevel.ToString() + " - " + GameManager.i.GameMapLevel.ToString();
        ActiveBtnParent(true, false, false);
        _towerInfo.gameObject.SetActive(false);

        //////////////test///////////
        UnitManager.i.UITowerBuy<MoveTower>(1);
        //UnitManager.i.UITowerBuy<HumanTower>(21);
        //UnitManager.i.UITowerBuy<HumanTower>(11);
        //////////////test///////////

        for (int i = 0; i < _towerMaxCount; i++)
        {
            _towerContentList.Add(_contentParent.transform.GetChild(i).GetComponent<GameTowerContent>());
            _towerContentList[i].Init();
        }

        ResetUIUpdata();
    }
    private void CreateContent<T>() where T : TowerBase
    {
        List<TowerBase> tower = UserInformation.i.Inventory.GetTower<T>();

        for (int i = 0; i < tower.Count; i++)
        {
            int    index = tower[i].LocalIndex;
            _towerContentList[i].SetUIData(index);
            _towerContentList[i].CallBack = ContentClickEvent<T>;
        }

        for (int i = tower.Count; i < _towerMaxCount; i++)
            _towerContentList[i].SetUIData(0);

        ActiveBtnParent(false, false, true);
    }

    private void SpawnEnemy<T>() where T : EnemyBase
    {
        int hundreds = GameManager.i.GameStageLevel * 100;
        int tens = GameManager.i.GameMapLevel * 10;
        int units = _currentGameLevel;

        int sumIndex = hundreds + tens + units;

        Vector3 pos = TempPoss();

        SpawnManager.i.CreateEnemy<T>(_enemyPrefab, pos, sumIndex, _enemyParent);
    }

    private void UpgradeTowerButton()
    {
        Debug.Log("Upgrade");
        ActiveBtnParent(true, false, false);
    }
    private void SellTowerButton()
    {
        Debug.Log("Sell");
        ActiveBtnParent(true, false, false);
    }
    private void InfoTowerButton()
    {
        Debug.Log("InfoTowerButton");
        ActiveBtnParent(true, false, false);
    }
    private void ActiveBtnParent(bool kindBtn, bool realatedBtn, bool contentBtn)
    {
        _towerKindParent.SetActive(kindBtn);
        _towerRealatedParent.SetActive(realatedBtn);
        _contentParent.SetActive(contentBtn);

        if (_towerRealatedParent.activeSelf == false)
            _towerInfo.gameObject.SetActive(false);
    }

    Vector3 towerPos;
    Vector3 enemyPos;
    private Vector3 TempPos()
    {
        towerPos += new Vector3(1, 0, 0);
        return towerPos;
    }
    private Vector3 TempPoss()
    {
        enemyPos -= new Vector3(1, 0, 0);
        return enemyPos;
    }

    private void ContentClickEvent<T>(int index) where T : TowerBase
    {
        int haveMoney = UserInformation.i.Character.GetGameMoney();
        int Cost = UserInformation.i.Inventory.GetTower(index).Cost;

        if (haveMoney < Cost)
        {
            UIManager.i.CreatePopup<PopupWarning>(POPUP_TYPE.POPUP);
            return;
        }
        Vector3 pos = TempPos();
        var tower = SpawnManager.i.CreateTower<T>(_towerPrefab, pos, index, _towerParent);
        ResetUIUpdata();
        ActiveBtnParent(true, false, false);
    }

    public void TowerClickEvent(Tower tower)
    {
        _getTower = tower;
        _towerInfo.GetTowerInfo(tower);
        _towerInfo.gameObject.SetActive(true);

        ActiveBtnParent(false, true, false);
    }

    public override void ResetUIUpdata()
    {
        int money = UserInformation.i.Character.GetGameMoney();
        _moneyTxt.text = money.ToString();
    }

    protected override void OnButtonClick(string name)
    {
        base.OnButtonClick(name);

        if (name == "Btn_Human")
        {
            CreateContent<MoveTower>();
        }
        if (name == "Btn_Machine")
        {
            CreateContent<MachineTower>();
        }
        if (name == "Btn_Magic")
        {
            CreateContent<MagicTower>();
        }
        if(name == "Btn_Upgrade")
        {
            UpgradeTowerButton();
        }
        if (name == "Btn_Sell")
        {
            SellTowerButton();
        }
        if (name == "Btn_Info")
        {
            InfoTowerButton();
        }
        if( name == "Btn_Return")
        {
            ActiveBtnParent(true, false, false);
        }
        if(name == "Btn_Enemy")
        {
            SpawnEnemy<HumanEnemy>();
        }
    }
}
