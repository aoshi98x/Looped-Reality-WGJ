using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderChecker : MonoBehaviour
{
    public bool imVisible;
    private void OnBecameInvisible() {

        imVisible=true;
        
    }
    private void OnBecameVisible() {

        imVisible=false;
        
    }
}
