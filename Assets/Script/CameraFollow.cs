using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private int speed;
    [SerializeField] private float offSetX, offSetY;
    private Vector3 temp;
    private void LateUpdate()
    {
        temp = player.position;
        temp.x += offSetX;
        temp.y += offSetY;
        temp.z = -10f;
        transform.position = Vector3.Lerp(transform.position, temp, speed * Time.deltaTime);
    }
}
