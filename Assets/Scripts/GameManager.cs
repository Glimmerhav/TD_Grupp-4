using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float currentTime;

    float minuteTime = 0f;
    float secunds = 0f;

    [SerializeField] TextMeshProUGUI CoinText;
    [SerializeField]float coins= 100;



    private void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        secunds = Mathf.FloorToInt(currentTime);
        if (secunds >= 60) { currentTime = 0; minuteTime += 1; }
        timerText.text = (minuteTime.ToString("00") + ":" + secunds.ToString("00"));

        CoinText.text = "Coins:" + coins.ToString();
    }
    public void SetCoins(float add)
    {
        coins += add;
    }
    public float Minute {get {return  minuteTime;}}
    public float Coins { get { return coins; } }
}
