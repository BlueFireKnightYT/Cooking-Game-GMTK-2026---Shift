using UnityEngine;

public class CookMeat : MonoBehaviour
{
    Material material;
    float matValue = 0f;
    bool isCooking;


    public float cookSpeed;
    public bool canServe = false;

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if(isCooking)
        { 
            matValue += cookSpeed * Time.deltaTime;
            material.SetFloat("_CookProgress", matValue);

            if (matValue <= 0.5f)
            {
                name = "Raw";
                canServe = false;
            }
            else if (matValue <= 0.8f)
            {
                name = "Seared";
                canServe = true;
            }
            else
            {
                name = "Burnt";
                canServe = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Pan"))
        {
            isCooking = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pan"))
        {
            isCooking = false;
        }
    }
}
