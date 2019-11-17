using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    float speed = 50;
    bool hasHit = false;
    public ParticleSystem motion;
    public ParticleSystem hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasHit)
        {
            transform.Translate((Vector3.right * speed) * Time.deltaTime);
        }

        Destroy(gameObject, 4.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            hasHit = true;
            motion.Stop();
            hit.Play();
            //Stop motion partcles
            //player hit particle effect
            Destroy(gameObject, .5f);
        }
    }
}
