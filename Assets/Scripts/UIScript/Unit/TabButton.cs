using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;



public class TabButton : UIObject
{
    private Button[] _buttons;
    private Text[] _btnText;
    //private int _currentIndex = 0;    

    void Awake()
    {
        _buttons = RegistAllButtonOnClickEvent();
        _btnText = GetComponentsInChildren<Text>();
    }

    /// <summary>
    /// 버튼 세팅이 끝나면 최초 어디부터 시작할껀지 시작점코드부터 진행 ( 시작탭 인덱스를 넣어주면된다 )
    /// </summary>
    public void Initialize(int index)
    {
        CheckButtonIndex(index);
        _buttons[index].onClick.Invoke();
    }

    public void AddListener(int index, UnityAction callback)
    {
        _buttons[index].onClick.AddListener(callback);
    }

    public void RemoveListener(int index, UnityAction callback)
    {
        _buttons[index].onClick.RemoveListener(callback);
    }

    // 단순히 이미지만 바꾸는 함수다  이벤트는 이미 등록해서 자동적으로 버튼 누르면 실행됨
    public void CheckButtonIndex(int index)
    {
        //_currentIndex = index;

        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].interactable = true;
            _btnText[i].color = Color.gray;
        }

        _buttons[index].interactable = false;
        _btnText[index].color = Color.black;
    }

    protected override void OnButtonClick(string name)
    {
        base.OnButtonClick(name);

        for (int i = 0; i < _buttons.Length; i++)
        {
            if (_buttons[i].name == name)
            {
                CheckButtonIndex(i);
            }
        }
    }



}
