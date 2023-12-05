using UnityEngine;

public class MoveToSide : MonoBehaviour
{
    /// <summary>
    /// This rases a objekt, sutch as a gate, in a straigt line in x,y or z, and move back to orignal
    /// simalarity to "OpenCloseDoor"
    /// </summary>
    // Start is called before the first frame update

    private AudioSource sourceAudio;
    public AudioClip soundClip;

    private float currentPositon = 0; // float represent start pos
    public float targetPosition = 2; // movment magnitude

    public float moveSpeed = 1;

    private bool objektAtOrignal = true;

    private void OnEnable()
    {
        if (soundClip != null)
        {
            sourceAudio = GetComponent<AudioSource>();
            sourceAudio.PlayOneShot(soundClip);
        }

    }


    void Update()
    {
        if(objektAtOrignal)
        {
            MoveUp();
        }
        else if(!objektAtOrignal)
        {
            MoveDown();
        }
            
    }

    void MoveUp()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        currentPositon += moveSpeed * Time.deltaTime;

        if (currentPositon >= targetPosition)
        {
            objektAtOrignal = false; // objekt has moved away

            currentPositon = 0;

            enabled = false;
        }
    }

    void MoveDown()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime * (-1));

        currentPositon += moveSpeed * Time.deltaTime;

        if (currentPositon >= targetPosition)
        {
            objektAtOrignal = true; // objekt has moved back

            currentPositon = 0;

            enabled = false;
        }
    }
}
