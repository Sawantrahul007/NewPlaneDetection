using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSc : MonoBehaviour
{
    private Material mCube;
    private Material mPlane;
    public ARRaycastSc arRaySc;
    // Start is called before the first frame update
    void Start()
    {
        arRaySc = FindObjectOfType<ARRaycastSc>().GetComponent<ARRaycastSc>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        mCube = other.GetComponent<MeshRenderer>().material;
        mPlane = gameObject.GetComponent<MeshRenderer>().material;
        if (mCube.color == mPlane.color && other.CompareTag("player"))
        {
            //transform.position = other.gameObject.transform.position;
            //transform.rotation = other.gameObject.transform.rotation;
            //mPlane.color = Color.green;
            //ARRaycastSc.isAbletoInsta = false;
            //ARRaycastSc.isAbletoInsta = true;
            //arRaySc.player = null;
            //ARRaycastSc.isENable = true;
            //gameObject.GetComponent<CubeDetection>().enabled = false;

            //Destroy(arRaySc.playerP);
            //Destroy(arRaySc.player);
            //arRaySc.player = null;
            //arRaySc.tCount = 0;
            //StartCoroutine(EnableBug());
        }
    }
    IEnumerator EnableBug()
    {
        yield return new WaitForSeconds(1);
        //ARRaycastSc.isAbletoInsta = true;
        gameObject.GetComponent<PlaneSc>().enabled = false;
    }
}
