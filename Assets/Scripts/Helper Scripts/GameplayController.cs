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

    public GameObject obstacles_Obj;
    public GameObject[] obstacles_List;

    [HideInInspector]
    public bool obstacles_Is_Active;
    public string Coutoutine_Name = "SpawnObstacles";

    private void Awake() {
        MakeInstance();
    }
    void Start()
    {
        gameJustStarted = true;
        GetObstacles();
        StartCoroutine(Coutoutine_Name);
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

    void GetObstacles(){
        obstacles_List = new GameObject[obstacles_Obj.transform.childCount];

        for(int i = 0 ; i < obstacles_List.Length ; i++){
            obstacles_List[i] = obstacles_Obj.GetComponentsInChildren<ObstacleHolder>(true)[i].gameObject;  //parameter true is we can get compenent when Active = false(get all)
        }
    }

    IEnumerator SpawnObstacles(){
        while(true){   // loop infinite will not crash when i have return new wait second
            if(!PlayerController.instance.player_Died){
                if(!obstacles_Is_Active){  //when we not active mean obstaces outside the bounds and reset
                    if(Random.value <= 0.5f){
                        int randomIdx = 0;
                        do{
                           randomIdx = Random.Range(0,obstacles_List.Length);

                        }while(obstacles_List[randomIdx].activeInHierarchy==true);// if that game object is active , we do notthing


                        obstacles_List[randomIdx].SetActive(true);

                        obstacles_Is_Active = true;
                    }
                }
            }
            yield return new WaitForSeconds(0.3f);
        }
    }
}
