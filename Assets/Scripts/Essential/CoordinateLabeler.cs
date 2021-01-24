/// <WARNING>
/// This script MUST be placed in the Editor folder prior to building for release.
/// </WARNING>

using UnityEngine;
using TMPro;
//using UnityEditor.Experimental.SceneManagement;

// ExecuteAlways will let us see code changes in Runtime and Editor modes
[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private Color blockedColor = Color.gray;
    [SerializeField] private Color exploredColor = Color.yellow;
    [SerializeField] private Color pathColor = new Color(1f, 0.5f, 0f); // Orange color

    private TextMeshPro label;
    private Vector2Int coordinates = new Vector2Int();
    private GridManager gridManager;

    // Before Lesson 30
    //private Waypoint waypoint;

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        label = GetComponent<TextMeshPro>();
        label.enabled = false;

        // Before Lesson 30
        //waypoint = GetComponentInParent<Waypoint>();

        DisplayCoordinates();
    }

    void Update()
    {
        //if (!Application.isPlaying && PrefabStageUtility.GetPrefabStage(gameObject) == null)
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
            // Turn on editor coordinate system
            label.enabled = true;
        }

        SetLabelColor();
        ToggleLabels();
    }

    private void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Set label to the opposite of the current active state
            label.enabled = !label.IsActive();
        }
    }

    private void SetLabelColor()
    {
        if (gridManager == null) { return; }

        Node node = gridManager.GetNode(coordinates);

        if (node == null) { return; }

        if (!node.isWalkable)
        {
            label.color = blockedColor;
        }
        else if (node.isPath)
        {
            label.color = pathColor;
        }
        else if (node.isExplored)
        {
            label.color = exploredColor;
        }
        else
        {
            label.color = defaultColor;
        }

        // Before Lesson 30
        //if (waypoint.IsPlaceable)
        //{
        //    label.color = defaultColor;
        //}
        //else
        //{
        //    label.color = blockedColor;
        //}
    }

    private void DisplayCoordinates()
    {
        // You cannot build a game with UnityEditor code built in
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        // Grabbing the y coord is actually the 2D x -> zed position due to 3D space
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = coordinates.x + "," + coordinates.y;
    }

    private void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
