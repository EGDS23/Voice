using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shooter : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] Arrow arrowPrefab;
    [SerializeField] int arrowNum;  // the number of arrows it will shoot during one activation interval
    [SerializeField] float shootingInterval;

    [SerializeField] float arrowSpeed = 2f;
    private Vector3 arrowDir;

    private AudioSource shootingAudioSource;


    private int remainingArrows;
    private bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        shootingAudioSource = gameObject.GetComponent<AudioSource>();
        arrowDir = target.position - transform.position;
        remainingArrows = 0;
        isActive = false;

        // Testing
        // remainingArrows = arrowNum;
        // StartCoroutine(Activate());
    }

    public IEnumerator Activate()
    {
        remainingArrows = arrowNum;
        if (!isActive)
        {
            isActive = true;
            while (remainingArrows > 0)
            {
                Arrow arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);
                arrow.SetDirectionAndSpeed(arrowDir, arrowSpeed);
                arrow.gameObject.SetActive(true);

                shootingAudioSource.Play();
                remainingArrows--;
                yield return new WaitForSeconds(shootingInterval);
            }
            isActive = false;
        }
        
    }

}
