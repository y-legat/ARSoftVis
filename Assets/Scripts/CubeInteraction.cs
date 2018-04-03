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
    private Vector3 initalRotation;
    private Vector3 updatedRotation;
    private Renderer parents;

    #region UnityAPI
    
    private void OnValidate()
    {
        
    }

    public void Awake()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
        parents = gameObject.GetComponentInParent<Renderer>();
        Debug.Log(parents);
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
            updatedRotation = Vector3.zero;
            updatedRotation.x = 1;
            transform.localRotation *= Quaternion.Euler(updatedRotation);
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
        StartRotation();
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
