using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InfinityScrollView : MonoBehaviour
{
    public int _ScrollObjScale;                          //초기화는 HaveTower 클래스에서
    public int _Gap;                                    //초기화는 HaveTower 클래스에서
    public int _InstanceScrollCount;          //초기화는 HaveTower 클래스에서

    public RectTransform Content;
    public ScrollRect ScrollRect;

    private float _prePos = 0;

    private int _speciesNum;                      //초기화는 HaveTower 클래스에서
    private int _currentNum;
    private int _scrollDataCount;                 //초기화는 HaveTower 클래스에서
    private List<TowerContent> _scrollList;

    void Awake()
    {
        _currentNum = 0;
        _scrollList = new List<TowerContent>();
        ScrollRect = GetComponent<ScrollRect>();
        Content = ScrollRect.content;
    }

    public void SelectScrollView(int speciesIndex, int scrollDataCount)
    {
        ScrollRect.velocity = Vector2.zero;
        _speciesNum = speciesIndex;
        _scrollDataCount = scrollDataCount;

        InfinityScrollViewStart();
    }

    public void InfinityScrollViewStart()
    {
        ScrollRect.velocity = new Vector2(0, 0.135f);
        _prePos = 0;

        _currentNum = 0;
        _scrollList.Clear();
        Content.transform.localPosition = new Vector2(100, 0);
        ScrollRect.onValueChanged.RemoveAllListeners();

        for (int i = 0; i < _InstanceScrollCount; i++)
        {
            var scrollObj = Content.GetComponentsInChildren<TowerContent>();

            var conScript = scrollObj[i].GetComponent<TowerContent>();

            conScript.SetUIData(i + _speciesNum);

            _scrollList.Add(scrollObj[i]);
            scrollObj[i].transform.localPosition = new Vector2(0, -(_currentNum * _Gap) - _ScrollObjScale);
            _currentNum++;
        }

        ScrollRect.onValueChanged.AddListener(ListChange);
        
        Content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, (_scrollDataCount * _Gap) + _ScrollObjScale);

    }

    private void ListChange(Vector2 vec)
    {
        if (-Content.anchoredPosition.y - _prePos < -(_Gap))
        {
            if (_currentNum >= _scrollDataCount)
                return;

            _prePos -= _Gap;

            var scrollObj = _scrollList[0];
            _scrollList.RemoveAt(0);
            scrollObj.transform.localPosition = new Vector2(0, -(_currentNum * _Gap) - _ScrollObjScale);
            _scrollList.Add(scrollObj);
            _scrollList[_InstanceScrollCount - 1].SetUIData(_speciesNum + _currentNum);
            _currentNum++;
        }

        else if(-Content.anchoredPosition.y - _prePos>0)
        {
            if (_currentNum <= _InstanceScrollCount)
                return;

            _prePos += _Gap;
            var scrollObj = _scrollList[_scrollList.Count - 1];
            _scrollList.RemoveAt(_scrollList.Count - 1);
            scrollObj.transform.localPosition = new Vector2(0, -(((_currentNum - (_InstanceScrollCount + 1)) * _Gap) + _ScrollObjScale));
            _scrollList.Insert(0, scrollObj);
            _scrollList[0].SetUIData(_speciesNum + _currentNum - (_InstanceScrollCount+1));
            _currentNum--;
        }
    }
}
