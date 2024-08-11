using UnityEngine;

public class CollectObjects : MonoBehaviour
{
    public bool haveObject = false;
    public bool correctObject = false;
    public CurtainMovementPoints locker; 
    

    private void Update()
    {
        if (haveObject && correctObject)
        {
            locker.MoveCurtain();
            haveObject = false;
            correctObject = false;
        }
    }
    
}
