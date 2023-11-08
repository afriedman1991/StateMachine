using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : InteractableBehavior, Interactable
{
    private Vector3 rotationSpeed = new Vector3(0f, 100f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
