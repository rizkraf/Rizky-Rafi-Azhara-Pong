using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 speed;
    private Rigidbody2D rig;
    public Vector2 resetPosition;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = speed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetBall(bool isRight)
    {
        if (isRight)
        {
            speed.x = +Mathf.Abs(speed.x);
        }
        else
        {
             speed.x = -Mathf.Abs(speed.x);
        }
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 1);
        rig.velocity = speed;
    }

    public void ActivatePUSpeed(float magnitude)
    {
        rig.velocity *= magnitude;
    }
}
