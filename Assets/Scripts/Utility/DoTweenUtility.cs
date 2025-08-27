using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public static class DoTweenUtility
{
    public static void onClickAnimation(this Button button, Action action, bool isWait = false, float value = -0.2f)
    {
        button.onClick.AddListener(() =>
        {
            if (!isWait)
            {
                button.transform.DOPunchScale(new Vector3(value, value, value), 0.1f);
                action?.Invoke();
                return;
            }

            var sequence = DOTween.Sequence();
            sequence.Append(button.transform.DOPunchScale(new Vector3(value, value, value), 0.1f));
            sequence.AppendCallback(() => { action?.Invoke(); });
        });
    }

    public static void OnClickAnimation(this Toggle toggle, float value = 0.2f, bool isWaitForAnimation = false, Action onClick = null)
    {
        var trans = toggle.transform;

        toggle.onValueChanged.AddListener((toggleValue) =>
        {
            if (!toggleValue)
                return;

            if (!isWaitForAnimation)
            {
                trans.DOPunchScale(new Vector3(value, value, value), 0.1f);
                onClick?.Invoke();
                return;
            }

            var sequence = DOTween.Sequence();
            sequence.Append(trans.DOPunchScale(new Vector3(value, value, value), 0.1f));
            sequence.AppendCallback(() =>
            {
                onClick?.Invoke();
            });
        });
    }

    public static void onImageFade(this Image image, float startAlpha, float targetAlpha, float duration = 2f, Action onEndFade = null)
    {
        Color setAlphaColor = image.color;
        setAlphaColor.a = startAlpha;
        image.color = setAlphaColor;

        if (onEndFade == null)
        {
            image.DOFade(targetAlpha, duration);
            return;
        }

        var sequence = DOTween.Sequence();
        sequence.Append(image.DOFade(targetAlpha, duration));
        sequence.AppendCallback(() =>
        {
            onEndFade?.Invoke();
        });
    }

    public static void onCanvasGroupFade(this CanvasGroup canvasGroup, float StartAlpha = 0, float targetAlpha = 1, float duration = 0.5f, Action onEndFade = null)
    {
        canvasGroup.alpha = StartAlpha;

        if (canvasGroup == null)
        {
            canvasGroup.DOFade(targetAlpha, duration);
            return;
        }

        var sequence = DOTween.Sequence();
        sequence.Append(canvasGroup.DOFade(targetAlpha, duration));
        sequence.AppendCallback(() =>
        {
            onEndFade?.Invoke();
        });
    }

    public static void onMoveIn(this Transform transform, Vector3 offsetPo, float duration = 1f)
    {
        Vector3 StartPosition = transform.position;

        transform.position = StartPosition + offsetPo;
        transform.DOMove(StartPosition, duration);
    }

    public static void onMoveOut(this Transform transform, Vector3 offsetPo, float duration = 1f)
    {
        transform.DOMove(transform.position + offsetPo, duration);
    }

    public static void GameObjectAnimation(this GameObject gameObject, Action action = null, float value = -0.2f, float duration = 0.2f)
    {
        var sequence = DOTween.Sequence();
        sequence.Append(gameObject.transform.DOPunchScale(new Vector3(value, value, value), duration));
        sequence.AppendCallback(() =>
        {
            action?.Invoke();
        });
    }
}
