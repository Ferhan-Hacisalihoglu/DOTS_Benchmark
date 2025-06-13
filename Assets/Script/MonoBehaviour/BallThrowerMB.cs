using System.Collections;
using UnityEngine;

public class BallThrowerMB : MonoBehaviour
{
    public GameObject[] prefabs;
    
    public float minThrowPeriod;
    public float maxThrowPeriod;
    
    public float minThrowSpeed;
    public float maxThrowSpeed;

    public int maxBalls;
    private int ballCount = 0;

    void Start()
    {
        StartCoroutine(ThrowBalls());
    }

    IEnumerator ThrowBalls()
    {
        while (maxBalls > ballCount)
        {
            GameObject newBall = Instantiate(prefabs[Random.Range(0, prefabs.Length)], transform.position, Quaternion.identity);
            newBall.transform.position = transform.position;
            newBall.GetComponent<Rigidbody>().AddForce(transform.forward * Random.Range(minThrowSpeed, maxThrowSpeed));
            
            yield return new WaitForSeconds(Random.Range(minThrowPeriod, maxThrowPeriod));
            
            ballCount++;
        }
    }
}
