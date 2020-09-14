using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    // Start is called before the first frame update

    //Sigleton
    public static GameplayController instance;

    public float moveSpeed , distance_factor = 1f;
    private float distance_Move;
    private bool gameJustStarted; // game has just began

    private void Awake() {
        MakeInstance();
    }
    void Start()
    {
        gameJustStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayerController.instance.player_Died) {
            MoveCamera();
        }
    }

    void MakeInstance(){
        if(instance==null) instance = this;
        else Destroy(gameObject);
    }

    void MoveCamera(){
        if(gameJustStarted){
            //remember check player alive

            if(moveSpeed<10f)
                moveSpeed+=Time.deltaTime*5f;
            else
            {
                moveSpeed=10f;
                gameJustStarted = false;  //end demo game
            }

        }
        Camera.main.transform.position += new Vector3(moveSpeed*Time.deltaTime,0f,0f);

        UpdateDistance();
    }

    
    void UpdateDistance(){
        distance_Move+=Time.deltaTime * distance_factor;

        int round = Mathf.RoundToInt(distance_Move);

        if(round>=30 && round < 60)  moveSpeed=12f;
        else if(moveSpeed>=60)  moveSpeed = 14f;    
    }


}
