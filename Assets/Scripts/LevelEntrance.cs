using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEntrance : MonoBehaviour
{
    [SerializeField] GameObject currentFloor;
    [SerializeField] GameObject nextFloor;
    [SerializeField] Transform teleportPos;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            currentFloor.SetActive(false);
            nextFloor.SetActive(true);
            GameManager.instance.player.GetComponent<PlayerController>().Teleport(teleportPos);            
        }
    }
}
