using System.Collections.Generic;
using UnityEngine;

public class CustomerMove : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    public float speed;


    Transform targetpos;
    public int index = 0;
    bool startedOrder;
    public bool completedOrder;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetpos = waypoints[index];
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == waypoints[index].position)
        {
            if(completedOrder)
            { 
                index--;
                targetpos = waypoints[index];

                if(index == 0)
                {
                    completedOrder = false;
                    startedOrder = false;
                }
                return;
            }
            if (index == waypoints.Count - 1)
            {
                if(!startedOrder)
                {
                    StartCoroutine(GetComponent<CustomerOrderSys>().DecideOrder());
                    startedOrder = true;
                }
                return;
            }
            
            index++;
            targetpos = waypoints[index];
        }
        else transform.position = Vector3.MoveTowards(transform.position, targetpos.position, speed * Time.deltaTime);
    }
}
