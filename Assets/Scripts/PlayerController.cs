using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Variables")]
    CharacterController controller;
    [SerializeField] float movX, movZ;
    float gravityScale = -9.8f;
    [Range(0,5)]
    public float speed;
    [Range(0,1)]
    public float decal;
    [Range(1,5)]
    public int jumpForce;
    Vector3 movement;
    [SerializeField] Vector3 gravity;
    [Header("CellPhone")]
    [SerializeField] Animator animator;
    [SerializeField] GameObject flash;
    bool activePhone;
    public LayerMask interactables;
    RaycastHit hit;


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        
        movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");
        
        MovePlayer();
        RotatePlayer();
        
        if(Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            JumpPlayer();
        }

        if(!controller.isGrounded)
        {
            ApplyGravity();
        }
        else
        {
            gravity.y = -2;
        }
        if(Input.GetButtonDown("Fire2"))
        {
            activePhone = !activePhone;
            animator.SetBool("usePhone", activePhone);
        }
        if(Input.GetButtonDown("Fire1") && RayOut())
        {
            hit.collider.GetComponent<TableSubject>().OpenClose();
        }
    }
    bool RayOut()
    {
        
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        if(Physics.Raycast(ray, out hit, Mathf.Infinity, interactables))
        {
            return true;
        }
        else{
            return false;
        }
    }

    void MovePlayer()
    {
        movement = transform.right * movX + transform.forward * movZ;
        controller.SimpleMove(movement * speed);
    }
    void RotatePlayer()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X")* decal,0);
    }
    void ApplyGravity()
    {
        gravity.y += gravityScale * Time.deltaTime;
        controller.Move(gravity * Time.deltaTime);
    }

    void JumpPlayer()
    {
        gravity.y = Mathf.Sqrt(gravityScale * -2 *jumpForce);
        controller.Move(gravity * Time.deltaTime);
    }
}


