using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> Actors { get; private set; }

    void Awake()
    {
        Actors = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Debug.Log(Actors.Count);
    }
}
