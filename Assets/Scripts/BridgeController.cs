using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    private Animator _animator;

    private bool _isDrop;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!_isDrop)
        {
            _animator.SetTrigger("DropTrigger");
            _isDrop = true;
        }
    }
}