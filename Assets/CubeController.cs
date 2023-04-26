using UnityEngine;

public class CubeController : MonoBehaviour
{
    public GameObject image;
    public float speed = 1.2f;

    private Vector3 originalPos;
    private bool isFalling;
    private float timer;

    private void Start()
    {
        originalPos = transform.position;
        isFalling = true;
        timer = 0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (isFalling)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);

            if (timer >= 2f)
            {
                timer = 0f;
                isFalling = false;
            }
        }
        else
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);

            if (timer >= 2f)
            {
                timer = 0f;
                isFalling = true;
            }
        }
    }

    // Use detection from the player's side instead
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            image.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
    }*/
}
