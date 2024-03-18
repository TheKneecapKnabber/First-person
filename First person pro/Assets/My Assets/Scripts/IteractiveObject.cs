using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class IteractiveObject : MonoBehaviour
{
    
    //Selection default
    private string _selectTag;
    
    private Transform _selection;
    
    public float distanceFromItem = 3f;




    private void Update()
    {
        if (_selection != null)
        {
            if (_selection.GetComponent<Interactable>() != null)
            {
                _selection.GetComponent<Interactable>().HideItemInteractable();
            }

            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * distanceFromItem, Color.red);

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distanceFromItem))
        {
            //Debug.Log("test"); ***(this was just for testing)***

            var selection = hit.transform;

            if (selection.GetComponent<Interactable>() != null)
            {
                selection.GetComponent<Interactable>().ShowItemInteractable();
            }

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                if (selection.GetComponent<LeverAndDoor>() != null)
                {
                    selection.GetComponent<LeverAndDoor>().LeverInteraction();
                }
                
                if (selection.GetComponent<LightFire>() != null)
                {
                    selection.GetComponent<LightFire>().FireLight();

                }

                if (selection.GetComponent<Grabbable>() != null)
                {
                    selection.GetComponent<Grabbable>().PickupObject();

                }
                _selection = selection;
            }

        }


    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            //hasKey = true;
            Destroy(other.gameObject);

        }
    }*/
}

