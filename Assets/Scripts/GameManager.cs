using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text timerText;
    public Text pinFirstText;
    public Text pinSecondText;
    public Text pinThirdText;
    public float timer;
    public float startTimer = 60;
    public int pinFirst = 0;
    public int pinSecond = 0;
    public int pinThird = 0;
    private bool isLost;
    private bool isWon;
    public GameObject losePanel;
    public GameObject winPanel;
    private int minPinValue = 0;
    private int maxPinValue = 10;
    private int randomizePin1;
    private int randomizePin2;
    private int randomizePin3;
    void Start()
    {
        RestartGame();
    }
    void Update()
    {
        if (!isWon)
        {
            CheckTimeRemain();
            timer -= Time.deltaTime;
            timerText.text = Mathf.Round(timer).ToString();
        }
        GameStatus();
    }
    public void Drill()
    {
        pinFirst += 1;
        pinSecond -= 1;
        CheckPins();
        ChangePinText();
    }
    public void Hammer()
    {
        pinFirst -= 1;
        pinSecond += 2;
        pinThird -= 1;
        CheckPins();
        ChangePinText();
    }
    public void MasterTool()
    {
        pinFirst -= 1;
        pinSecond += 1;
        pinThird += 1;
        CheckPins();
        ChangePinText();
    }
    public void CheckTimeRemain()
    {
        if (timer <= 0)
        {
            timer = 0;
            isLost = true;
        }
    }
    private void CheckPins()
    {
        if (pinFirst < 0)
            pinFirst = minPinValue;
        if (pinFirst > 10)
            pinFirst = maxPinValue;
        if (pinSecond < 0)
            pinSecond = minPinValue;
        if (pinSecond > 10)
            pinSecond = maxPinValue;
        if (pinThird < 0)
            pinThird = minPinValue;
        if (pinThird > 10)
            pinThird = maxPinValue;
    }
    public void GameStatus()
    {
        if (isLost)
            losePanel.SetActive(true);
        else if (isWon)
            winPanel.SetActive(true);
        if (pinFirst == 5 && pinSecond == 5 && pinThird == 5)
            isWon = true;
    }
    private void RandomPins()
    {
        randomizePin1 = Random.Range(minPinValue, maxPinValue + 1);
        randomizePin2 = Random.Range(minPinValue, maxPinValue + 1);
        randomizePin3 = Random.Range(minPinValue, maxPinValue + 1);
        pinFirst = randomizePin1;
        pinSecond = randomizePin2;
        pinThird = randomizePin3;
    }
    private void ChangePinText()
    {
        pinFirstText.text = pinFirst.ToString();
        pinSecondText.text = pinSecond.ToString();
        pinThirdText.text = pinThird.ToString();
    }
    public void RestartGame()
    {
        RandomPins();
        ChangePinText();
        isLost = false;
        isWon = false;
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        isLost = false;
        isWon = false;
        timer = startTimer;
        timerText.text = timer.ToString();
    }
}
