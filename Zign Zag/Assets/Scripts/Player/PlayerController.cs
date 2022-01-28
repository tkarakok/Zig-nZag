using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : Singleton<PlayerController>
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
        if (StateManager.Instance.state == State.InGame)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameManager.Instance.Score++;
                UIManager.Instance.UpdateScoreText();
                if (_forward)
                {
                    _forward = false;
                    if (GameManager.Instance.GameMode == GameMode.Up)
                    {
                        direction = Vector3.left;
                    }
                    else
                    {
                        direction = Vector3.right;
                    }
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
