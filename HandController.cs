using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;



[RequireComponent(typeof(ActionBasedController))]
public class HandController : MonoBehaviour
{

    ActionBasedController controller;
    public Hand hand;

    // Start is called before the first frame update
    void Start()
    {
        //stores the component in a variable
        controller = GetComponent<ActionBasedController>();
    }

    // Update is called once per frame
    void Update()
    {

        //is the middlelman between the controller and the hand code, OOP abstraction
        hand.SetGrip(controller.selectAction.action.ReadValue<float>());
        hand.SetTrigger(controller.activateAction.action.ReadValue<float>());



        //hand.SetIndex(controller.selectAction.action.ReadValue<float>());
        //hand.SetMiddle(controller.selectAction.action.ReadValue<float>());
        //hand.SetRing(controller.selectAction.action.ReadValue<float>());
        //hand.SetPinky(controller.selectAction.action.ReadValue<float>());
        //hand.SetThumb(controller.selectAction.action.ReadValue<float>());
    }
}
