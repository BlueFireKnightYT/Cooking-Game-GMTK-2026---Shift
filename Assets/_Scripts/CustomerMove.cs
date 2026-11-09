using System.Collections.Generic;
using UnityEngine;

public class CustomerMove : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    public float speed;


    Transform targetpos;
    int index = 0;
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
            transform.position = Vector3.MoveTowards(transform.position, targetpos.position, speed * Time.deltaTime);

        if (transform.position == waypoints[index].position)
        {
            if (index == waypoints.Count - 1)
            {
                if(!startedOrder)
                {
                    StartCoroutine(GetComponent<CustomerOrderSys>().DecideOrder());
                    startedOrder = true;
                }
                return;
            }

            if (!completedOrder)
                index++;
            else
                index--;
            targetpos = waypoints[index];
        }
    }
}
