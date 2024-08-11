using UnityEngine;

public class VFXController : MonoBehaviour
{
    public GameObject vfxPrefab; 
    public Transform vfxSpawnPoint;
    public bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.R)) 
        {
            ActivateVFX();
        }
    }

    public void ActivateVFX()
    {
        Instantiate(vfxPrefab, vfxSpawnPoint.position, vfxSpawnPoint.rotation);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            playerInRange = false;
        }
    }
}
