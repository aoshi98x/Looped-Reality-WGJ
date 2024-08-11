using Unity.VisualScripting;
using UnityEngine;

public class VFXController : MonoBehaviour
{
    public GameObject vfxPrefab; 
    public Transform vfxSpawnPoint;
    public bool playerInRange = false;
    public bool imCorrect;
    CollectObjects player;
    void Start()
    {
        player = FindAnyObjectByType<CollectObjects>();
    }

    void Update()
    {
        if (playerInRange && Input.GetButtonDown("ActionPlayer") && !player.haveObject) 
        {
            ActivateVFX();
            player.haveObject = true;
            player.correctObject = imCorrect;

        }
    }

    public void ActivateVFX()
    {
        Instantiate(vfxPrefab, vfxSpawnPoint.position, vfxSpawnPoint.rotation);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
