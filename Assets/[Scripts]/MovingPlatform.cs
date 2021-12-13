// MovingPlatform.cs
// Lucas Dunster 101230948
// DLM: 12/12/21
// Controls moving platforms

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private PlatformDirections Direction;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float Distance;
    [SerializeField]
    private bool isLooping;

    private Vector2 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
        switch (Direction)
        {
            case PlatformDirections.HORIZONTAL:
                transform.position = new Vector2(startingPosition.x + Mathf.PingPong(Time.time * Speed, Distance), transform.position.y);
                break;
            case PlatformDirections.VERTICAL:
                transform.position = new Vector2(transform.position.x, startingPosition.y + Mathf.PingPong(Time.time * Speed, Distance));
                break;
            case PlatformDirections.DIAGONAL_UPRIGHT:
                transform.position = new Vector2(startingPosition.x + Mathf.PingPong(Time.time * Speed, Distance), startingPosition.y + Mathf.PingPong(Time.time * Speed, Distance));
                break;
            case PlatformDirections.DIAGONAL_DOWNRIGHT:
                transform.position = new Vector2(startingPosition.x + Mathf.PingPong(Time.time * Speed, Distance), startingPosition.y - Mathf.PingPong(Time.time * Speed, Distance));
                break;
            case PlatformDirections.DIAGONAL_UPLEFT:
                transform.position = new Vector2(startingPosition.x - Mathf.PingPong(Time.time * Speed, Distance), startingPosition.y + Mathf.PingPong(Time.time * Speed, Distance));
                break;
            case PlatformDirections.DIAGONAL_DOWNLEFT:
                transform.position = new Vector2(startingPosition.x - Mathf.PingPong(Time.time * Speed, Distance), startingPosition.y - Mathf.PingPong(Time.time * Speed, Distance));
                break;

        }

    }
}
