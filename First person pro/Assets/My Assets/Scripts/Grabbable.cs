using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public GameObject GrabbableObject;

    public void PickupObject()
    {
        Destroy(GrabbableObject);
    }

}
