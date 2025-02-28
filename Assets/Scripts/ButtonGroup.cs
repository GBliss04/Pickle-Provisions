using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGroup : MonoBehaviour
{
    public GameObject nextGroup ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ButtonPushed()
    {
        // check if nextGroup is set
        if (nextGroup == null) 
        {
            Debug.Log("nextGroup is not defined, returning.");
            return;
        }
        // check if all children are activated
        bool allActive = true;
        for (int i = 0; i < transform.childCount; i++)
        {
            // Get each child by index
            Transform child = transform.GetChild(i);
            // Add the child GameObject to the list
            PressurePlateTakeMoney childScript = child.GetComponent<PressurePlateTakeMoney>();
            if (childScript != null)
            {
                if (!childScript.activated) {
                    allActive = false;
                    break;
                }
            }
        }
        if (allActive) {
        // if they are, get the nextGroup
        
        // make the nextGroup appear
        }
    }
}

