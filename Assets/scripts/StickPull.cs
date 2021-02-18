using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickPull : MonoBehaviour
{
    public float pullStrength;
    public bool pulling;


    private Rigidbody2D rb;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (pulling)
        {
            rb.velocity = new Vector2(pullStrength * -1, 0);
        }
    }

    public void StartPulling()
    {
        pulling = true;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }
}
