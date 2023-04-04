using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDetection : MonoBehaviour
{
    //private MeshRenderer meshR;
    private Material mCube;
    private Material mPlane;
    private ARRaycastSc arRaySc;
    public static bool isAbleToDestroy;
    private BoxCollider bX;
    private Rigidbody rB;
    public bool isCondition;
    
    private void Awake()
    {
        arRaySc = FindObjectOfType<ARRaycastSc>().GetComponent<ARRaycastSc>();
        bX = gameObject.GetComponent<BoxCollider>();
        rB = gameObject.GetComponent<Rigidbody>();
        isAbleToDestroy = false;
    }
    private void Start()
    {
        //isCondition = true;
    }
    private void Update()
    {
        if(!isCondition && ARRaycastSc.isAbletoInstal)
        {
            ARRaycastSc.isAbletoInstal = false;
            arRaySc.player = null;
            Destroy(gameObject);
        }
        //if (isAbleToDestroy == true)
        //{
        //    Destroy(gameObject);
        //}
        //if (Input.GetTouch(0).tapCount < 1)
        //{
        //    ARRaycastSc.isAbletoInsta = true;
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        isCondition = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isCondition = false;
    }
    private void OnTriggerStay(Collider other)
    {
        mCube = gameObject.GetComponent<MeshRenderer>().material;
        mPlane = other.GetComponent<MeshRenderer>().material;
        if (ARRaycastSc.isAbletoInstal && isCondition)
        {
            Debug.Log("ll");
            if (mCube.color != mPlane.color && other.CompareTag("red")/* && ARRaycastSc.isAbletoInstal*/)
            {
                Debug.Log("mm");
                ARRaycastSc.isAbletoInstal = false;
                //isCondition = false;
                arRaySc.audioClipp.Play();
                arRaySc.player = null;
                //rB.isKinematic = false;
                //rB.constraints = RigidbodyConstraints.FreezeAll;
                isCondition = false;
                Destroy(gameObject);
                Destroy(this);
                //bX.isTrigger = false;
                //ARRaycastSc.isDestroy = true;
                


            }
            if (mCube.color == mPlane.color && other.CompareTag("red") /*&& ARRaycastSc.isAbletoInstal*/)
            {
                Debug.Log("nn");
                ARRaycastSc.isAbletoInstal = false;
                transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y+0.15f, other.gameObject.transform.position.z);
                transform.rotation = other.gameObject.transform.rotation;
                //mPlane.color = Color.green;
                //ARRaycastSc.isAbletoInsta = false;
                //ARRaycastSc.isAbletoInsta = true;
                for (int i = 0; i < arRaySc.mcolor.Count; i++)
                {
                    if (mCube.color == arRaySc.mcolor[i].color)
                    {
                        arRaySc.mcolor.RemoveAt(i);
                    }
                }
                if (arRaySc.mcolor.Count == 0)
                {
                    arRaySc.gameOver.gameObject.SetActive(true);
                }
                arRaySc.player = null;
                ARRaycastSc.isENable = true;
                //ARRaycastSc.isDestroy = true;
                //rB.isKinematic = false;
                isCondition = false;
                rB.constraints = RigidbodyConstraints.FreezeAll;
                Destroy(this);
                gameObject.GetComponent<CubeDetection>().enabled = false;
                

                //Destroy(arRaySc.playerP);
                //Destroy(arRaySc.player);
                //arRaySc.player = null;
                //arRaySc.tCount = 0;

            }

            //ARRaycastSc.isAbletoInstal = false;
            //ARRaycastSc.isDestroy = true;
            //rB.isKinematic = false;
            //bX.isTrigger = false;
            //gameObject.GetComponent<CubeDetection>().enabled = false;
            //if (mPlane.color == Color.green)
            //{
            //    if (Input.GetTouch(0).tapCount == 0)
            //    {
            //        ARRaycastSc.isAbletoInsta = true;
            //        Destroy(gameObject);
            //    }
            //}
            //Destroy(gameObject);
        }



    }
    
    IEnumerator BugFix()
    {
        yield return new WaitForSeconds(1);
        
        
    }
}
