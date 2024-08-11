using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOC : MonoBehaviour
{
    public float proximityDistance = 5f;
    public float distance;
    private Transform playerTransform;
    private bool isPlayingFastSound = false;

    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        distance = Vector3.Distance(playerTransform.position, transform.position);

        if (distance <= proximityDistance && !isPlayingFastSound)
        {
            AudioManager.Instance.PlaySlowTickTock();
            isPlayingFastSound = true;
        }
        else if (distance > proximityDistance && isPlayingFastSound)
        {
            AudioManager.Instance.PlayFastTickTock();
            isPlayingFastSound = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; // Color del gizmo
        Gizmos.DrawWireSphere(transform.position, proximityDistance); // Dibuja una esfera alrededor del objeto
    }
}
