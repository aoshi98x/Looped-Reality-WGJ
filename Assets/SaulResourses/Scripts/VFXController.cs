using UnityEngine;

public class VFXController : MonoBehaviour
{
    public GameObject vfxPrefab; 
    public Transform vfxSpawnPoint; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            ActivateVFX();
        }
    }

    public void ActivateVFX()
    {
        Instantiate(vfxPrefab, vfxSpawnPoint.position, vfxSpawnPoint.rotation);
        Destroy(gameObject);
    }
}
