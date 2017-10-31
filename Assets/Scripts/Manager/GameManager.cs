using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class GameManager : Singleton<GameManager>
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        var pop = UIManager.i.CreatePopup<FadeInOut>(POPUP_TYPE.FRONT);
    }

    void Start()
    {
        TableManager.i.DataTableLoad();

        ChangeScene(SCENE_NAME.LOGO_SCENE, IntroSceneExitWaiting, LogoScenePrepareWaiting);
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        if (UIManager.i.GetUIObject<ItemManagement>())
    //        {
    //            var pop = UIManager.i.GetUIObject<ItemManagement>();

    //            UIManager.i.RemoveTopUIObject(pop.Reset);
    //            return;
    //        }

    //        UIManager.i.RemoveTopUIObject();
    //    }

    //}

    //******************** Scene **********************//

    public void ChangeScene(SCENE_NAME sceneName, UnityAction exit, UnityAction preFunc)
    {
        var pop = UIManager.i.GetPopupUIObject<FadeInOut>();

        if (pop == null)
            pop = UIManager.i.CreatePopup<FadeInOut>(POPUP_TYPE.FRONT);

        pop.FadeOut(() => { SceneManager.i.ChangeScene(sceneName, exit, preFunc); });
    }

    public void IntroSceneExitWaiting()
    {
        SceneManager.i.Done();
    }

    public void LogoScenePrepareWaiting()
    {
        UIManager.i.CreatePopup<LogoPopup>(POPUP_TYPE.POPUP);
        var pop = UIManager.i.GetPopupUIObject<FadeInOut>();

        SceneManager.i.Done();

        pop.FadeIn(() => UIManager.i.RemovePopupUIObject<FadeInOut>());
        StartCoroutine(DelayTimeFunc(1.8f, () => { ChangeScene(SCENE_NAME.GAME_SCENE, LogoSceneExitWaiting, MainScenePrepareWaiting); }));
    }

    public void LogoSceneExitWaiting()
    {
        SceneManager.i.Done();
    }

    public void MainScenePrepareWaiting()
    {
        var mainPop = UIManager.i.CreatePopup<MainPage>(POPUP_TYPE.PAGE);
        var pop = UIManager.i.GetPopupUIObject<FadeInOut>();

        SceneManager.i.Done();
        pop.AddAction += () => mainPop.ButtonTweenPlay(0);

        pop.FadeIn(() => UIManager.i.RemovePopupUIObject<FadeInOut>());
    }

    public void MainSceneExitWaiting()
    {
        SceneManager.i.Done();
    }

    public void StageScenePrepareWaiting()
    {
        var pop = UIManager.i.GetPopupUIObject<FadeInOut>();

        SceneManager.i.Done();

        pop.FadeIn(() => UIManager.i.RemovePopupUIObject<FadeInOut>());
    }

    private IEnumerator DelayTimeFunc(float time, UnityAction func)
    {
        yield return new WaitForSeconds(time);
        func.Invoke();
    }

    /////////////////////////////////// Scene ///////////////////////////////////

}
