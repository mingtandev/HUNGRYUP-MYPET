using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GM : MonoBehaviour
{

    public static GM instace;
    // Start is called before the first frame update
    public static GameData data;

    [Header("Gameplay Scene")]
    public GameObject UIEndGame_Gameplay;


    //My data
    [Header("Menu Scene")]
    public TextMeshProUGUI starCount_Menu;
    public int myStar;
    public int myScore;
    public bool[] heroes = new bool[9];
    public int hero_Selected;


    private void Awake()
    {
        MakeSingleton();
        LoadData();
    }

    public IEnumerator ShowUIEndGame()
    {
        yield return new WaitForSeconds(0.8f);
        UIEndGame_Gameplay.SetActive(true);
    }

    void MakeSingleton()
    {
        if (instace == null)
        {
            instace = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void LoadData()
    {
        data = SaveLoadManager.LoadData();

        if (data == null)
        {
            Debug.Log("CREATE NEW FILE");
            GameData newData = new GameData(0, 0, 0, new bool[9]);
            SaveLoadManager.SaveData(newData);
            data = newData;

            return;
        }

        //assign to varible
        myStar = data.Star_Count;
        myScore = data.Score_Count;
        heroes = data.Heroes;
        if (heroes == null)
        {
            heroes = new bool[9];
            heroes[0] = true;
            Debug.Log("New Create");
        }
        //Debug.Log(heroes[]);


        if (starCount_Menu)
            starCount_Menu.text = myStar.ToString();
    }

    public void SaveData(int curScore, int curStar)
    {
        if (curScore > myScore)
        {
            myScore = curScore;
        }


        myStar += curStar;


        // data = new GameData(myScore, myStar);
        data.Score_Count = myScore;
        data.Star_Count = myStar;
        SaveLoadManager.SaveData(data);
    }

    public void SaveDataSelected(int select, int resStar)
    {
        hero_Selected = select;
        data.Selected_Index = select;
        data.Star_Count = resStar;
        SaveLoadManager.SaveData(data);
    }

    public void SaveDataAtIndex(int indexOpen)
    {

        heroes[indexOpen] = true;
        data.Heroes = heroes;
        SaveLoadManager.SaveData(data);
    }
}















































































































