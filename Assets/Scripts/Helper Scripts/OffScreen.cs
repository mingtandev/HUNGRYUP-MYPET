using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffScreen : MonoBehaviour
{
    // Start is called before the first frame update

    //This script attch to grass(top) , grass bottom , land 1 2 3 4 5 , road ,  ground3(we cant use ground1 2 3 because ground3 is parent of it , we just only move ground3) 
    SpriteRenderer sprite;
    private void Awake() {
        sprite = GetComponent<SpriteRenderer>();
    } 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);  // this funtion will be return 6 plane (3d top bot , right left , near far) to check Camera in side

        //Check if bounds of sprite inside planes of camera
        if(!GeometryUtility.TestPlanesAABB(planes,sprite.bounds)){
            if(transform.position.x - Camera.main.transform.position.x<0f){
                Regen();
            }
        }   
    }

    void Regen(){
        if(this.tag==MyTags.TOP_NEAR_GRASS){
            ChangePos(ref MapGenerator.instance.last_Pos_Of_Top_Near_Grass , new Vector3(1.2f,0f,0f) ,  ref MapGenerator.instance.last_Order_Of_Top_Near_Grass);
        }

        else if(this.tag == MyTags.ROAD){
            ChangePos(ref MapGenerator.instance.last_Pos_Of_Road_Tile , new Vector3(1.5f,0f,0f), ref MapGenerator.instance.last_Order_Of_Road);
        }
        else if(this.tag == MyTags.TOP_FAR_GRASS){
            ChangePos(ref MapGenerator.instance.last_Pos_Of_Top_Far_Grass , new Vector3(4.8f , 0f , 0f) , ref MapGenerator.instance.last_Order_Of_Top_Far_Grass);
        }
        else if(this.tag == MyTags.BOTTOM_NEAR_GRASS){
            ChangePos(ref MapGenerator.instance.last_Pos_Of_Bottom_Near_Grass , new Vector3(1.2f , 0f , 0f) , ref MapGenerator.instance.last_Order_Of_Bottom_Near_Grass);
        }
        else if(this.tag == MyTags.BOTTOM_FAR_LAND_1){
            ChangePos(ref MapGenerator.instance.last_Pos_Of_Botom_Far_Land_F1 , new Vector3(1.6f , 0f , 0f) , ref MapGenerator.instance.last_Order_Of_Bottom_Far_Land_F1);
        }
        else if(this.tag == MyTags.BOTTOM_FAR_LAND_2){
            ChangePos(ref MapGenerator.instance.last_Pos_Of_Botom_Far_Land_F2 , new Vector3(1.6f , 0f , 0f) , ref MapGenerator.instance.last_Order_Of_Bottom_Far_Land_F2);
        }
        else if(this.tag == MyTags.BOTTOM_FAR_LAND_3){
            ChangePos(ref MapGenerator.instance.last_Pos_Of_Botom_Far_Land_F3 , new Vector3(1.6f , 0f , 0f) , ref MapGenerator.instance.last_Order_Of_Bottom_Far_Land_F3);
        }
        else if(this.tag == MyTags.BOTTOM_FAR_LAND_4){
            ChangePos(ref MapGenerator.instance.last_Pos_Of_Botom_Far_Land_F4 , new Vector3(1.6f , 0f , 0f) , ref MapGenerator.instance.last_Order_Of_Bottom_Far_Land_F4);
        }
        else if(this.tag == MyTags.BOTTOM_FAR_LAND_5){
            ChangePos(ref MapGenerator.instance.last_Pos_Of_Botom_Far_Land_F5 , new Vector3(1.6f , 0f , 0f) , ref MapGenerator.instance.last_Order_Of_Bottom_Far_Land_F5);
        }
    }


    void ChangePos(ref Vector3 pos , Vector3 offset , ref int orderinLayer){
        transform.position = pos;
        pos+=offset;
        sprite.sortingOrder = orderinLayer;
        //dont forget set order inlayer of child because ground3 (TOP FAR GRASS ) is enable = false to show child
        if(this.tag == MyTags.TOP_FAR_GRASS){
            gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingOrder = orderinLayer;
        }
        orderinLayer++;
        
    }
}
