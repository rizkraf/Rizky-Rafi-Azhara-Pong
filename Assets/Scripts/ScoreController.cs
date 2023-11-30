using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text scoreKiri;
    public Text scoreKanan;
    // Start is called before the first frame update
    public ScoreManager manager;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreKiri.text = manager.leftScore.ToString();
        scoreKanan.text = manager.rightScore.ToString();
    }
}
