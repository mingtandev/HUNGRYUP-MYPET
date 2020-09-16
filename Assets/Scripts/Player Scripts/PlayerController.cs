using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerController instance;
    private Animator anim;


    public GameObject player,
                      shadow;

    public Vector3 first_PosOfPlayer,
                   second_PosOfPlayer;  

    //Movement handle
    private Vector3 firstCursor;
    private Vector3 DirectionOfHand;
    private int amoutOfClick;
    
    public bool player_Died;


    //Collision
    public GameObject explosion;
    private SpriteRenderer player_Renderer;
    public Sprite TRex_Sprite , player_Sprite;

    private bool TRex_Trigger;
    private GameObject[] star_Effect;
    
    private void Awake() {
        anim = player.GetComponent<Animator>();
        MakeSingleton();
        player_Renderer = player.GetComponent<SpriteRenderer>(); 
        star_Effect = GameObject.FindGameObjectsWithTag(MyTags.STAR_EFFECT);

    }

    void Start()
    {

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

    void Die(){
        player_Died = true;
        player.SetActive(false);
        shadow.SetActive(false);
        GameplayController.instance.moveSpeed = 0f;

        //PLAY SOUND PLAYER DEAD
        //PLAY SOUND GAME OVER
    }
    
    void DieWithObstacles(Collider2D target){
        Die();
        explosion.transform.position = target.gameObject.transform.position;
        explosion.SetActive(true);  
        target.gameObject.SetActive(false);
    }

    IEnumerator TrexMode(){
        yield return new WaitForSeconds(7f);
        if(TRex_Trigger){
            TRex_Trigger = false;
            player_Renderer.sprite = player_Sprite;
        }
    }

    void DestroyObstacles(Collider2D target){
        explosion.transform.position = target.transform.position;
        explosion.SetActive(false);
        explosion.SetActive(true);

        target.gameObject.SetActive(false);

        //Sound manager 
    }

    private void OnTriggerEnter2D(Collider2D target) {
        if(target.tag==MyTags.OBSTACLE){
            if(!TRex_Trigger){
                DieWithObstacles(target);
            }
            else{  //in trex mode
                DestroyObstacles(target);
            }
        }

        if(target.tag==MyTags.T_REX){
            TRex_Trigger=true;
            player_Renderer.sprite = TRex_Sprite;
            target.gameObject.SetActive(false);

            StartCoroutine(TrexMode());

            //SOUND MANAGER TO PLAY MUSIC
        }

        if(target.tag==MyTags.STAR){
            for(int i = 0 ; i < star_Effect.Length ; i++){
                if(!star_Effect[i].activeInHierarchy){
                    star_Effect[i].transform.position = target.transform.position;
                    star_Effect[i].SetActive(true);
                    break;
                }
            }

            target.gameObject.SetActive(false);
            
            //PLAY SOUND
            //CONTROLLER INCREASE STAR SCORE
        }
    }

}
