using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerController instance;
    private Animator anim;

    private string jump_Animation = "PlayerJump";
    private string change_Line_Animation = "ChangeLine";

    public GameObject player,
                      shadow;

    public Vector3 first_PosOfPlayer,
                   second_PosOfPlayer;

    //Movement handle
    private Vector3 firstCursor;
    private Vector3 DirectionOfHand;
    private int amoutOfClick;
    
    public bool player_Died;
    
    private void Awake() {
        anim = player.GetComponent<Animator>();
    }

    void Start()
    {
        MakeSingleton();
    }

    // Update is called once per frame
    void Update()
    {
        HandleChangeLine(); 
        HandleJump();
    }

    void MakeSingleton(){
        if(instance==null){
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void HandleChangeLine(){
        if(Input.GetMouseButtonDown(0)){
            firstCursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if(Input.GetMouseButtonUp(0)){
            Vector3 endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 vectorDirec = endPoint - firstCursor;
            
            if(Mathf.Abs(vectorDirec.y) > Mathf.Abs(vectorDirec.x)){
                amoutOfClick = 0;
                if(vectorDirec.y>0)
                    DirectionOfHand = Vector3.up;
                else
                    DirectionOfHand = Vector3.down;
            }
            else{
                DirectionOfHand = Vector3.zero;
            }
        }

        if(DirectionOfHand==Vector3.up){
            MovePositionTo(second_PosOfPlayer);
        }
        else if(DirectionOfHand==Vector3.down){
            MovePositionTo(first_PosOfPlayer);
        }
    }

    void HandleJump(){
        if(Input.GetMouseButtonDown(0)){
            amoutOfClick++;
        }

        if(amoutOfClick==2){
            anim.Play("PlayerJump");
            amoutOfClick = 0;
        }
    }


    void MovePositionTo(Vector3 pos){
        transform.localPosition = Vector3.Lerp(transform.localPosition,pos,Time.deltaTime*10f);
    }

}
