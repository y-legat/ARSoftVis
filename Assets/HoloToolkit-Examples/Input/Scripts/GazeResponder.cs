// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    /// <summary>
    /// This class implements IFocusable to respond to gaze changes.
    /// It highlights the object being gazed at.
    /// </summary>
    public class GazeResponder : MonoBehaviour, IFocusable, IInputClickHandler
    {
        private Material[] defaultMaterials;
        private InputManager inputManager;
        private TextMesh textMesh;
        private GameObject text_01;


        private void Start()
        {
            defaultMaterials = GetComponent<Renderer>().materials;
        }
        private void Awake()
        {
            inputManager = InputManager.Instance;

            if (inputManager != null)
            {
                inputManager.OverrideFocusedObject = gameObject;
            }

            textMesh = FindObjectOfType<TextMesh>();
            text_01 = GameObject.Find("InfoText");
        }
        public void OnFocusEnter()
        {
            for (int i = 0; i < defaultMaterials.Length; i++)
            {
                // Highlight the material when gaze enters using the shader property.
                defaultMaterials[i].SetFloat("_Gloss", 70.0f);
               
                Debug.Log(gameObject.name);
            }
        }

        public void OnFocusExit()
        {
            for (int i = 0; i < defaultMaterials.Length; i++)
            {
                // Remove highlight on material when gaze exits.
                defaultMaterials[i].SetFloat("_Gloss", 1.0f);
            }
        }

        private void OnDestroy()
        {
            foreach (var material in defaultMaterials)
            {
                Destroy(material);
            }
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
           
            if (text_01.GetComponent<TextMesh>().text != null && inputManager != null)
            {
                // todo visibility text
               

                
                text_01.GetComponent<TextMesh>().text = gameObject.transform.parent.name;
                inputManager.OverrideFocusedObject = null;
            }
            
        }
    }
}