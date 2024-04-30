using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class CharacterMovementHelper : MonoBehaviour
{

    private XROrigin XROrigin;
    private CharacterController XRCharacterController;
    private CharacterControllerDriver driver;


    // Start is called before the first frame update
    void Start()
    {
        XROrigin = GetComponent<XROrigin>();
        XRCharacterController = GetComponent<CharacterController>();
        driver = GetComponent<CharacterControllerDriver>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCharacterController();
    }

    /// <summary>
    /// Updates the <see cref="CharacterController.height"/> and <see cref="CharacterController.center"/>
    /// based on the camera's position.
    /// </summary>
    protected virtual void UpdateCharacterController()
    {
        if (XROrigin == null || XRCharacterController == null)
            return;

        var height = Mathf.Clamp(XROrigin.CameraInOriginSpaceHeight, driver.minHeight, driver.maxHeight);

        Vector3 center = XROrigin.CameraInOriginSpacePos;
        center.y = height / 2f + XRCharacterController.skinWidth;

        XRCharacterController.height = height;
        XRCharacterController.center = center;
    }
}
