using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int speed;
    public KeyCode upKey;
    public KeyCode downKey;
    private Rigidbody2D rig;
    public Vector2 resetScale;
    private float extendPaddleTimer;
    private float SpeedUpPaddleTimer;
    private bool extendPaddlePower;
    private bool speedUpPaddlePower;
    public PowerUpManager powerUpManager;
    public Collider2D ball;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (extendPaddlePower)
        {
            extendPaddleTimer += Time.deltaTime;
            if (extendPaddleTimer > 5)
            {
                transform.localScale = new Vector3(resetScale.x, resetScale.y, 1);
                extendPaddleTimer -= 5;
                extendPaddlePower = false;
            }
        }
        if (speedUpPaddlePower)
        {
            SpeedUpPaddleTimer += Time.deltaTime;
            if (SpeedUpPaddleTimer > 5)
            {
                speedUpPaddlePower = false;
                SpeedUpPaddleTimer -= 5;
            }
        }
        MoveObject(GetInput());
    }

    private Vector2 GetInput()
    {
        if (Input.GetKey(upKey))
        {
            if (speedUpPaddlePower)
            {
                return Vector2.up * (speed * 2);
            }
            return Vector2.up * speed;
        }

        if (Input.GetKey(downKey))
        {
            if (speedUpPaddlePower)
            {
                return Vector2.down * (speed * 2);
            }
            return Vector2.down * speed;
        }

        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement)
    {
        Debug.Log("Test: " + movement);
        rig.velocity = movement;
    }

    public void ExtendPaddle (bool activatePowerUp)
    {
        extendPaddlePower = activatePowerUp;
        transform.localScale = new Vector3(resetScale.x, resetScale.y * 2, 1);
    }

    public void SpeedUpPaddle (bool activatePowerUp)
    {
        speedUpPaddlePower = activatePowerUp;
    }

    public void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.collider == ball)
        {
            Collider2D paddle = GetComponent<Collider2D>();
            powerUpManager.GetComponent<PowerUpManager>().GetHitPaddle(paddle);
        }
    }
}
