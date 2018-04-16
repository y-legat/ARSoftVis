using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class CubeInteraction : MonoBehaviour, IFocusable, IInputClickHandler , ISpeechHandler{

    public Color NormalColor;
    public Color HighlightColor;
    private Renderer myRenderer;
    private Material myMaterialInstance;
    private bool canRotate;
    //private Vector3 initalRotation;
    //private Vector3 updatedRotation;
   
    private InputManager inputManager;
    private TextMesh textMesh;

    #region UnityAPI

    private void OnValidate()
    {
        
    }

    public void Awake()
    {
        inputManager = InputManager.Instance;

        if (inputManager != null)
        {
            inputManager.OverrideFocusedObject = gameObject;
        }

        textMesh = FindObjectOfType<TextMesh>();

        myRenderer = gameObject.GetComponent<Renderer>();
        
        myMaterialInstance = myRenderer.material;
       // initalRotation = gameObject.transform.localRotation.eulerAngles;
    }

    public void OnFocusEnter()
    {
       myMaterialInstance.color = HighlightColor;
       
    }

    public void OnFocusExit()
    {
        myMaterialInstance.color = NormalColor;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (canRotate)
        {
           // updatedRotation = Vector3.zero;
           //updatedRotation.x = 1;
           // transform.localRotation *= Quaternion.Euler(updatedRotation);
        }
		
	}

    private void OnDestroy()
    {
        Destroy(myMaterialInstance);
    }
    #endregion

    #region Input

    
    public void OnInputClicked(InputClickedEventData eventData)
    {


        //StartRotation();
        // Increase the scale of the object just as a response.
        gameObject.transform.localScale += 0.05f * gameObject.transform.localScale;
        Debug.Log("Click");
        if (textMesh != null && inputManager != null)
        {
            // todo visibility text
            //Debug.Log(gameObject.name);
            //textMesh.text = "package_02";
            textMesh.text = gameObject.name;
            inputManager.OverrideFocusedObject = null;
        }
        eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.

       
    }

    public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    {
       switch (eventData.RecognizedText.ToLower())
        {
            case "Rotate":
                canRotate = true;
                break;
        }
    }

    #endregion

    public void StartRotation()
    {
        canRotate = true;
    }
}
