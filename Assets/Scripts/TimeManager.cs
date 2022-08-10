using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public int selected;
    List<string> days = new List<string>();
    private void Start()
    {
        days.Add("Day1");
        days.Add("Day2");
        days.Add("Day3");
        days.Add("DeathNight");
    }
    void Update()
    {
        
    }
}
