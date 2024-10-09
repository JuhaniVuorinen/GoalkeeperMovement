using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour

{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player"); // The player

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x -2, player.transform.position.y , player.transform.position.z );
    }
}
