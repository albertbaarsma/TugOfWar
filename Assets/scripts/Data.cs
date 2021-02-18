using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data
{
    public int nFollowers;
    public int reposts = 0;
    public int maxReposts = 0;
    public int TicksBetweenUpdate = 20;
    public float pullStrength;
    public int pullers;


    public Data()
    {
        nFollowers = 0;
        reposts = 0;
        maxReposts = 3;
        TicksBetweenUpdate = 50;
        pullers = 1;
        pullStrength = 1;

    }
}
