using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsController : MonoBehaviour
{
    public Data data;
    
    private int tick;

    public TextMeshProUGUI followersText;
    public TextMeshProUGUI pullersText;

    private void Awake()
    {
        data = new Data();
    }

    public void FixedUpdate()
    {
        Debug.Log(data.pullers);
       if (data.reposts < data.maxReposts)
       {
            tick++;
            if (tick == data.TicksBetweenUpdate)
            {
                UpdateStats();
                
                tick = 0;
            }
       }
    }

    // can be used by button
    public void AddFollowers(int minAmount = 1, int maxAmount = 3)
    {
        followersText.text = "Followers: " + data.nFollowers;
        data.nFollowers+= Random.Range(minAmount, maxAmount);
        data.reposts = 0;
    }

    void UpdateStats()
    {
        // adding a repost value in each update. If max is reached no more followers will automatically join.
        data.reposts++;

        // adding followers per for each repost
        data.nFollowers += Random.Range(1, 3);
        followersText.text = "Followers: " + data.nFollowers;

        if (Random.value < .45f)
        {
            data.pullers++;
            followersText.text = "Pullers: " + data.pullers;
        }

        // if the amount of followers is 100, add 1 
    }

}
