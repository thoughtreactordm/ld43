﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

    public float time;

    private void Awake()
    {
        Destroy(this.gameObject, time);
    }
}
