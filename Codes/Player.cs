using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;

    SpriteRenderer spriter;
    Rigidbody2D rigid;
    Animator anim;



        // Start is called before the first frame update
    void Awake()
    {
      rigid = GetComponent<Rigidbody2D>();
      spriter = GetComponent<SpriteRenderer>();
      anim = GetComponent<Animator>();


    }

    // Update is called once per frame

    void FixedUpdate()
    {
    //    // 1. 힘을준다
    //    rigid.AddForce(inputVec);

    //    // 2 .속도제어
       
    //    rigid.velocity = inputVec;

       // 3 .위치이동
       Vector2 nextVec =inputVec * speed  * Time.fixedDeltaTime;
       rigid.MovePosition(rigid.position + nextVec);

    }
    void LateUpdate() 
    {

      anim.SetFloat("Speed", inputVec.magnitude);

      

      if (inputVec.x !=0) {
        spriter.flipX = inputVec.x < 0 ;
        }
    }
    void OnMove(InputValue value)

    { inputVec = value.Get<Vector2>();

    }
}
