using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOC : MonoBehaviour
{
    public float proximityDistance = 5f;

    private Transform playerTransform;
    private bool isPlayingFastSound = false;

    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(playerTransform.position, transform.position);

        if (distance <= proximityDistance && !isPlayingFastSound)
        {
            AudioManager.instance.PlayFastTickTock();
            isPlayingFastSound = true;
        }
        else if (distance > proximityDistance && isPlayingFastSound)
        {
            AudioManager.instance.PlaySlowTickTock();
            isPlayingFastSound = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; // Color del gizmo
        Gizmos.DrawWireSphere(transform.position, proximityDistance); // Dibuja una esfera alrededor del objeto
    }
}
