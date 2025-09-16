using System.Collections;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public int days = 0;
    void Start()
    {
        StartCoroutine(passTime());
    }

    public IEnumerator passTime()
    {
        while (days < 3)
        {
            yield return new WaitForSeconds(3);
            Grow();
        }
    }
    public void Grow()
    {
        days++;
        if (days == 1)
        {
            Debug.Log("dia 1 plantado");
        }
        else if (days == 2)
        {
            Debug.Log("dia 2 creció");
        }
        else
        {
            Debug.Log("dia 3 listo para recoger");
        }
    }
}
