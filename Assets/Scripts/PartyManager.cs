using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
    public List<Character> allyList = new List<Character>();
    public List<Character> sameCharList = new List<Character>();
    public float mergeTime;
    float timer=0;

    public void AddCharacter(Character character) //int cost / if(wallet>cost)
    {
        if(allyList.Count > 0)
        {            
            for (int i = 0; i < allyList.Count; i++)
            {
                if(allyList[i].characterClasses == character.characterClasses && allyList[i].charLevel == character.charLevel)
                {
                    sameCharList.Add(character);
                    sameCharList.Add(allyList[i]);
                    
                }
            }
            if(sameCharList.Count>=3)
            {
                GameObject mergedAlly = Instantiate(sameCharList[0]).gameObject;
                mergedAlly.GetComponent<Character>().SetCharLevel(sameCharList[0].charLevel + 1);
                mergedAlly.GetComponent<StateMachine>().enabled = true;
                allyList.Add(mergedAlly.GetComponent<Character>());
                for (int i = 0; i < sameCharList.Count; i++)
                {
                    Debug.Log("i ="+i+" SameC Count " + sameCharList.Count);
                    Destroy(sameCharList[i].gameObject);
                    allyList.Remove(sameCharList[i]);                    
                }
                sameCharList.Clear();
            }
            else
            {
                character.GetComponent<StateMachine>().enabled = true;
                allyList.Add(character);
                Destroy(character.GetComponentInChildren<SpriteRenderer>().gameObject);
            }
        }
        else
        {
            character.GetComponent<StateMachine>().enabled = true;
            allyList.Add(character);
            Destroy(character.GetComponentInChildren<SpriteRenderer>().gameObject);
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        timer = 0;
    }
    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.layer == LayerMask.NameToLayer("Merge"))
        {
            timer += Time.deltaTime;
            if(timer>=mergeTime)
            {
                Debug.Log("Merged!");
                AddCharacter(other.gameObject.GetComponentInParent<Character>());
                other.gameObject.GetComponentInParent<StateMachine>().enabled = true;
                other.gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {

        timer = 0;
    }

    public List<Character> GetAllyList()
    {
        return allyList;
    }



}
