using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class GameData
{
    private int star_Count;
    private int score_Count;

    private bool[] heroes;

    private int selected_Index;
    
    public int Star_Count
    {
        get
        {
            return star_Count;
        }
        set
        {
            star_Count = value;
        }
    }

    public int Score_Count
    {
        get
        {
            return score_Count;
        }
        set
        {
            score_Count = value;
        }
    }

    public int Selected_Index
    {
        get
        {
            return selected_Index;
        }
        set
        {
            selected_Index = value;
        }
    }

    public bool[] Heroes
    {
        get
        {
            return heroes;
        }
        set
        {
            heroes = value;
        }
    }



    public GameData(int scoreCount , int starCount , int selectedIndex , bool[] heroes)
    {
        heroes[0] = true;
        this.score_Count = scoreCount;
        this.star_Count = starCount;
        this.selected_Index = selectedIndex;
        this.heroes = heroes;
    }

     public GameData(int index)
    {
        this.heroes[index] = true;
    }


     public GameData(int scoreCount , int starCount)
    {
        this.score_Count = scoreCount;
        this.star_Count = starCount;
    }



}
