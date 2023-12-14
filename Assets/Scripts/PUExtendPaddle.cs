using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUExtendPaddle : MonoBehaviour
{
    public Collider2D ball;
    public PowerUpManager manager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            Collider2D paddle = manager.GetComponent<PowerUpManager>().paddle;
            paddle.GetComponent<PaddleController>().ExtendPaddle(true);
            manager.RemovePowerUp(gameObject);
        }
    }
}
