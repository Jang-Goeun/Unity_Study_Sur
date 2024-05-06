using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.Rendering;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    public Scanner scanner;
    public Hand[] hands;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
        hands = GetComponentsInChildren<Hand>(true);
    }

    void Update()
    {
        if (!GameManager.instance.isLive)
            return;

        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (!GameManager.instance.isLive)
            return;

        Vector2 nextvec = inputVec.normalized * speed * Time.fixedDeltaTime;
        //1. 힘을 준다.
        //rigid.AddForce(inputVec);

        //2. 속도 제어
        //rigid.velocity = inputVec;

        //3. 위치 이동
        rigid.MovePosition(rigid.position + nextvec);
    }

    void LateUpdate()
    {
        if (!GameManager.instance.isLive)
            return;

        anim.SetFloat("Speed", inputVec.magnitude);
        if(inputVec.x != 0) {
            spriter.flipX = (inputVec.x < 0);
        }
    }
}
