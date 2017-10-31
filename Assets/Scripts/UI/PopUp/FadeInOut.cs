using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class FadeInOut : UIPopupBase
{
    public float _Alpha;
    public UnityAction AddAction;

    private float _fadeTime = 1.5f;
    private Image _fadeImage;

    void Awake()
    {
        _fadeImage = GetComponent<Image>();
    }

    public void FadeIn(UnityAction func)
    {
        if (AddAction != null)
            func += AddAction;

        StartCoroutine(FadeInStart(func));
    }

    public void FadeOut(UnityAction func)
    {
        StartCoroutine(FadeOutStart(func));
    }

    public IEnumerator FadeInStart(UnityAction func)
    {
        float accTime = 0;

        while (accTime < _fadeTime)
        {
            accTime += Time.deltaTime;

            _Alpha = (_fadeTime - accTime) / _fadeTime;

            _fadeImage.color = new Color(0, 0, 0, _Alpha);

            yield return null;
        }

        _fadeImage.color = new Color(0, 0, 0, 0);

        func.Invoke();
    }

    public IEnumerator FadeOutStart(UnityAction func)
    {

        float accTime = 0;

        while (accTime < _fadeTime)
        {
            accTime += Time.deltaTime;

            _Alpha = 1 - (_fadeTime - accTime) / _fadeTime;

            _fadeImage.color = new Color(0, 0, 0, _Alpha);

            yield return null;
        }

        _fadeImage.color = new Color(0, 0, 0, 1);

        func.Invoke();
    }

}
