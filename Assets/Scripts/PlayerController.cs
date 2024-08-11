using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Variables")]
    Rigidbody playerRigidB;
    [SerializeField] float movX, movZ;
    [Range(15,20)]
    public float speed;
    [Range(1,5)]
    public float decal;
    [Range(1,5)]
    public float horizontalDecal;
    float cameraHorizontalRotation = 0f;
    [Range(1,5)]
    public int jumpForce;
    Vector3 movement;
    [SerializeField] Transform controlRot;

    [Header("CellPhone")]
    [SerializeField] Animator animator;
    [SerializeField] GameObject flash;
    bool activePhone, flashActive;
    public LayerMask interactables;
    RaycastHit hit;


    void Start()
    {
        playerRigidB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");
        movement = transform.forward * movZ + transform.right * movX;
        
        RotatePlayer();
        
        if(Input.GetButtonDown("Jump"))
        {
            JumpPlayer();
        }

        if(Input.GetButtonDown("Fire1") && RayOut())
        {
            hit.collider.GetComponent<TableSubject>().OpenClose();
        }

        if(Input.GetButtonDown("Fire2"))
        {
            activePhone = !activePhone;
            animator.SetBool("usePhone", activePhone);
        }

        if(Input.GetButtonDown("Light"))
        {
            if(activePhone)
            {
                flashActive = !flashActive;
                flash.SetActive(flashActive);
            }
        }
    }
    private void FixedUpdate() {
        
        MovePlayer();
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
        playerRigidB.AddForce(movement.normalized * speed, ForceMode.Acceleration);
    }
    void RotatePlayer()
    {
        cameraHorizontalRotation -= Input.GetAxis("Mouse Y") * horizontalDecal;
        controlRot.localEulerAngles = Vector3.right * cameraHorizontalRotation;

        transform.Rotate(0, Input.GetAxis("Mouse X") * decal, 0);
    }

    void JumpPlayer()
    {
        playerRigidB.AddForce(transform.up *jumpForce, ForceMode.Impulse);
    }
}


