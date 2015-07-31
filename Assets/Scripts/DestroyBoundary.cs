﻿using UnityEngine;
using System.Collections;

public class DestroyBoundary : MonoBehaviour {

    void OnTriggerExit(Collider Other)
    {
        Destroy(Other.gameObject);
    }
}
