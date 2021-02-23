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

    public GameObject level2;
    public GameObject levelExtra;
    public GameObject levelExtra2;
    public GameObject level3;
    public GameObject levelHill;


    private void Awake()
    {
        data = new Data();
      
    }

    private void Start()
    {
        int playerPrefPullers = PlayerPrefs.GetInt("pullers");

        if (playerPrefPullers != 1)
        {
            Debug.Log("get here?");
            data.pullers += playerPrefPullers;
        }

        int playerPrefFollowers = PlayerPrefs.GetInt("followers");

        Debug.Log(playerPrefFollowers);


        if (playerPrefFollowers != 1)
        {
            data.nFollowers += playerPrefFollowers;
        }
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

        PlayerPrefs.SetInt("followers", data.nFollowers);

        followersText.text = "Followers: " + data.nFollowers;

        UpdatePullers();

        data.maxReposts = Random.Range(1, (data.nFollowers / 20)+2) +1;

        // if the amount of followers is 100, add 1 
    }

    void UpdatePullers()
    {
        chancePullerJoin = .01f + (float)data.nFollowers / 10000;

        if (Random.value < chancePullerJoin)
        {
            data.pullers++;
        }

        if (data.pullers >= 2)
        {
            levelExtra.SetActive(true);
        }
        if (data.pullers >= 3)
        {
            level2.SetActive(true);
        }
        if (data.pullers >= 5)
        {
            levelExtra2.SetActive(true);
        }
        if (data.pullers >= 8)
        {
            level3.SetActive(true);
        }
        if (data.pullers >= 12)
        {
            levelHill.SetActive(true);
        }
        pullersText.text = "Pullers: " + data.pullers;
        PlayerPrefs.SetInt("pullers", data.pullers);
    }

    public void AddFollowers(int modifier = 3)
    {
        followersText.text = "Followers: " + data.nFollowers;
        data.nFollowers += Random.Range(1, (data.nFollowers / 10 * modifier) + 2);
        data.reposts = 0;
    }

    public void CallFriend()
    {
        data.pullers++;
        UpdatePullers();
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        data = new Data();
        data.reposts = 3;
        data.maxReposts = 3;

        pullersText.text = "Pullers: " + data.pullers;
        followersText.text = "Followers: " + data.nFollowers;
    }
}
