using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public enum GameModes
    {
        Survivor,
        Wave,
        None
    }
    public GameModes gameModes;
    public GameObject mainPlayer;
    public GameObject allyParent;
    public GameObject bulletParent;
    public GameObject enemyParent;
    public GameObject crystalParent;
    public float crystalCount;
    public TextMeshProUGUI tmesh;
    public Mineral min1;    
    public Character player;
    public Transform cam;
    public GameObject panel;
    public GameObject UIPos;
    public AudioSource mineralAudio;
    public delegate void OnMineralCollectDelegate();
    public OnMineralCollectDelegate OnMineralCollect;
    public List<Character> enemyList = new List<Character>();
    float timer=0;
    public int count = 0;
    public static GameManager instance;

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
        gameModes = GameModes.None;
    }

    private void Start()
    {
        SkillMenu.instance.InitializeSkillMenu();
        crystalCount = 0;
        tmesh.SetText(crystalCount + "");
        for (int i =0; i<100; i++)
        {
            if (i % 2 == 0)
            {
                //SpawnManager.instance.SpawnEnemy();
            }
            //SpawnManager.instance.SpawnMineral();
        }
        //SpawnManager.instance.InvokeRepeating("SpawnEnemy",1f,1f);
        //SpawnManager.instance.InvokeRepeating("SpawnMineral", 2f, 3f);        
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (gameModes == GameModes.None)
        {

        }
        else if (gameModes == GameModes.Survivor)
        {            
            if(count < 15)
            {
                if (timer > 0.02f)
                {
                    SpawnManager.instance.SpawnEnemy();
                    timer = 0;                    
                }
            }
        }
        else
        {
            //Wave Spawn!!
        }
        
    }


    public void ChangeValueOfCrystal(float amount)
    {
        crystalCount += amount;
        tmesh.SetText("" + GameManager.instance.crystalCount);
        OnMineralCollect?.Invoke();
    }


}
