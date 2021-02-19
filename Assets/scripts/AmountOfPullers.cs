using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmountOfPullers : MonoBehaviour
{
    public GameObject[] StickMen;
    // Start is called before the first frame update
    void Start()
    {
        int pullers = PlayerPrefs.GetInt("pullers");
        Debug.Log("pullers: " + pullers);

        for(int i = 0; i < pullers;i++)
        {
            StickMen[i].SetActive(true);
        }
    }
}
