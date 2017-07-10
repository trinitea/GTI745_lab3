using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MaestroCameraController : MonoBehaviour {

    public float cameraSensitivity = 5.0f;
    public float smoothing = 2.0f;
    
    public Text debugText;

    [SerializeField]
    private Image crosshair;

    public Sprite normalCrosshair;
    public Sprite physicInteractCrosshair;
    public Sprite uiCrosshair;
    public Sprite partyCrosshair;
    public Sprite party2Crosshair;
    public Sprite surpriseCrosshair;

    private Vector2 mouseLook;
    private Vector2 smoothV;

    private GameObject maestro;
    private PhysicsRaycaster raycaster;

    private IInteractable currentInteractable;
    private PointerEventData ped;

    // Use this for initialization
    void Start () {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        maestro = this.transform.parent.gameObject;
        raycaster = GetComponent<PhysicsRaycaster>();

        crosshair.sprite = normalCrosshair;

        //ped = new PointerEventData(EventSystem.current);
        //ped.position = new Vector2(0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        // Look
        float cameraSmoothing = cameraSensitivity * smoothing;

        Vector2 look = Vector2.Scale(new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")), new Vector2(cameraSensitivity * smoothing, cameraSensitivity * smoothing));

        smoothV.x = Mathf.Lerp(smoothV.x, look.x, 1.0f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, look.y, 1.0f / smoothing);

        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90, 90);

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        maestro.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, maestro.transform.up);


        // Raycast
        List<RaycastResult> hits = new List<RaycastResult>();

        ped = new PointerEventData(EventSystem.current);
        ped.position = GetComponent<Camera>().ViewportToScreenPoint(new Vector3(0.5f, 0.5f));//new Vector2(0.5f, 0.5f);

        Debug.Log("MousePosition =>  [" + GetComponent<Camera>().ViewportToScreenPoint(new Vector3(0.5f, 0.5f)) + "]");

        //raycaster.Raycast(ped, hits);
        //graphRaycaster.Raycast(ped, hits);

        EventSystem.current.RaycastAll(ped, hits);

        IInteractable newInteractable = null;

        if (hits.Count > 0)
        {
            foreach(RaycastResult result in hits)
            {
                newInteractable = result.gameObject.GetComponent<IInteractable>();

                if (newInteractable != null)
                {
                    debugText.text = newInteractable.DebugText();
                    break;
                }
            }
        }

        if (newInteractable == null)
        {
            if (currentInteractable != null)
            {
                currentInteractable.OnLookAtEnd(ped);
                currentInteractable = null;

                debugText.text = "No target";
                ChangeCrossHair(InteractableType.NONE);
            }
        }
        else if(newInteractable != currentInteractable)
        {

            currentInteractable = newInteractable;
            newInteractable.OnLookAtStart(ped);

            debugText.text = currentInteractable.DebugText();
            ChangeCrossHair(currentInteractable.GetInteractableType());
        }

        if (Input.GetButtonDown("Fire1") && currentInteractable != null)
        {
            currentInteractable.OnInteract();
        }
    }

    private void ChangeCrossHair(InteractableType type) {

        switch (type)
        {
            case InteractableType.PHYSICAL:
                crosshair.sprite = physicInteractCrosshair;
                break;

            case InteractableType.UI:
                crosshair.sprite = uiCrosshair;
                break;

            case InteractableType.PARTY:
                crosshair.sprite = partyCrosshair;
                break;

            default:
                crosshair.sprite = normalCrosshair;
                break;
        }

    }


}
