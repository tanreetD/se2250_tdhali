using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour

{
    // Start is called before the first frame update
    void Update()
    {
        this.transform.Rotate(new Vector3(0f, 0f, 0.1f));
    }
}
