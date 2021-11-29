using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startgame : MonoBehaviour
{
    public List<GameObject> ob = new List<GameObject>();

    private float starttime;
    private float deltatime = 1f;
    private int i = 0;
    void Start()
    {
        Player.Pause();
        ob[i].SetActive(true);
        starttime = Time.time;
    }
    void Update()
    {
        if(starttime + deltatime <= Time.time)
        {
            if(i < ob.Count)
            {
                ob[i].SetActive(false);
                if(i < ob.Count - 1)
                ob[i+1].SetActive(true);
                i++;
                if (i == ob.Count)
                    Player.Continue();
            }
            
            starttime = Time.time;
        }
    }
}
