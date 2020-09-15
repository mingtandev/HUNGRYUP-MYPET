using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHolder : MonoBehaviour
{
    
    private float LimitAxisX;

    private Vector3 firstLinePos,
                    secondLinePos;

    // Start is called before the first frame update
    private void Awake() {
        firstLinePos = new Vector3(0,0,10f);
        secondLinePos = new Vector3(0.67f , 1.41f , 10f);
        //transform.position = new Vector3(transform.position.x , transform.position.y , 10);
    }
    void OnEnable() {
        for(int i = 0 ; i <gameObject.transform.childCount ; i++){
            gameObject.transform.GetChild(i).gameObject.SetActive(true);
        }
        

        if(Random.value <= 0.5f){
            transform.localPosition = firstLinePos;
        }
        else{
            transform.localPosition = secondLinePos;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position+= new Vector3(-GameplayController.instance.moveSpeed*Time.deltaTime , 0f , 0f);
    }

    void MoveLeft(){
        float posX = transform.position.x;
        posX-=GameplayController.instance.moveSpeed*Time.deltaTime;
        transform.position = new Vector2(posX,transform.position.y);
    }


}
