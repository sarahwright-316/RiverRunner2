using UnityEngine;

public class TubeControls : MonoBehaviour
{
    public Transform boat;
    public float followDistance = 2f;
    public float fixedY = 0.5f;
    public float xSpeed = 5f;

    public float swingAmp = 0.5f;
    public float swingFreq = 2f;
    public float inputSwingMultiplier = 1f;

    float _currentXVel;

    void LateUpdate()
    {
        // 1) Get the target “behind the boat” pos
        Vector3 target = boat.position - boat.forward * followDistance;

        // 2) Figure out how much extra swing to add
        float h = Input.GetAxis("Horizontal");        // –1 to +1
        // a) base sine wave
        float swing = Mathf.Sin(Time.time * swingFreq) * swingAmp;
        // b) optionally boost when you’re steering
        swing += Mathf.Sin(Time.time * swingFreq * 2f) 
                 * swingAmp * inputSwingMultiplier * Mathf.Abs(h);

        // 3) Smoothly chase the target X (+ swing offset)
        float desiredX = target.x + swing;
        float newX = Mathf.SmoothDamp(
            transform.position.x,
            desiredX,
            ref _currentXVel,
            1f / xSpeed
        );

        // 4) Apply the new position (X is smoothed + swung; Y & Z are fixed/snapped)
        transform.position = new Vector3(
            newX,
            fixedY,
            target.z
        );
    }
}
