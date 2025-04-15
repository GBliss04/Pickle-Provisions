using System.Collections.Generic;
using UnityEngine;

public class GroupTriggerManager : MonoBehaviour
{
    public List<GameObject> triggerGroups; // List of Empty GameObjects (each containing trigger objects)
    private int currentGroupIndex = 0;
    private HashSet<GameObject> triggeredObjects = new HashSet<GameObject>();

    void Start()
    {
        // Check if triggerGroups are set up correctly
        if (triggerGroups == null || triggerGroups.Count == 0)
        {
            Debug.LogError("No trigger groups assigned! Please add groups in the inspector.");
            return;
        }

        // Ensure only the first group is active
        SetGroupActive(triggerGroups[0], true);
        Debug.Log($"Group 1 is Active");
        for (int i = 1; i < triggerGroups.Count; i++)
        {
            SetGroupActive(triggerGroups[i], false);
            Debug.Log($"Group {i + 1} is Inactive");
        }
    }

    public void OnTriggerActivated(GameObject trigger)
    {
        // Ensure we are in a valid group
        if (triggerGroups.Count == 0 || currentGroupIndex >= triggerGroups.Count) return;

        GameObject currentGroup = triggerGroups[currentGroupIndex];

        // Make sure the object belongs to the current active group
        if (!trigger.transform.IsChildOf(currentGroup.transform))
        {
            Debug.LogWarning($"{trigger.name} is not part of the current active group!");
            return;
        }

        // Add the triggered object
        if (!triggeredObjects.Contains(trigger))
        {
            triggeredObjects.Add(trigger);
            Debug.Log($"{trigger.name} triggered! {triggeredObjects.Count}/{currentGroup.transform.childCount} in Group {currentGroupIndex + 1}");
        }

        // Check if all objects in the current group have been triggered
        if (triggeredObjects.Count >= currentGroup.transform.childCount)
        {
            MoveToNextGroup();
        }
    }

    private void MoveToNextGroup()
    {
        Debug.Log($"Group {currentGroupIndex + 1} completed. Moving to the next group...");

        // Disable current group
        SetGroupActive(triggerGroups[currentGroupIndex], false);
        triggeredObjects.Clear(); // Reset for the next group

        // Move to the next group if available
        if (currentGroupIndex + 1 < triggerGroups.Count)
        {
            currentGroupIndex++;
            SetGroupActive(triggerGroups[currentGroupIndex], true);
            Debug.Log($"Group {currentGroupIndex + 1} is now active!");
        }
        else
        {
            Debug.Log("All groups completed!");
        }
    }

    private void SetGroupActive(GameObject group, bool isActive)
    {
        foreach (Transform child in group.transform)
        {
            child.gameObject.SetActive(isActive);
            Debug.Log("Setting game object " + isActive);
        }
    }
}