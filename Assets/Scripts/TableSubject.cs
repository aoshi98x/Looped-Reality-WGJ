using DG.Tweening;
using UnityEngine;

public class TableSubject : MonoBehaviour
{
    public bool isOpen;
    [SerializeField]Transform drawer;
    

    public void OpenClose()
    {
        isOpen = !isOpen;
        if(isOpen)
        {
            drawer.localPosition = new Vector3(drawer.localPosition.x,drawer.localPosition.y, -0.7f);
        }
        else{

            drawer.localPosition = new Vector3(drawer.localPosition.x,drawer.localPosition.y, 0);
        }
    }
}
