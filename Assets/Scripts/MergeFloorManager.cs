using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeFloorManager : MonoBehaviour
{
    
    List<Vector3> mergePos = new List<Vector3>();
    public List<Character> mergableAllyList = new List<Character>();

    private void Awake()
    {
        GameManager.instance.gameModes = GameManager.GameModes.None;
        mergePos.Add(new Vector3(-13, 0, 0));
        mergePos.Add(new Vector3(2, 0, 0));
        mergePos.Add(new Vector3(17, 0, 0));
        for (int i = 0; i < mergableAllyList.Count; i++)
        {
            mergableAllyList[i].GetComponent<StateMachine>().enabled = false;
        }
    }

    private void OnEnable()
    {
        /*GameObject ally1;
        GameObject ally2;
        GameObject ally3;
        ally1 = Instantiate(mergableAllyList[Random.Range(0, mergableAllyList.Count-1)] , transform).gameObject;
        ally1.transform.position = mergePos[0];
        ally2 = Instantiate(mergableAllyList[Random.Range(0, mergableAllyList.Count - 1)] , transform).gameObject;
        ally2.transform.position = mergePos[1];
        ally3 = Instantiate(mergableAllyList[Random.Range(0, mergableAllyList.Count - 1)] , transform).gameObject;
        ally3.transform.position = mergePos[2]; */
    }

}
