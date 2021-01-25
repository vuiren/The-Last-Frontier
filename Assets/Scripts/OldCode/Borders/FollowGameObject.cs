using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGameObject : MonoBehaviour
{
    [SerializeField]
    GameObject objectToFollow;

    // Update is called once per frame
    void LateUpdate()
    {
        var targetTransform = objectToFollow.transform;
        var targetPos = targetTransform.position;

        var selfPos = transform.position;
        var newPos = new Vector3(targetPos.x, selfPos.y, selfPos.z);
        transform.position = newPos;
    }
}
