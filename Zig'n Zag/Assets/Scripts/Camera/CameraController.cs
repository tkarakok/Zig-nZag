using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : Singleton<CameraController>
{
    public Vector3 position, rotation;

   public void ChangePOsition()
    {
        transform.DOMove(position, 1);
        transform.DORotate(rotation, 1);
    }
}
