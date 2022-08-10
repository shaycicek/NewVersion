using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyItemDrop : MonoBehaviour
{
    public float itemDropValue;
    public float dropChance;


    /*public void OnItemDrop()
    {
        GameManager.instance.ChangeValueOfCrystal(crystalAmount);
        GameManager.instance.tmesh.SetText("" + GameManager.instance.crystalCount);
        GameObject mineralUI;
        minAnimation = DOTween.Sequence();
        audio.Play();
        mineralUI = Instantiate(minUI, Camera.main.WorldToScreenPoint(transform.position), panel.transform.rotation, panel.transform);
        minAnimation.Append(mineralUI.transform.DOMove(Camera.main.WorldToScreenPoint(UIPos.transform.position), 0.5f).SetEase(Ease.OutSine)).OnComplete(() => Destroy(mineralUI));
    }*/


    public float DropItem()
    {
        if(dropChance>0)
        {
            if (System.Math.Round(System.Convert.ToDecimal(Random.Range(1, 1 / dropChance))) == 1)
            {
                UIManager.instance.MineralCollectAnim(transform);
                GameManager.instance.ChangeValueOfCrystal(itemDropValue);
                return itemDropValue;
            }
            return 0f;
        }
        return 0f;        
    }

}
