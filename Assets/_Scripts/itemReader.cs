using System.Collections.Generic;
using UnityEngine;

public class itemReader : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        items.Add(other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        items.Remove(other.gameObject);
    }
}
