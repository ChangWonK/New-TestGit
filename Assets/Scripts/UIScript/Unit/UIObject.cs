using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

public class UIObject : MonoBehaviour
{

    protected Text GetText(string textName)
    {
        var texts = GetComponentsInChildren<Text>();

        for (int i = 0; i < texts.Length; i++)
        {
            if (texts[i].name == textName)
                return texts[i];
        }

        return null;
    }

    protected Text GetText(Transform transform, string textName)
    {
        
        var texts = transform.GetComponentsInChildren<Text>();

        for (int i = 0; i < texts.Length; i++)
        {
            if (texts[i].name == textName)
                return texts[i];
        }

        return null;
    }

    protected Button GetButton(string buttonName)
    {
        var buttons = GetComponentsInChildren<Button>();

        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].name == buttonName)
            {
                buttons[i].onClick.RemoveAllListeners();
                return buttons[i];
            }
        }

        return null;
    }

    protected Button GetButton(string buttonChildName, string buttonName)
    {
        Transform child = transform.Find(buttonChildName);
        var buttons = child.GetComponentsInChildren<Button>();

        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].name == buttonName)
            {
                buttons[i].onClick.RemoveAllListeners();
                return buttons[i];
            }
        }
        return null;
    }

    protected Button GetButton(Transform child, string buttonName)
    {
        var buttons = child.GetComponentsInChildren<Button>();

        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].name == buttonName)
            {
                buttons[i].onClick.RemoveAllListeners();
                return buttons[i];
            }
        }

        return null;
    }

    protected Image GetImage(Transform child, string ImageName)
    {
        var Images = child.GetComponentsInChildren<Image>();

        for (int i = 0; i < Images.Length; i++)
        {
            if (Images[i].name == ImageName)
                return Images[i];
        }

        return null;
    }

    protected Image GetImage(string ImageName)
    {
        var Images = GetComponentsInChildren<Image>();

        for (int i = 0; i < Images.Length; i++)
        {
            if (Images[i].name == ImageName)
                return Images[i];
        }

        return null;
    }

    /// <summary>
    /// ButtonEvent 스크립트없이 버튼 OnClick 등록 & 사용하는 Method
    /// 기존 : ButtonEvent public type 변경 
    /// </summary>
    /// <param name="button"></param>
    protected void RegistButtonOnClickEvent(Button button)
    {
        if (button == null)
            print(gameObject.name);

        button.onClick.AddListener(() => { OnButtonClick(button.name); });
    }

    /// <summary>
    ///  버튼을 이름으로 찾으면서 반환하는 함수 
    /// </summary>
    /// <param name="btnName"></param>
    /// <returns></returns>
    protected Button RegistButtonOnClickEvent(string btnName, Transform trans = null)
    {
        Button findButton;

        if (trans)
            findButton = GetButton(trans, btnName);
        else
            findButton = GetButton(btnName);

        if (findButton != null)
            findButton.onClick.AddListener(() => { OnButtonClick(findButton.name); });

        return findButton;
    }

    /// <summary>
    /// 모든 버튼에 대한 UIBase Onclick 이벤트 등록하는 함수 
    /// </summary>
    /// <returns>버튼 배열 반환</returns>
    protected Button[] RegistAllButtonOnClickEvent()
    {
        Button[] btns = transform.GetComponentsInChildren<Button>(true);

        for (int i = 0; i < btns.Length; i++)
            RegistButtonOnClickEvent(btns[i]);

        return btns;
    }


    //
    // Summary:
    // 버튼 클릭 시 이벤트 받는다. 
    // 기본 버튼음 추가 
    //
    protected virtual void OnButtonClick(string name) { }

}
