using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverAndDoor : MonoBehaviour
{
    //Lever Stuffs
    public Animator LeverAnimator;
    public GameObject doorText;
    public bool hasKey = false;
    private bool _isDown = false;

    public void LeverInteraction()
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



    void DisableText()
    {
        ///doorText.SetActive(false);
    }
}
