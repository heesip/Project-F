using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public GameObject player;
    float offset = -10f;
    Vector3 target;
    public float followSpeed = 5;

    void FixedUpdate()
    {

        target = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + offset);
        transform.position = Vector3.Lerp(transform.position, target, followSpeed * Time.deltaTime);

    }

    public IEnumerator NextCam()
    {
        yield return null;
        followSpeed = 10000;
        yield return new WaitForSeconds(0.1f);
        followSpeed = 5;


    }

}
