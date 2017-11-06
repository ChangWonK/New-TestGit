using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageStage : MonoBehaviour
{
    private PageScrollView _scrollView;

    void Awake()
    {
        _scrollView = GetComponentInChildren<PageScrollView>();
    }

    void Start()
    {
        _scrollView.Init(1150, 3);
    }

}
