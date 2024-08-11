using UnityEngine;

public class TableSubject : MonoBehaviour
{
    public bool isOpen;
    [SerializeField]Transform drawer;
    public enum Orientation {x, y, z};
    public Orientation orientation;
    public float originValue, destinationValue;
    

    public void OpenClose()
    {
        isOpen = !isOpen;
        if(isOpen)
        {
            switch (orientation)
            {
                case Orientation.x:
                    
                    drawer.localPosition = new Vector3(destinationValue, drawer.localPosition.y, drawer.localPosition.z);

                break;
                case Orientation.y:
                    
                    drawer.localPosition = new Vector3(drawer.localPosition.x, destinationValue, drawer.localPosition.z);

                break;
                case Orientation.z:
                    
                    drawer.localPosition = new Vector3(drawer.localPosition.x,drawer.localPosition.y, destinationValue);

                break;
            }
        }
        else{
            
            switch (orientation)
            {
                case Orientation.x:
                    
                    drawer.localPosition = new Vector3(originValue, drawer.localPosition.y, drawer.localPosition.z);

                break;
                case Orientation.y:
                    
                    drawer.localPosition = new Vector3(drawer.localPosition.x, originValue, drawer.localPosition.z);

                break;
                case Orientation.z:
                    
                    drawer.localPosition = new Vector3(drawer.localPosition.x,drawer.localPosition.y, originValue);

                break;
            }
        }
    }
}
