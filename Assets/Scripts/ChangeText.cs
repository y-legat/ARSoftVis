using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class ChangeText : MonoBehaviour, IFocusable {

    private InputManager inputManager;
    private TextMesh textMesh;

    public void Awake()
    {
        inputManager = InputManager.Instance;

        if (inputManager != null)
        {
            inputManager.OverrideFocusedObject = gameObject;
        }

        textMesh = FindObjectOfType<TextMesh>();

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnFocusEvent()
    {
        if (textMesh != null && inputManager != null)
        {
            // todo visibility text
            Debug.Log(gameObject.name);
            //textMesh.text = "package_02";
            textMesh.text = gameObject.name;
            inputManager.OverrideFocusedObject = null;
        }
    }

    public void OnFocusExit()
    {
        if(textMesh != null && inputManager != null)
        {
            // todo visibility text
            //Debug.Log(gameObject.name);
            //textMesh.text = "package_02";
            textMesh.text = "Select House";
           
        }
    }

    public void OnFocusEnter()
    {
        Debug.Log("onfocusEnter");
    }


    public void OnInputClicked(InputClickedEventData eventData)
    {


        
        Debug.Log("Click");
        eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.

        if (textMesh != null && inputManager != null)
        {
            // todo visibility text
            //Debug.Log(gameObject.name);
            //textMesh.text = "package_02";
            textMesh.text = gameObject.name;
            inputManager.OverrideFocusedObject = null;
        }
    }
}
