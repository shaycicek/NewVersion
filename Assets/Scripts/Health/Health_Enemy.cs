using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Enemy : Health
{
    Sequence minAnimation;
    public GameObject UIPos;
    public GameObject minUI;
    public GameObject panel;
    public AudioSource audio;
    public delegate void OnUnvisibleEnemyDestroyDelegate();
    public static OnUnvisibleEnemyDestroyDelegate OnUnvisibleEnemyDestroy;
    public float crystalAmount;
    float timer = 0;
    private void Start()
    {
        panel = GameManager.instance.panel;
        UIPos = GameManager.instance.UIPos;
        audio = GameManager.instance.mineralAudio;
        StartCoroutine(LateInit());
        
    }
    private void OnEnable()
    {
        GetComponent<StateMachine>().enabled = true;
    }

    private void Update()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);        
        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
        {
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
            if (timer >= 10)
            {
                DestroyUnvisibleEnemy();
                timer = 0;
            }
            
        }
    }
    public override void OnDeath()
    {
        base.OnDeath();
        GetComponent<StateMachine>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponentInChildren<Canvas>().enabled = false;
        GetComponent<EnemyItemDrop>().DropItem();
        /*GameManager.instance.ChangeValueOfCrystal(crystalAmount);
        GameObject mineralUI;
        minAnimation = DOTween.Sequence();
        audio.Play();
        mineralUI = Instantiate(minUI, Camera.main.WorldToScreenPoint(transform.position), panel.transform.rotation, panel.transform);
        minAnimation.Append(mineralUI.transform.DOMove(Camera.main.WorldToScreenPoint(UIPos.transform.position), 0.5f).SetEase(Ease.OutSine)).OnComplete(() => Destroy(mineralUI));*/
        GameManager.instance.enemyList.Remove(GetComponent<Character>());
        SpawnManager.instance.enemyPool.EnqueueMe(gameObject);
        //Destroy(gameObject,2f);
    }

    IEnumerator LateInit()
    {
        yield return new WaitForSeconds(0.5f);
        character.Initialize(Stats.instance.enemyHP, Stats.instance.enemyDFactor, character.movementSpeed, character.attackRange, character.sightRange);
        currentHealth = charHealth;
        healthBar.SetMaxHealth(charHealth);
    }

    public void DestroyUnvisibleEnemy()
    {
        OnUnvisibleEnemyDestroy?.Invoke();
        GameManager.instance.enemyList.Remove(GetComponent<Character>());  // Düþmaný Listeden Kaldýr
        SpawnManager.instance.enemyPool.EnqueueMe(gameObject);
        //SpawnManager.instance.SpawnEnemy();
        //Destroy(gameObject);
    }

    public void KnockBack()
    {
        
    }
}
