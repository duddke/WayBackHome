using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class SnaptoGround : MonoBehaviour
{
    // Start is called before the first frame update
    [MenuItem("Custom/Snap To Ground %g")]
    public static void Ground()
    {
        float randomrange = Random.Range(0, 180);
        foreach (var transform in Selection.transforms)
        {
            RaycastHit hitinfo;
            var hits = Physics.RaycastAll(transform.position + Vector3.up, Vector3.down, 10f);
            foreach (var hit in hits)
            {
                if (hit.collider.gameObject == transform.gameObject)
                    continue;
                transform.position = hit.point;
                transform.up = hit.normal;
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, randomrange, transform.localEulerAngles.z);
                break;
            }
        }
    }
}
