using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameTowerContent : UIObject {

    private int _index;
    public Text _indexTxt;

    public UnityAction<int> CallBack;

    void Awake()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ButtonAction);
    }

    public void Init()
    {
        _indexTxt = GetText("Text");
    }

    public void SetUIData(int index)
    {
        _index = index;

        if (index == 0)
        {
            gameObject.SetActive(false);
            return;
        }
        _indexTxt.text = _index.ToString();
        gameObject.SetActive(true);

    }

    public void ButtonAction()
    {
        if (CallBack != null)
            CallBack.Invoke(_index);
    }
}
