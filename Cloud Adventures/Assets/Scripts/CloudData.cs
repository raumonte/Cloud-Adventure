using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudData : MonoBehaviour
{
    public int health = 20;
    public CloudMover mover;
    public float speed;
    public float rotateSpeed;
    public float damageDone;
    public float shootDelay;
    public GameObject bullet;
    public Vector2 shootOffset = new Vector2(0.8f, 0.25f);
    public float fireRateModifier = 1;
    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<CloudMover>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
