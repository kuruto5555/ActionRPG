using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpringArm : MonoBehaviour
{
    /// <summary> アームの長さ </summary>
    [field:SerializeField]
    [field:Tooltip("始点")]
    private Vector3 startPoint_ = Vector3.zero;
    
    [field:SerializeField]
    [field:Tooltip("アームの長さ")]
    private float length_ = 1.0f;

    [field:SerializeField]
    [field:Tooltip("持ち手")]
    private GameObject Hand_ = null;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
#if DEBUG
        if (Hand_ != null && transform.parent != null) {

            Vector3 from = transform.position;

            Vector3 to   = Hand_.transform.position;

            Gizmos.color = Color.green;
            Gizmos.DrawLine(from, to);
        }
#endif
    }
}
