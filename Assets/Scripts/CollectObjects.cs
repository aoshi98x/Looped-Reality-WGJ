using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObjects : MonoBehaviour
{
    private bool haveObject = false;
    private bool doorIsOpen = false;
    public GameObject door; 
    public float rotationSpeed = 2f; 
    public Vector3 pivotOffset;
    private float targetRotation = 90f;
    private float currentRotation = 0f;
    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("CorrectObject"))
        {
            Debug.Log("Objecto recogido " );
            haveObject = true; 
            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        if (haveObject && !doorIsOpen){
            RotateDoor();
        }
    }
    private void RotateDoor()

    {
        Vector3 pivotPoint = door.transform.position + pivotOffset;
        float rotationThisFrame = rotationSpeed * Time.deltaTime;

        if (currentRotation + rotationThisFrame > targetRotation){
            rotationThisFrame = targetRotation - currentRotation;
        }

        door.transform.RotateAround(pivotPoint, Vector3.up, rotationThisFrame);
        currentRotation += rotationThisFrame;

        if (currentRotation >= targetRotation){
            doorIsOpen = true;
        }

    }
}
