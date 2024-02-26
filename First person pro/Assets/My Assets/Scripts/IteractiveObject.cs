using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IteractiveObject : MonoBehaviour
{
    private string _selectTag = "InteractiveObject";
    public Material highlightMaterial;
    private bool _isHighlighted = false;

    private Transform _selection;

    public TMP_Text _nameDisplay;

    public float distanceFromItem = 3f;

    private void Update()
    {
        if (_selection != null)
        {
            _isHighlighted = false;
            Renderer selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material.DisableKeyword("_EMISSION");

            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distanceFromItem))
        {
            Debug.Log("test");
        }
    }
    
}
