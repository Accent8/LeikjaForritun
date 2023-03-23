using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    // listi af waypointum svo að gameObject geti farið að þeim
    [SerializeField] GameObject[] waypoints;
    // index af hvaða waypointi gameobjectið er hjá
    int CurrentWayPointIndex = 0;
    // og svo breyta til að stilla hraða
    [SerializeField] float speed = 1f;

    void Update()
    {   // hérna er skoðað hvort að gameobjectið er minna en 0.1cm frá waypointinum sínum
        if (Vector3.Distance(transform.position, waypoints[CurrentWayPointIndex].transform.position) < .1f) {
            // þá er bætt inn í waypoint indexinn
            CurrentWayPointIndex++;
            // og svo ef waypoint indexinn er stærri en lengdinn af listannum
            if (CurrentWayPointIndex >= waypoints.Length) {
                // "resetar" waypoint indexin aftur bara í 0
                CurrentWayPointIndex = 0;
            }
        }
        // og svo breytann sem að færi gameobjectið að waypointinum
        // bara segir farðu í átt að waypointinum á þessum hraða :D
        transform.position = Vector3.MoveTowards(transform.position, waypoints[CurrentWayPointIndex].transform.position, speed * Time.deltaTime);
    }
}
