using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform levelParent;
    public Transform mainFloorParent;
    public Character enemyPrefab;
    public Character allyPrefab;
    public Mineral min1;
    Vector3 randomPos;
    float Radius;
    List<Vector3> posList = new List<Vector3>();
    public static SpawnManager instance;
    public ObjectPool enemyPool;
    public ObjectPool mineralPool;
    int maxEnemies = 50;
    public int totalNumberEnemiesInScene=0;

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
        Radius = 45.0f;   
        min1 = GameManager.instance.min1;
        //Health_Enemy.OnUnvisibleEnemyDestroy += SpawnEnemy;
    }

    public void SpawnEnemy() 
    {
        if(totalNumberEnemiesInScene < maxEnemies)
        {
            randomPos = Camera.main.ViewportToWorldPoint(RandomPosOutsideOfCam());
            randomPos.y = 0;

            if (Physics.OverlapSphere(randomPos + new Vector3(0, 1f, 0), 0.2f).Length > 0)
            {
                randomPos = Camera.main.ViewportToWorldPoint(RandomPosOutsideOfCam());
                randomPos = new Vector3(randomPos.x, 0, randomPos.z);
            }
            else
            {
                Character enemy = enemyPool.GetPooledObject().GetComponent<Character>();
                enemy.Initialize(Stats.instance.enemyHP, Stats.instance.enemyDFactor, enemy.movementSpeed, enemy.attackRange, enemy.sightRange);
                enemy.gameObject.SetActive(true);
                if (GameManager.instance.gameModes == GameManager.GameModes.Survivor)
                {
                    enemy.transform.parent = levelParent;
                } else if (GameManager.instance.gameModes == GameManager.GameModes.Wave)
                {
                    enemy.transform.parent = mainFloorParent;
                }
                GameManager.instance.enemyList.Add(enemy);  // Düþmaný Listeye ekle           
                enemy.transform.position = randomPos;
                totalNumberEnemiesInScene++;
                GameManager.instance.count++;
            }
        }
    }

    public Vector3 RandomPosOutsideOfCam()
    {
        posList.Clear();         
        float x1 = Random.Range(-0.2f, -0.1f);
        float x2 = Random.Range(-0.2f, 1.1f);
        float x3 = Random.Range(1.1f, 1.2f);
        float x4 = Random.Range(-0.1f, 1.2f);

        float y1 = Random.Range(-0.1f, 1.2f);
        float y2 = Random.Range(-0.2f, -0.1f);
        float y3 = Random.Range(-0.2f, 1.1f);
        float y4 = Random.Range(1.1f, 1.2f);
        posList.Add(new Vector3(x1, y1, 35));
        posList.Add(new Vector3(x2, y2, 35));
        posList.Add(new Vector3(x3, y3, 35));
        posList.Add(new Vector3(x4, y4, 35));
        return posList[Random.Range(0, 4)];

        

    }

    public void SpawnAlly(Vector3 playerPosition)
    {
        randomPos = Random.insideUnitSphere * 4f;
        randomPos = new Vector3(randomPos.x, 0, randomPos.z);
        Character ally = Instantiate(allyPrefab);
        //ally.Initialize(Stats.instance.allyHP , Stats.instance.allyDamageFactor, ally.movementSpeed, ally.attackRange, ally.sightRange);
        ally.transform.position = randomPos + playerPosition;
        
    }

    public void SpawnMineral()
    {
        randomPos = Random.insideUnitSphere * Radius;
        randomPos = new Vector3(randomPos.x, 0 , randomPos.z);
        if(Physics.OverlapSphere(randomPos+new Vector3(0, 1f, 0), 0.2f).Length > 0)
        {
            randomPos = Random.insideUnitSphere * Radius;
            randomPos = new Vector3(randomPos.x, 0, randomPos.z);
        }
        else
        {
            Mineral mineral = Instantiate(min1);
            mineral.transform.position = randomPos;
            mineral.transform.parent = GameManager.instance.crystalParent.transform;
        }
    }
}
