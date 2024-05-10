using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public int ammoCount;
    public float projectileSpeed = 10f;
    public Transform shootLocation;

    GameObject projectileGameObject;

    [SerializeField] ChildManager childManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ammoCount = childManager.numberOfChildren.Count;
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (ammoCount > 0)
        {
            projectileGameObject = childManager.numberOfChildren[0];
            projectileGameObject.GetComponent<ChildController>().isUsedAsProjectile = true;
            projectileGameObject.GetComponent<ChildController>().isPickedUp = false;
            projectileGameObject.GetComponent<BoxCollider2D>().enabled = true;
            projectileGameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            projectileGameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            projectileGameObject.transform.position = shootLocation.position;
            projectileGameObject.transform.localScale = new Vector3(1, 1, 1);
            projectileGameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);
            childManager.numberOfChildren.RemoveAt(0);
        }
    }
}
