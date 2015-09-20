using UnityEngine;
using System.Collections;

public class SpawnTimeLine : TimeLine
{

    public GameObject prefab;
    public Transform bike;
    public Vector3 offset;

    public override void Trigger()
    {
        var bikeOffset = new Vector3(0, 0, bike != null ? bike.position.z : 0);
        Instantiate(prefab, bikeOffset + offset, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        var bikeOffset = new Vector3(0, 0, bike != null ? bike.position.z : 0);
        Gizmos.DrawWireSphere(bikeOffset + offset, .2f);
        Gizmos.DrawLine(transform.position, bikeOffset + offset);
    }
}
