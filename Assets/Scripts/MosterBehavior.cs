using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MosterBehavior : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    Vector3 originalPosition;
    private NavMeshAgent _agent;
    
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _agent.destination = targetTransform.position;
    }

    public void Restart()
    {
        _agent.enabled = false;
        transform.position = originalPosition;
        _agent.enabled = true;
    }
}
