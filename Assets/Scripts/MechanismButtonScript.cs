﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanismButtonScript : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.SetBool("Enable", true);
        }
    }
}