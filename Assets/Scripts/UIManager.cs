using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    Sequence minAnimation;
    public GameObject UIPos;
    public GameObject minUI;
    public GameObject panel;
    public static UIManager instance;

    private void Awake()
    {
        if (instance == null || instance == this)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    public void MineralCollectAnim(Transform minTransform)
    {
        GameObject mineralUI;

        minAnimation = DOTween.Sequence();
        mineralUI = Instantiate(minUI, Camera.main.WorldToScreenPoint(minTransform.position), panel.transform.rotation, panel.transform);
        minAnimation.Append(mineralUI.transform.DOMove(Camera.main.WorldToScreenPoint(UIPos.transform.position), 0.2f).SetEase(Ease.OutSine)).OnComplete(() => Destroy(mineralUI));
    }
}
