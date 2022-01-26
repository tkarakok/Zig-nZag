using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody _rigidbody;
    private bool _forward = true;
    private Vector3 direction = Vector3.forward;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StateManager.Instance.state = State.InGame;
        }
        if (StateManager.Instance.state == State.InGame)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_forward)
                {
                    _forward = false;
                    direction = Vector3.left;
                }
                else
                {
                    _forward = true;
                    direction = Vector3.forward;
                }
            }
            transform.Translate(direction * _speed * Time.deltaTime);
        }
    }


}
