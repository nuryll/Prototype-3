using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;


    void Start()
    {
        startPos = transform.position; // store the starting position of the background
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; // get the width of the background from its BoxCollider

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth) // if the background has moved left beyond its width
        {
            transform.position = startPos; // reset the position to the starting position


        }
    }
}
