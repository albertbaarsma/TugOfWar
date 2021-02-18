using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSegment : MonoBehaviour
{
    public GameObject connectedLeft, connectedRight;
    // Start is called before the first frame update
    void Start()
    {
        connectedLeft = GetComponent<HingeJoint2D>().gameObject;
        RopeSegment leftSegment = connectedLeft.GetComponent<RopeSegment>();
        if(leftSegment != null)
        {
            leftSegment.connectedLeft = gameObject;
            float spriteFarLeft = connectedLeft.GetComponent<SpriteRenderer>().bounds.size.x;
            Debug.Log(spriteFarLeft);
            Debug.Log(spriteFarLeft *-1);

            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(spriteFarLeft, 0.5f);
        } else {
            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, 0);
        }
    }
}
