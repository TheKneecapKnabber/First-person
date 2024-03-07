using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class IteractiveObject : MonoBehaviour
{
    
    //Selection default
    private string _selectTag;
    private bool _isHighlighted = false;
    private Transform _selection;
    public TMP_Text nameDisplay;
    public float distanceFromItem = 3f;

    //Lever Stuffs
    public Animator LeverAnimator;
    public GameObject doorText;
    public bool hasKey = false; 
    private bool _isDown = false;


    private void Update()
    {
        if (_selection != null)
        {
            nameDisplay.text = "";
            _isHighlighted = false;
            Renderer selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material.DisableKeyword("_EMISSION");

            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * distanceFromItem, Color.red);

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distanceFromItem))
        {
            //Debug.Log("test"); ***(this was just for testing)***

            var selection = hit.transform;

            if (selection.CompareTag("InteractiveObject") || selection.CompareTag("Lever"))
            {
                if(selection!= _isHighlighted)
                {
                    _isHighlighted = true;
                    selection.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                    nameDisplay.text = selection.gameObject.name; 
                }
                _selection = selection;
            }
        }
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            LeverInteraction(); 
        }
    }

    void LeverInteraction()
    {
        RaycastHit hitInfo;

        Vector2 mouseposition = Mouse.current.position.ReadValue();

        Ray rayOrigin = Camera.main.ScreenPointToRay(mouseposition);

        if(Physics.Raycast(rayOrigin,out hitInfo, distanceFromItem))
        {
            var selection = hitInfo.transform;
            if(!hasKey)
            {
                doorText.SetActive(true);
                Invoke("DisableText", 2f);
            }
            else            
            {
                if(selection.gameObject.tag == "Lever")
                {
                    if (!_isDown)
                    {

                        LeverAnimator.SetTrigger("Down");
                        LeverAnimator.ResetTrigger("Up");
                        _isDown = true;
                    }
                    else
                    {
                        LeverAnimator.SetTrigger("Up");
                        LeverAnimator.ResetTrigger("Down");
                        _isDown = false;
                    }

                }
            }
        }
    }
    void DisableText() 
    {
        doorText.SetActive(false);
    }
}
