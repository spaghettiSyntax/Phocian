using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Tower towerPrefab = null;

    // Property Example
    [SerializeField] private bool isPlaceable = false;
    public bool IsPlaceable { get { return isPlaceable; } }

    //// Getter Example
    //public bool GetIsPlaceable() { return isPlaceable; }

    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            //Debug.Log(transform.name);
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            isPlaceable = !isPlaced;
        }
    }
}
