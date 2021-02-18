using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FollowersTextController : MonoBehaviour
{


    public Data data;
    
    private int tick;

    public TextMeshProUGUI followersText;

    private void Awake()
    {
        data = new Data();
    }

    public void FixedUpdate()
    {
        Debug.Log("tick" + tick);

       if (data.reposts < data.maxReposts)
       {
            tick++;
            if (tick == data.TicksBetweenUpdate)
            {

                data.nFollowers += Random.Range(1, 3);
                followersText.text = "Followers: " + data.nFollowers;
                data.reposts++;
                tick = 0;
                Debug.Log("reposts: " + data.reposts);

            }
       }
    }

 
    public void AddFollowers()
    {
        followersText.text = "Followers: " + data.nFollowers;
        data.nFollowers+= Random.Range(1, 3);
        data.reposts = 0;
    }

}
