using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFloorManager : MonoBehaviour
{
    public GameObject nextFloorDoor;
    private void Start()
    {

    }
    private void Update()
    {
        if (GameManager.instance.enemyList.Count <= 0)
        {
            nextFloorDoor.SetActive(true);
        }
        else
        {
            nextFloorDoor.SetActive(false);
        }
    }
    private void OnEnable()
    {
        
        GameManager.instance.gameModes = GameManager.GameModes.Survivor;
    }
    private void OnDisable()
    {
        GameManager.instance.count = 0;
    }

}
