using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObjects : MonoBehaviour
{
    public bool haveObject = false;
    public bool correctObject = false;
    public GameObject locker; 
    

    private void Update()
    {
        if (haveObject && correctObject){
            UnlockPass();
        }
    }
    private void UnlockPass()

    {
        locker.SetActive(false);
    }
}
