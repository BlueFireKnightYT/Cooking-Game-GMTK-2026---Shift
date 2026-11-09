using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class InteractWithCustomer : MonoBehaviour
{
    RaycastHit hit;
    GameObject camera;
    public LayerMask customerLayer;

    public float maxInteractDistance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void interact(InputAction.CallbackContext context)
    { 
        bool hasHit = Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, maxInteractDistance, customerLayer);

        if(hasHit)
        {
            hit.transform.GetComponent<CustomerOrderSys>().CheckOrder();
        }
    }
}
