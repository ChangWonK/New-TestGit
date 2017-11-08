using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackMapSelect : UIPopupBase
{
    private GameMode _gameMode;
    private int _stageLevel;
    private int _mapLevel;
    private RectTransform _content;


    void Awake()
    {
        _content = transform.Find("Content") as RectTransform;
    }

    public void Init(GameMode mode, int stageLevel)
    {
        _gameMode = mode;
        _stageLevel = stageLevel;

        CreateContent();
    }

    private void CreateContent()
    {
        MapContent[] content = _content.GetComponentsInChildren<MapContent>();

        for (int i = 0; i < content.Length; i++)
        {
            content[i].SetUIData(i);
            content[i].CallBack = ContentClickEvent;
        }
    }

    private void ContentClickEvent(int mapLevel)
    {
        _mapLevel = mapLevel;
        UIManager.i.CreatePopup<PopupGamePlayRelated>(POPUP_TYPE.POPUP);
    }

    public void SceneChange()
    {
        GameManager.i.ChangeScene(SCENE_NAME.GAME_SCENE, StageSceneExitWaiting, GameScenePrepareWaiting);
    }
    private void StageSceneExitWaiting()
    {
        GameManager.i.GameMode = _gameMode;
        GameManager.i.GameStage = _stageLevel;
        GameManager.i.GameMap = _mapLevel;

        UIManager.i.RemoveStackUIObject<StackMapSelect>();
        UIManager.i.RemovePageUIObject();
        UIManager.i.RemovePopupUIObject<PopupGamePlayRelated>();

        SceneManager.i.Done();
    }
    private void GameScenePrepareWaiting()
    {
        var pop = UIManager.i.GetPopupUIObject<FadeInOut>();

        UIManager.i.CreatePopup<PageGame>(POPUP_TYPE.PAGE);

        SceneManager.i.Done();

        pop.FadeIn(() => UIManager.i.RemovePopupUIObject<FadeInOut>());



    }

}
