using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDecay : MonoBehaviour
{
    public float lifetime_inseconds = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime_inseconds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
