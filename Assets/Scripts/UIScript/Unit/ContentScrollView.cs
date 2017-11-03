using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

public enum ScrollViewAxis { HORIZONTAL, VERTICAL }
public enum ScrollContentKind { ITEM, TOWER}

public class ContentScrollView : MonoBehaviour
{
    private UnitContent[] _contentArray;
    private ScrollRect _scollRect;
    private ScrollViewAxis _axis;
    private ScrollContentKind _contentKind;

    public void Init<T>(ScrollViewAxis axis, ScrollContentKind kind) where T : UnitContent
    {
        _contentArray = GetComponentsInChildren<T>();
        _scollRect = GetComponentInChildren<ScrollRect>();
        _axis = axis;
        _contentKind = kind;
    }


    public void SetScrollView(int speciesIndex, int scrollDataCount, int lineCount, UnityAction<int,long> btnCallback)
    {
        SetScrollViewAxis(scrollDataCount, lineCount);

        for (int i = 0; i < scrollDataCount; i++)
        {
            int index = speciesIndex + (i * 10);

            if(ScrollContentKind.TOWER == _contentKind)
            {
                long uid = (index + 11) / 10;
                if (UserInformation.i.Inventory.FindTower(uid) != null)
                {
                    index = UserInformation.i.Inventory.FindTower(uid).LocalIndex;
                }
            }
            _contentArray[i].SetUIData(index);
            _contentArray[i].Callback = btnCallback;
            _contentArray[i].GetComponent<Image>().enabled = true;
            _contentArray[i].GetComponent<Button>().enabled = true;
        }

        int count = _contentArray.Length - scrollDataCount;

        for (int i = 0; i < count; i++)
        {
            _contentArray[i + scrollDataCount].GetComponent<Image>().enabled = false;
            _contentArray[i + scrollDataCount].GetComponent<Button>().enabled = false;

        }
    }

    private void SetScrollViewAxis(int scrollDataCount, float lineCount)
    {
        float tempCount = scrollDataCount / lineCount;

        scrollDataCount = Mathf.CeilToInt(tempCount);

        if (_axis == ScrollViewAxis.HORIZONTAL)
        {
            _scollRect.content.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, scrollDataCount * 200);
            float posX = _scollRect.content.sizeDelta.x - _scollRect.viewport.sizeDelta.x;
            posX = posX * 0.5f;
            float posY = _scollRect.viewport.sizeDelta.y;
            posY *= 0.5f;
            _scollRect.content.transform.localPosition = new Vector2(posX, posY);

            if (_scollRect.content.sizeDelta.x <= _scollRect.viewport.sizeDelta.x)
                _scollRect.horizontal = false;
            else
                _scollRect.horizontal = true;
        }

        if (_axis == ScrollViewAxis.VERTICAL)
        {
            _scollRect.content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, scrollDataCount * 200);
            float posY = _scollRect.viewport.sizeDelta.y - _scollRect.content.sizeDelta.y;
            posY *= 0.5f;
            _scollRect.content.transform.localPosition = new Vector2(0, posY);

            if (_scollRect.content.sizeDelta.y <= _scollRect.viewport.sizeDelta.y)
                _scollRect.vertical = false;
            else
                _scollRect.vertical = true;
        }
    }

}
