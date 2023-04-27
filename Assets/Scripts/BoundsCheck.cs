using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{    
    private Bounds planeBounds;
    [SerializeField]
    private bool despawn;

    // Start is called before the first frame update
    void Start()
    {
        planeBounds = GameObject.Find("Plane").GetComponent<MeshRenderer>().bounds;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < -5 || transform.position.z > planeBounds.max.z + 5 || transform.position.z < planeBounds.min.z - 5 || transform.position.x > planeBounds.max.x + 5 || transform.position.x < planeBounds.min.x - 5)
        {
            if (despawn)
                Destroy(gameObject);
            else
                transform.position = new Vector3(0, 3, 0);
        }
    }
}
