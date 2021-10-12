using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public float particleLifeTime = 2f;

    private IEnumerator Wait(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        Destroy(this.gameObject);
    }

    private void Update()
    {
        StartCoroutine(Wait(particleLifeTime));
    }
}
