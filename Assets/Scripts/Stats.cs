using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float enemyHP;
    public float enemyDFactor;
    public float playerHP;
    public float playerDFactor;
    public float allyHP;
    public float allyDamageFactor;
    public static Stats instance;

    private void Start()
    {        
        if(PlayerPrefs.HasKey("EnemyHealth"))
        {
            enemyHP = PlayerPrefs.GetFloat("EnemyHealth");
        }
        if (PlayerPrefs.HasKey("EnemyDFactor"))
        {
            enemyDFactor = PlayerPrefs.GetFloat("EnemyDFactor");
        }
        if (PlayerPrefs.HasKey("PlayerHealth"))
        {
            playerHP = PlayerPrefs.GetFloat("PlayerHealth");
        }
        if (PlayerPrefs.HasKey("PlayerDFactor"))
        {
            playerDFactor = PlayerPrefs.GetFloat("PlayerDFactor");
        }
        if (PlayerPrefs.HasKey("AllyHealth"))
        {
            allyHP = PlayerPrefs.GetFloat("AllyHealth");
        }
        if (PlayerPrefs.HasKey("AllyDFactor"))
        {
            allyDamageFactor = PlayerPrefs.GetFloat("AllyDFactor");
        }
    }

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
}
