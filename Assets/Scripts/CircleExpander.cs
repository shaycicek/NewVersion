using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleExpander : MonoBehaviour
{
    Sequence circleAnim;
    private void Start()
    {
        circleAnim = DOTween.Sequence();
        circleAnim.Append(gameObject.transform.DOScale(new Vector3 (2.2f , 2.2f , 25f) , 2f).SetEase(Ease.OutSine)).OnComplete(() => Destroy(gameObject));        
    }
    private void OnDestroy()
    {
       
    }


}
