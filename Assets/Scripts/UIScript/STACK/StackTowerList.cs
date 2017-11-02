
public class StackTowerList : UIPopupBase
{
    enum TabBtn
    {
        HUMAN, MACHINE, MAGIC, BUF
    }

    private ContentScrollView _scrollView;
    private TowerInformation _information;
    private TabButton _tabButton;

    private int _preSelectIndex = 0;

    void Awake()
    {
        _scrollView = GetComponentInChildren<ContentScrollView>();
        _information = GetComponentInChildren<TowerInformation>();
        _tabButton = GetComponentInChildren<TabButton>();
    }

    void Start()
    {
        _scrollView.Init<TowerContent>(ScrollViewAxis.HORIZONTAL, ScrollContentKind.TOWER);

        _tabButton.AddListener(0, () => SetContentInfo(1, 3,0));
        _tabButton.AddListener(1, () => SetContentInfo(101, 3,1));
        _tabButton.AddListener(2, () => SetContentInfo(201, 3,2));
        _tabButton.AddListener(3, () => SetContentInfo(301, 3,3));

        _tabButton.Initialize(_preSelectIndex);
    }

    private void SetContentInfo(int kindIndex, int dataCount, int preIndex)
    {
        _preSelectIndex = preIndex;

        int lineCount = 1;
        _scrollView.SetScrollView(kindIndex, dataCount, lineCount);
    }

    public override void ResetUIUpdata()
    {
        base.ResetUIUpdata();
        _tabButton.Initialize(_preSelectIndex);
    }
}
