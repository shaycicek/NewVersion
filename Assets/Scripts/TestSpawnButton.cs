using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestSpawnButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spawn;
    Button button;
    public void Spawn()
    {
        SpawnManager.instance.TestSpawn(spawn);
    }
    

}
