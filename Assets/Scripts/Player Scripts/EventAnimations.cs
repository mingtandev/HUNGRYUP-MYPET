using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventAnimations : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private string jump_Animation = "PlayerJump";
    private string walk_Animation = "PlayerWalk";

    
    private void Awake() {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerWalkAnimation()
    {
        anim.Play(walk_Animation);
    }

    public void AnimationEnded(){
        gameObject.SetActive(false);
    }
   
}
