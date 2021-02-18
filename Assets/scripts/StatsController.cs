using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsController : MonoBehaviour
{
    public Data data;
    
    private int tick;

    float chancePullerJoin = .01f;

    public TextMeshProUGUI followersText;
    public TextMeshProUGUI pullersText;

    private void Awake()
    {
        data = new Data();
        pullersText.text = "Pullers: " + data.pullers;
        followersText.text = "Followers: " + data.nFollowers;

    }

    public void FixedUpdate()
    {
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

    void UpdateStats()
    {
        // adding a repost value in each update. If max is reached no more followers will automatically join.
        data.reposts++;

        // adding followers per for each repost
        data.nFollowers += Random.Range(1, (data.nFollowers/10)+2);
        followersText.text = "Followers: " + data.nFollowers;

        UpdatePullers();

        data.maxReposts = Random.Range(1, (data.nFollowers / 20)+2) +1;
        Debug.Log(data.maxReposts);

        // if the amount of followers is 100, add 1 
    }

    void UpdatePullers()
    {
        chancePullerJoin = .01f + (float)data.nFollowers / 10000;

        if (Random.value < chancePullerJoin)
        {
            data.pullers++;
            pullersText.text = "Pullers: " + data.pullers;
        }
    }

    public void AddFollowers(int modifier = 3)
    {
        followersText.text = "Followers: " + data.nFollowers;
        data.nFollowers += Random.Range(1, (data.nFollowers / 10 * modifier) + 2);
        data.reposts = 0;
    }

    public void CallFriend()
    {
        if (Random.value < chancePullerJoin*10*data.pullers)
            data.pullers++;
    }

}
