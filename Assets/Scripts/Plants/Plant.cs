using System.Collections;
using UnityEngine;

public class Plant : MonoBehaviour, IInteractable
{
    public GameObject day1;
    public GameObject day2;
    public GameObject day3;
    public int days = 0;
    public float timeToGrow = 1;
    private Land parentLand;
    void Start()
    {
        day1.gameObject.SetActive(false);
        day2.gameObject.SetActive(false);
        day3.gameObject.SetActive(false);
        StartCoroutine(passTime());
        parentLand = GetComponentInParent<Land>();
    }

    public IEnumerator passTime()
    {
        while (days < 3)
        {
            yield return new WaitForSeconds(timeToGrow);
            Grow();
        }
    }
    public void Grow()
    {
        days++;
        if (days == 1)
        {
            day1.gameObject.SetActive(true);
        }
        else if (days == 2)
        {
            day2.gameObject.SetActive(true);
        }
        else
        {
            day3.gameObject.SetActive(true);
        }
    }

    public void Interact()
    {
        parentLand.ResetLand();
        Debug.Log("Jola");
        Destroy(gameObject);
    }
}
