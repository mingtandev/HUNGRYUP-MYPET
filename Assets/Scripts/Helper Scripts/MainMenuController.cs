using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] avaible_Heroes;

    public GameObject SelectHeroesButton;

    public int[] PricesHeros;

    private int currentIndex;

    public TextMeshProUGUI star;

    public int factorMoney = 1;

    public void InitializeCharaters()
    {
        currentIndex = 0;
        PricesHeros = new int[avaible_Heroes.Length];
        if (GM.data.Selected_Index == 0)
        {
            SelectHeroesButton.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = "YOU CHOOSE";
        }
        for (int i = 0; i < avaible_Heroes.Length; i++)
        {
            PricesHeros[i] = factorMoney * (i + 1);
            avaible_Heroes[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = (factorMoney * (i + 1)).ToString();


            if (GM.instace.heroes[i])
            {
                HideThePrice(i);
            }
            avaible_Heroes[i].SetActive(false);
        }

        avaible_Heroes[currentIndex].SetActive(true);
    }

    public void NextHero()
    {

        avaible_Heroes[currentIndex].SetActive(false);

        currentIndex++;

        currentIndex %= avaible_Heroes.Length;
        avaible_Heroes[currentIndex].SetActive(true);


        //check choosen
        if (GM.data.Selected_Index == currentIndex)
        {
            SelectHeroesButton.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = "YOU CHOOSE";
            HideThePrice(currentIndex);
            return;
        }

        if (!GM.instace.heroes[currentIndex])
        {
            SelectHeroesButton.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = "BUY";

        }
        else
        {
            SelectHeroesButton.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = "SELECT";
            HideThePrice(currentIndex);
        }

    }

    public void PreviousHero()
    {
        currentIndex %= avaible_Heroes.Length;

        avaible_Heroes[currentIndex].SetActive(false);

        currentIndex--;
        if (currentIndex < 0) currentIndex = 0;


        currentIndex %= avaible_Heroes.Length;

        avaible_Heroes[currentIndex].SetActive(true);





        //check choosen

        if (GM.data.Selected_Index == currentIndex)
        {
            SelectHeroesButton.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = "YOU CHOOSE";
            HideThePrice(currentIndex);

            return;
        }

        if (!GM.instace.heroes[currentIndex])
        {
            SelectHeroesButton.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = "BUY";
        }
        else
        {
            SelectHeroesButton.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = "SELECT";
            HideThePrice(currentIndex);

        }




    }

    public void SelectPet()
    {
        string curText = SelectHeroesButton.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text;

        if (curText.Equals("BUY"))
        {
            if (GM.instace.myStar >= PricesHeros[currentIndex])
            {
                GM.instace.myStar -= PricesHeros[currentIndex];
                star.text = GM.instace.myStar.ToString();
                SelectedHero(currentIndex);
                GM.instace.SaveDataSelected(currentIndex, GM.instace.myStar);
            }
            else
            {
                return;
            }
        }
        GM.instace.SaveDataSelected(currentIndex, GM.instace.myStar);

        SelectHeroesButton.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = "YOU CHOOSE";


    }


    public void LoadToGameplay()
    {
        SceneManager.LoadScene(1);
    }

    void SelectedHero(int index)
    {
        avaible_Heroes[index].transform.GetChild(0).gameObject.SetActive(false);
        avaible_Heroes[index].transform.GetChild(1).gameObject.SetActive(false);
        GM.instace.heroes[index] = true;
        GM.instace.SaveDataAtIndex(index);


    }

    void HideThePrice(int index)
    {
        Debug.Log(index);
        avaible_Heroes[index].transform.GetChild(0).transform.gameObject.SetActive(false);
        avaible_Heroes[index].transform.GetChild(1).transform.gameObject.SetActive(false);
    }


    public void GoHome()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }
}
