using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public static MainMenuController instance;
    public int score;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private Text scoreText, endScoreText;
    void Awake()
    {
        MakeInstance();    
    }
    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }    
    public void ReStartButton()
    {
        gameOverPanel.SetActive(false);
        Application.LoadLevel("SampleScene");
    }
    public void OptionButton()
    {
        Application.LoadLevel("MainMenu");
    }
    public void ShipDiedShowPanel()
    {
        gameOverPanel.SetActive(true);
        endScoreText.text = "" + score;
        scoreText.gameObject.SetActive(false);


    }
    void Start()
    {
        score = 0;
        //UpdateScore();
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGamePlayController();
    }
    void UpdateGamePlayController()
    {
        scoreText.text = "" + score;
    }
    //public void AddScore(int newScoreValue)
    //{
    //    score += newScoreValue;
    //    UpdateScore();
    //}
    //public void UpdateScore()
    //{
    //    scoreText.text = "Score: " + score;
    //}    
}
