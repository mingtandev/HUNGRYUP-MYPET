using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{

    public static GM instace;
    // Start is called before the first frame update
    public GameObject UIEndGame;

    private void Awake() {
        MakeSingleton();
    }

    public IEnumerator ShowUIEndGame(){
        yield return new WaitForSeconds(0.8f);
        UIEndGame.SetActive(true);
    }

    void MakeSingleton(){
        if(instace ==null){
            instace = this;
        }
        else{
            Destroy(gameObject);
        }
    }
}
