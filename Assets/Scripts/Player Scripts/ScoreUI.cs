using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreUI : MonoBehaviour
{
    // Start is called before the first frame update

    public static ScoreUI instance;
    public int score;
    public int star;

    public TextMeshProUGUI text_Score;
    public TextMeshProUGUI text_starScore;

    public TextMeshProUGUI End_text_Score;
    public TextMeshProUGUI End_text_starScore;

    public TextMeshProUGUI Best_Score;

    private GameData data;
    private void Awake()
    {
        MakeInstance();
    }
    void Start()
    {
        Best_Score.text = GM.instace.myScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        text_Score.text = score.ToString();
        text_starScore.text = star.ToString();
        End_text_Score.text = score.ToString();
        End_text_starScore.text = star.ToString();



    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveDataToFile()
    {
        int bestScoreToInt = int.Parse(Best_Score.text);
        if (bestScoreToInt < int.Parse(text_Score.text))
        {
            Best_Score.text = text_Score.text;
        }
        GM.instace.SaveData(score, star);
    }



}
