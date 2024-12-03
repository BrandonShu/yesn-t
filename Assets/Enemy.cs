using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    EnemyManager m_EnemyManager;

    void Awake()
    {
        m_EnemyManager = GameObject.FindObjectOfType<EnemyManager>();

        // Register as an actor
        if (!m_EnemyManager.Actors.Contains(this.gameObject))
        {
            m_EnemyManager.Actors.Add(this.gameObject);
        }
    }

    void OnDestroy()
    {
        // Unregister as an actor
        if (m_EnemyManager)
        {
            m_EnemyManager.Actors.Remove(this.gameObject);
        }
    }

    void OnDisable()
    {
        // Unregister as an actor
        if (m_EnemyManager)
        {
            m_EnemyManager.Actors.Remove(this.gameObject);
        }
    }

}
