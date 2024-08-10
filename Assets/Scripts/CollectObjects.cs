using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObjects : MonoBehaviour
{
    private bool haveObject = false;
    private bool doorIsOpen = false;
    public GameObject door; 
    public Vector3 doorOpenPosition; 
    public float moveSpeed = 2f; 
    
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
        if (haveObject && !doorIsOpen)
        {
            MoveDoor();
        }
    }
    private void MoveDoor()
    {
        door.transform.position = Vector3.MoveTowards(door.transform.position, doorOpenPosition, moveSpeed * Time.deltaTime);

        if (door.transform.position == doorOpenPosition)
        {
            doorIsOpen = true;
        }
    }
}
