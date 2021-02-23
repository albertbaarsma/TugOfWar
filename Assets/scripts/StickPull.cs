using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickPull : MonoBehaviour
{
    public float pullStrength;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }
    // Update is called once per frame
    void Update()
    {
            rb.velocity = new Vector2(pullStrength * -1, 0);
    }
}
