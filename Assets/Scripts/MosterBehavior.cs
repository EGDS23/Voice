using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MosterBehavior : MonoBehaviour
{

    [SerializeField] private Transform playerTarget;
    [SerializeField] private Transform initialTarget; // The location that monster will charge to at the very begining of the game
    private Transform _currentTarget;
    Vector3 originalPosition;
    private NavMeshAgent _agent;
    private AudioSource _audioSource;

    
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        originalPosition = transform.position;
        _audioSource = GetComponent<AudioSource>();
        _currentTarget = initialTarget;
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentTarget == initialTarget)
        {
            if (Vector3.Magnitude(transform.position - _currentTarget.position) < 1.0f)
            {
                _currentTarget = playerTarget;
            }
        }
        _agent.destination = _currentTarget.position;
        float v = Vector3.Magnitude(_agent.velocity);
        _audioSource.volume = 0.4f + v / _agent.speed;
    }

    public void Restart()
    {
        _agent.enabled = false;
        transform.position = originalPosition;
        _currentTarget = initialTarget;
        _agent.enabled = true;
    }

}
