using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InfinityScrollView : MonoBehaviour
{
    public float WhiteSpace;
    public int UserSetScrollObjGap;
    public int UserSetInstanceScrollObjCount;


    private ScrollRect _scrollRect;
    private int _scrollDataCount;
    private int _currentIndex;
    private float _prePos;
    private float _scrollObjSize;
    private float _scrollObjGap;
    private float _setUnitcontentPosY;

    private List<UnitContent> _contentScrollList;
    private List<Unit> _unitScollList;


    void Awake()
    {
        _contentScrollList = new List<UnitContent>();
        _scrollRect = GetComponent<ScrollRect>();
    }

    public void CreateContent(ContentIndex SelectContent, UnityAction<long> btnCallback)
    {
        string path = null;

        if (SelectContent == ContentIndex.ITEM)
            path = ItemData.PrefabPath;
        if (SelectContent == ContentIndex.TOWER)
            path = TowerData.PrefabPath;

        var content = Resources.Load<GameObject>(path);

        _scrollObjSize = content.GetComponent<RectTransform>().sizeDelta.y;

        for (int i = 0; i < UserSetInstanceScrollObjCount; i++)
        {
             var itemContent = Instantiate(content, _scrollRect.content);

             var cnt = itemContent.GetComponent<ItemContent>();

            cnt.Callback = btnCallback;
        }

    }

    public void SetScrollView<T>(List<Unit> unitList) where T : UnitContent
    {
        _unitScollList = unitList;
        _scrollRect.velocity = Vector2.zero;
        _scrollDataCount = unitList.Count;

        StartScrollView<T>();
    }

    private void StartScrollView<T>() where T : UnitContent
    {
        _scrollRect.vertical = true;
        _scrollRect.velocity = new Vector2(0, 0.135f);
        _currentIndex = 0;
        _contentScrollList.Clear();
        _scrollRect.onValueChanged.RemoveAllListeners();

        _scrollRect.content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, SetContentSizeY());

        if (_scrollRect.content.sizeDelta.y <= _scrollRect.viewport.sizeDelta.y)
            _scrollRect.vertical = false;

        _setUnitcontentPosY = SetUnitContentPosY();

        float initposY = (_scrollRect.viewport.sizeDelta.y - _scrollRect.content.sizeDelta.y) * 0.5f;

        _scrollRect.content.transform.localPosition = new Vector2(0, initposY);
        _prePos = _scrollRect.content.localPosition.y;

        var scrollIn = _scrollRect.content.GetComponentsInChildren<T>();

        for (int i = 0; i < UserSetInstanceScrollObjCount; i++)
        {
            scrollIn[i].gameObject.SetActive(true);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////
        /// 정보의 개수보다 인스턴스된 스크롤컨텐트가 더 많으면///
        if (_scrollDataCount <= UserSetInstanceScrollObjCount)
        {
            for (int i = 0; i < _scrollDataCount; i++)
            {
                float posY = _setUnitcontentPosY - (UserSetScrollObjGap * _currentIndex);

                scrollIn[i].SetUIData(_unitScollList[i].LocalIndex, _unitScollList[i].UID);
                scrollIn[i].transform.localPosition = new Vector2(0, posY);
                _currentIndex++;
            }
            
            int count = UserSetInstanceScrollObjCount - _scrollDataCount;
            for (int i = 0; i < count; i++)
            {
                scrollIn[i + _scrollDataCount].transform.localPosition = new Vector2(-1000, 0);
            }
            return;
        }

        for (int i = 0; i < UserSetInstanceScrollObjCount; i++)
        {
            float posY = _setUnitcontentPosY - (UserSetScrollObjGap * _currentIndex);

            scrollIn[i].transform.localPosition = new Vector2(0, posY);
            scrollIn[i].SetUIData(_unitScollList[i].LocalIndex, _unitScollList[i].UID);

            _contentScrollList.Add(scrollIn[i]);
            _currentIndex++;
        }

        _scrollRect.onValueChanged.AddListener(ListValueChange);
    }

    private void ListValueChange(Vector2 vec)
    {
        if (_scrollRect.content.localPosition.y > _prePos + _scrollObjGap + _scrollObjSize)
        {
            _prePos = _scrollRect.content.localPosition.y;

            if (_currentIndex >= _scrollDataCount) return;

            var tempScrollObj = _contentScrollList[0];
            _contentScrollList.RemoveAt(0);

            float posY = _setUnitcontentPosY - (UserSetScrollObjGap * _currentIndex);
            tempScrollObj.transform.localPosition = new Vector2(0,posY);

            int index = _unitScollList[_currentIndex].LocalIndex;
            long uid = _unitScollList[_currentIndex].UID;
            tempScrollObj.SetUIData(index, uid);

            _contentScrollList.Add(tempScrollObj);
            _currentIndex++;
        }
        else if (_scrollRect.content.localPosition.y < _prePos - _scrollObjGap - _scrollObjSize)
        {
            _prePos = _scrollRect.content.localPosition.y;

            if (_currentIndex < UserSetInstanceScrollObjCount) return;

            var tempScrollObj = _contentScrollList[_contentScrollList.Count - 1];
            _contentScrollList.RemoveAt(_contentScrollList.Count - 1);

            float posY = _setUnitcontentPosY - (UserSetScrollObjGap * (_currentIndex - UserSetInstanceScrollObjCount));
            tempScrollObj.transform.localPosition = new Vector2(0, posY);


            int index = _unitScollList[_currentIndex - UserSetInstanceScrollObjCount].LocalIndex;
            long uid = _unitScollList[_currentIndex - UserSetInstanceScrollObjCount].UID;
            tempScrollObj.SetUIData(index, uid);
            //int index = _speciesIndex + ((_currentIndex - UserSetInstanceScrollObjCount) * 10);

            _contentScrollList.Insert(0, tempScrollObj);
            _currentIndex--;
        }
    }

    private float SetUnitContentPosY()
    {
        float returnValue = _scrollRect.content.sizeDelta.y - _scrollRect.viewport.sizeDelta.y;
        returnValue *= 0.5f;

        float nullGap = 0;

        nullGap = 100 - _scrollObjSize;
        nullGap *= 0.5f;

        //여백을 얼마나 남길껀지 정해야함 화이트 스페이쓰
        
        returnValue = returnValue - WhiteSpace + nullGap + ((_scrollRect.viewport.sizeDelta.y - 100) * 0.5f);

        return returnValue;
    }

    private float SetContentSizeY()
    {
        float objSize = _scrollObjSize * _scrollDataCount;
        _scrollObjGap = UserSetScrollObjGap - _scrollObjSize;

        float setGap = _scrollObjGap * (_scrollDataCount - 1);

        //여백을 얼마나 남길껀지 정해야함 화이트 스페이쓰
        //여기는 밑에랑 위에랑 같이 맞추기 위해서 2배로하여 같게함
        float returnValuse = objSize + setGap + (WhiteSpace * 2);

        return returnValuse;
    }
}
