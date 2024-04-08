using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControl : MonoBehaviour
{

    public GameObject[] waypoints;
    int currentWP = 0;

    public float speed = 12.0f;
    public float rotSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        this.enabled = false;
        StartCoroutine(WaitThreeSeconds());
    }

    IEnumerator WaitThreeSeconds()
    {
        yield return new WaitForSeconds(3);
        this.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(this.transform.position, waypoints[currentWP].transform.position)< 8)
        { currentWP++; }
        if(currentWP >= waypoints.Length) 
        { currentWP = 0; }

        Quaternion lookAtWP = Quaternion.LookRotation(waypoints[currentWP].transform.position - this.transform.position);

        //this.transform.LookAt(waypoints[currentWP].transform);

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookAtWP, rotSpeed* Time.deltaTime);
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
