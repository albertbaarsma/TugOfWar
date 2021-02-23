using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PullController : MonoBehaviour
{
    public TextMeshProUGUI pullText;

    public GameObject[] stick;

    public void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Pull();
        }
    }

    public void Pull()
    {
            for (int i = 0; i < stick.Length; i++)
            {
                stick[i].GetComponent<StickPull>().pullStrength += 0.05f;
            }
        pullText.text = "Pull effort = " + Mathf.Round(stick[0].GetComponent<StickPull>().pullStrength * 20);
    }
}
