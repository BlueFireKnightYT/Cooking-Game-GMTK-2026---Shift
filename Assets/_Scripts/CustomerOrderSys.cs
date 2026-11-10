using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrderSys : MonoBehaviour
{
    int orderAmount;
    List<GameObject> orders = new List<GameObject>();
    List<GameObject> correctItems = new List<GameObject>();


    public List<GameObject> possibleOrders = new List<GameObject>();
    public itemReader counterItemReader;

    private void Start()
    {
        
    }

    public IEnumerator DecideOrder()
    {
        orderAmount = Random.Range(1, 5);
        yield return new WaitForSeconds(Random.Range(7, 16));

        for(int i = 0; i < orderAmount; i++)
        {
            orders.Add(possibleOrders[Random.Range(0, possibleOrders.Count)]);
        }

        foreach(GameObject order in orders)
            print(order);
    }

    public void CheckOrder()
    {
        correctItems.Clear();

        foreach (GameObject order in orders)
        {
            bool itemFound = false;
            foreach(GameObject item in counterItemReader.items)
            {
                if(!item.GetComponent<CookMeat>().canServe)
                {
                    print("Can't serve this item");
                    break;
                }
                if (order.CompareTag(item.tag))
                {
                    correctItems.Add(item);
                    itemFound = true;
                    break;
                }
            }

            if(!itemFound)
            {
                print("Order Incomplete");
                return;
            }
        }

        print("Complete!");

        for(int i = correctItems.Count - 1; i >=0; i--)
        {
            GameObject item = correctItems[i];
            //Destroy(item);
        }

        GetComponent<CustomerMove>().completedOrder = true;
        correctItems.Clear();
    }
}
