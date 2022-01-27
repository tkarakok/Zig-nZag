using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(.2f,.2f,.2f * Time.deltaTime);
    }
}
