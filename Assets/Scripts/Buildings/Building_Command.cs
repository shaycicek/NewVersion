using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building_Command : Building
{
    [SerializeField] Button upgradePanelOpener;
    public override void Interact(GameObject other)
    {
        panel.SetActive(true);
    }

    public void OpenPanel()
    {
        panel.SetActive(true);
        upgradePanelOpener.gameObject.SetActive(false);
        Time.timeScale = 0;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Interact(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            upgradePanelOpener.gameObject.SetActive(false);
        }
    }
}
