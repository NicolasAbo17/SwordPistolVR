using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{

    private int currentScore;
    private int currentMultiplier;
    private int multiplierCount;
    private int highScore;

    [Header("UI Fields")]
    public TextMeshProUGUI hightScoreText;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI currentMultiplierText;
    public TextMeshProUGUI finalScoreText;

    public static ScoreManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        // DontDestroyOnLoad(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        currentMultiplier = 1;

        highScore = PlayerPrefs.GetInt("HighScore",0);
        hightScoreText.text = highScore.ToString();

        //Set the current score as 0.
        currentScoreText.text = "0";

    }


    public void AddScore(int scorePoint)
    {
        currentScore = currentScore + scorePoint*currentMultiplier;
        PlayerPrefs.SetInt("CurrentScore",currentScore);

        // Increment multiplier
        multiplierCount++;
        if( currentMultiplier < 8 && multiplierCount == 2 * currentMultiplier )
        {
            multiplierCount = 0;
            currentMultiplier *= 2;
        }
        
        //Display the current score in UI
        currentScoreText.text = currentScore.ToString();

        //Display the current multiplier
        currentMultiplierText.text = "X" + currentMultiplier;

        //Also, update the final score
        finalScoreText.text = currentScore.ToString();

        if (currentScore > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore",currentScore);
            hightScoreText.text = currentScore.ToString();

        }
    }

    public void LoseMultiplier()
    {
        multiplierCount = 0;
        if(currentMultiplier > 1)
        {
            currentMultiplier = currentMultiplier / 2;
        }
        currentMultiplierText.text = "X" + currentMultiplier;

    }
}
