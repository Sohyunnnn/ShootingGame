using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text currentScoreUI;
    public int currentScore;

    public Text bsetScoreUI;
    public int bestScore;

    public static ScoreManager Instance = null;

    public int Score
    {
        get
        {
            return currentScore;
        }
        set
        {
            currentScore = value;


            currentScoreUI.text = "현재점수 : " + currentScore;

            if (currentScore > bestScore)
            {
                bestScore = currentScore;
                bsetScoreUI.text = "최고점수 : " + bestScore;

                PlayerPrefs.SetInt("Best Score", bestScore);
            }
        }
    }

    private void Awake()
    {
        if(Instance ==null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        bsetScoreUI.text = "최고점수 : " + bestScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScore(int value)
    {

       currentScore++;


        currentScoreUI.text = "현재점수 : " + currentScore;

        if (currentScore > bestScore)
        {
            bestScore =currentScore;
            bsetScoreUI.text = "최고점수 : " +bestScore;

            PlayerPrefs.SetInt("Best Score", bestScore);
        }
    }

    public int GetScore()
    {
        return currentScore;
    }
}
