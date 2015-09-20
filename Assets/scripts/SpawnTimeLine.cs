using UnityEngine;
using System.Collections;

public class SpawnTimeLine : TimeLine
{

    public GameObject prefab;
    public Transform bike;
    public Vector3 offset;

    public override void Trigger()
    {
        Instantiate(prefab, (bike != null ? bike.position : Vector3.zero) + offset, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere((bike != null ? bike.position : Vector3.zero) + offset, 1);
        Gizmos.DrawLine(transform.position, (bike != null ? bike.position : Vector3.zero) + offset);
    }
}
