using UnityEngine;

public class RopeVisual : MonoBehaviour
{
    public Transform boat;
    public Transform tube;
    [Tooltip("Number of segments in the rope")]
    public int segmentCount = 20;
    [Tooltip("How much the rope sags at midpoint")]
    public float sagAmount = 1.5f;

    private LineRenderer lr;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = segmentCount;
    }

    void LateUpdate()
    {
        Vector3 A = boat.position;
        Vector3 B = tube.position + new Vector3(0, 0, 1);
        

        for (int i = 0; i < segmentCount; i++)
        {
            float t = i / (float)(segmentCount - 1);
            // base linear interp
            Vector3 point = Vector3.Lerp(A, B, t);
            // add sag: a simple parabola peaking at t = 0.5
            float parabola = 4f * (t - t * t);
            Vector3 sagOffset = Vector3.down * (parabola * sagAmount);
            lr.SetPosition(i, point + sagOffset);
        }
    }
}
