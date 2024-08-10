using DG.Tweening;
using UnityEngine;

public class TableSubject : MonoBehaviour
{
    public bool isOpen;
    [SerializeField]Transform drawer;
    public float originValue, destinationValue;
    

    public void OpenClose()
    {
        isOpen = !isOpen;
        if(isOpen)
        {
            drawer.localPosition = new Vector3(drawer.localPosition.x,drawer.localPosition.y, destinationValue);
        }
        else{

            drawer.localPosition = new Vector3(drawer.localPosition.x,drawer.localPosition.y, originValue);
        }
    }
}
