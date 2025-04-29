using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Needed for loading scenes

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

        // Only the first group is active at start
        SetGroupActive(triggerGroups[0], true);

        for (int i = 1; i < triggerGroups.Count; i++)
        {
            SetGroupActive(triggerGroups[i], false);
        }
    }

    public void OnTriggerActivated(GameObject trigger)
    {
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
        }

        // Check if all objects in the current group have been triggered
        if (triggeredObjects.Count >= currentGroup.transform.childCount)
        {
            MoveToNextGroup();
        }
    }

    private void MoveToNextGroup()
    {
        // Disable current group
        SetGroupActive(triggerGroups[currentGroupIndex], false);
        triggeredObjects.Clear(); // Reset triggered list

        currentGroupIndex++;

        if (currentGroupIndex < triggerGroups.Count)
        {
            // Activate the next group
            SetGroupActive(triggerGroups[currentGroupIndex], true);
        }
        else
        {
            // No more groups - all completed!
            Debug.Log("All groups completed! Loading Credits scene...");
            SceneManager.LoadScene("Credits");
        }
    }

    private void SetGroupActive(GameObject group, bool isActive)
    {
        foreach (Transform child in group.transform)
        {
            child.gameObject.SetActive(isActive);
        }
    }
}
