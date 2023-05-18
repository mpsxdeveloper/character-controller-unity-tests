using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{

    private Animator animator;    
    private CharacterController controller;
    private Rigidbody rig;
    private Camera cam;
    private float gravity = 1.1f;
    private float speed = 1.5f;
    private float maxJumpHeight = 14f;
    private float jumpSpeed = 0f;
    private bool moving = false;
    private float walkSpeed = 0.15f;
    private bool right, left, up, down, jumping;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();        
        controller = GetComponent<CharacterController>();
        rig = GetComponent<Rigidbody>();
        cam = Camera.main;
        right = left = up = down = jumping = false;
        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 direction = Vector3.zero * speed;

        if(right) {
            MoveRight();
        }
        else if(left) {
            MoveLeft();
        }
        else if(down) {
            MoveDown();
        }
        else if(up) {
            MoveUp();
        }
        else if(jumping == true) {
            Jump();
        }        
        else {            
            animator.SetTrigger("idle");            
        }       
        
        jumpSpeed -= gravity;
        
        if(rig.velocity.z == 0f) {
            moving = false;            
        }
        if(moving == false) {
            animator.SetTrigger("idle");
        }
        if(controller.isGrounded) {
            jumping = false;            
        }

        direction.y = jumpSpeed;
        controller.Move(direction * Time.deltaTime);

    }
    
    void FixedUpdate() {
        cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, transform.position.z / 2);
    }

    public void SetRight(bool direction) {
        right = direction;
    }

    public void SetLeft(bool direction) {
        left = direction;
    }

    public void SetDown(bool direction) {
        down = direction;
    }

    public void SetUp(bool direction) {
        up = direction;
    }

    public void SetJump(bool direction) {
        jumping = direction;
    }

    public void MoveRight() {

        transform.rotation = Quaternion.Euler(0, 0, 0);
        moving = true;        
        animator.ResetTrigger("idle");
        animator.SetTrigger("run");
        controller.Move(Vector3.forward * walkSpeed);

    }

    public void MoveLeft() {

        transform.rotation = Quaternion.Euler(0, 180, 0);
        moving = true;
        animator.ResetTrigger("idle");
        animator.SetTrigger("run");                    
        controller.Move(Vector3.forward * -walkSpeed);
    
    }

    public void MoveDown() {
        
        transform.rotation = Quaternion.Euler(0, 90, 0);
        moving = true;
        animator.ResetTrigger("idle");
        animator.SetTrigger("run");                    
        controller.Move(Vector3.right * walkSpeed);

    }

    public void MoveUp() {
        
        transform.rotation = Quaternion.Euler(0, 270, 0);
        moving = true;
        animator.ResetTrigger("idle");
        animator.SetTrigger("run");                    
        controller.Move(Vector3.right * -walkSpeed);

    }

    private void Jump() {
        
        if(controller.isGrounded) {
            jumping = true;
            jumpSpeed = maxJumpHeight;            
        }

    }

    void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.tag == "Limits") {
            transform.position = new Vector3(startPos.x, startPos.y, startPos.z);
        }
    }

}