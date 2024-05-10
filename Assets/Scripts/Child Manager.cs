using System.Collections.Generic;
using UnityEngine;

public class ChildManager : MonoBehaviour
{
    public List<GameObject> numberOfChildren = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToList()
    { 
        numberOfChildren.Add(gameObject);
    }
}
