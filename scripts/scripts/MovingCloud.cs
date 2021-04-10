using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCloud : MonoBehaviour
{
   public float speed;
   
   
   float xDir;
   
   // Start is called before the first frame update
    void Start()
    {
        xDir = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        xDir -= Time.deltaTime * speed;

        transform.position = new Vector3 (xDir, transform.position.y, transform.position.z);
    }
}
