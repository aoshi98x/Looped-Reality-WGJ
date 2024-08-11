using UnityEngine;

public class CurtainMovementPoints : MonoBehaviour
{
    public GameObject[] points;
    private int CurrentPos = 0;

    public void MoveCurtain()
    {
        if (CurrentPos < points.Length)
        {
            transform.position = points[CurrentPos].transform.position;
            CurrentPos++;
        }

        else
        {
            gameObject.SetActive(false);
        }
    }
}
