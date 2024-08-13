using UnityEngine;

public class TableSubject : MonoBehaviour
{
    public enum ObjectType { Drawer, Door }
    public ObjectType objectType;
    public bool isOpen;
    [SerializeField]Transform drawer;
    public enum Orientation {x, y, z};
    public Orientation orientation;
    public float originValue, destinationValue;
    
    public void OpenClose()
    {
        isOpen = !isOpen;

        switch (objectType)
        {
            case ObjectType.Drawer:
                HandleDrawer();
                break;
            case ObjectType.Door:
                HandleDoor();
                break;
        }
    }

    public void HandleDrawer()
    {
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

    public void HandleDoor()
    {
        if(isOpen)
        {
            switch (orientation)
            {
                case Orientation.x:
                    
                    drawer.localRotation = Quaternion.Euler(destinationValue, drawer.localRotation.eulerAngles.y, drawer.localRotation.eulerAngles.z);

                break;
                case Orientation.y:
                    
                    drawer.localRotation = Quaternion.Euler(drawer.localRotation.eulerAngles.x, destinationValue, drawer.localRotation.eulerAngles.z);

                break;
                case Orientation.z:
                    
                    drawer.localRotation = Quaternion.Euler(drawer.localRotation.eulerAngles.x, drawer.localRotation.eulerAngles.y, destinationValue);

                break;
            }
        }
        else{
            
            switch (orientation)
            {
                case Orientation.x:
                    
                    drawer.localRotation = Quaternion.Euler(drawer.localRotation.eulerAngles.x, drawer.localRotation.eulerAngles.y, destinationValue);

                break;
                case Orientation.y:
                    
                    drawer.localRotation = Quaternion.Euler(drawer.localRotation.eulerAngles.x, originValue, drawer.localRotation.eulerAngles.z);

                break;
                case Orientation.z:
                    
                    drawer.localRotation = Quaternion.Euler(drawer.localRotation.eulerAngles.x, drawer.localRotation.eulerAngles.y, originValue);

                break;
            }
        }
    }
}
