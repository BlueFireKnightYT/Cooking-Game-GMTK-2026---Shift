using System.Xml;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pickup : MonoBehaviour
{
    public LayerMask pickupLayer;
    public float maxPickupDistance;
    public Transform handPos;

    GameObject camera;
    bool hasItem = false;
    RaycastHit hit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickupObject(InputAction.CallbackContext context)
    {
        if (context.performed && !hasItem)
        {
            bool hasHit = Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, maxPickupDistance, pickupLayer);
            if(hasHit)
            {
                hasItem = true;
                hit.rigidbody.isKinematic = true;
                hit.rigidbody.GetComponent<Collider>().isTrigger = true;

                hit.transform.position = handPos.position;
                hit.transform.rotation = handPos.rotation;

                hit.transform.SetParent(handPos);
            }
        }
        else if(context.performed && hasItem)
        {
            hasItem = false;

            hit.rigidbody.GetComponent<Collider>().isTrigger = false;

            hit.rigidbody.isKinematic = false;
            hit.transform.SetParent(null);
        }
    }
}
