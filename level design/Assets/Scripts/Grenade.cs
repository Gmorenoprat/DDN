using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject cursor;
    public LayerMask layer;
    public Transform shootPoint;
    public LineRenderer lineVisual;
    public int linesSegment = 10;

    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        lineVisual.positionCount = linesSegment;
    }

    // Update is called once per frame
    void Update()
    {
        LaunchProyectil();
    }
    void LaunchProyectil()
    {
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(camRay, out hit, 100f, layer))
        {
            cursor.SetActive(true);
            cursor.transform.position = hit.point + Vector3.up * 0.1f;

            Vector3 vo = CalculateVelocity(hit.point, shootPoint.position, 1f);

            Visualize(vo);

            //transform.rotation = Quaternion.LookRotation(vo);

            if (Input.GetKeyDown(KeyCode.G)) {

                Rigidbody obj = Instantiate(rb, shootPoint.position, Quaternion.identity);
                obj.velocity = vo;
            }
        }
    }

    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {

        Vector3 distance = target - origin;
        Vector3 distanceXz = distance;
        distanceXz.y = 0;


        float sY = distance.y;
        float sXz = distanceXz.magnitude;

        float Vxz = sXz * time;
        float Vy = (sY / time) + (0.5f * Mathf.Abs(Physics.gravity.y) * time);

        Vector3 result = distanceXz.normalized;
        result *= Vxz;
        result.y = Vy;
        
        return result;

    }


    void Visualize(Vector3 vo) 
    { 
        for(int i = 0; i<linesSegment; i++)
        {
            Vector3 pos = CalculatePositionIntTime(vo, i / (float)linesSegment);
            lineVisual.SetPosition(i, pos);
        }
    }
    Vector3 CalculatePositionIntTime(Vector3 vo, float time) {

        Vector3 Vxz = vo;
        vo.y = 0f;

        Vector3 result = shootPoint.position + vo * time;
        float sY = (-0.5f * Mathf.Abs(Physics.gravity.y) * (time * time)) + (vo.y * time) + shootPoint.position.y;

        result.y = sY;
        return result;
    }
}
