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
        GameObject city;


        private void Start()
        {
            defaultMaterials = GetComponent<Renderer>().materials;
            city = GameObject.Find("CityModel");

        }
        private void Awake()
        {
            inputManager = InputManager.Instance;

            if (inputManager != null)
            {
                inputManager.OverrideFocusedObject = gameObject;
            }
           // GameObject.Find("Canvas").SetActive(true);
            //GameObject.Find("Canvas/InfoText").SetActive(true);
            
            
        }
        public void OnFocusEnter()
        {
            if (city.activeSelf)
            {
                for (int i = 0; i < defaultMaterials.Length; i++)
                {
                    // Highlight the material when gaze enters using the shader property.
                    defaultMaterials[i].SetFloat("_Gloss", 70.0f);
                    Debug.Log(gameObject.name);
                }
            }
            
        }

        public void OnFocusExit()
        {
            if (city.activeSelf)
            {
                for (int i = 0; i < defaultMaterials.Length; i++)
                {
                    // Remove highlight on material when gaze exits.
                    defaultMaterials[i].SetFloat("_Gloss", 1.0f);
                }

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
            //text_01 = GameObject.Find("InfoText");
            //Debug.Log(GameObject.Find("InfoText"));
            //Debug.Log(text_01.GetComponent<TextMesh>());
            // if (text_01.activeSelf)

            text_01 = GameObject.Find("InfoText");
            //textMesh = FindObjectOfType<TextMesh>();
            textMesh = text_01.GetComponent<TextMesh>();

            if (text_01.GetComponent<TextMesh>().text != null && inputManager != null)
                {
                    // todo visibility text



                    text_01.GetComponent<TextMesh>().text = gameObject.transform.parent.name;
                    inputManager.OverrideFocusedObject = null;
                }
            
           

        }
    
    }
}