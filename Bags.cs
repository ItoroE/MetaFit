using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BagController : MonoBehaviour
{
    
    public List<GameObject> bagPrefabs;
    public Transform leftHand;

    private GameObject currentBag;
    private int currentIndex = 0;

    private void Start()
    {
        if (leftHand == null)
        {
            Debug.LogError("? Left hand Transform not assigned.");
            return;
        }

        if (bagPrefabs.Count > 0)
            EquipBag(currentIndex);
    }

    public void SwitchToNextBag()
    {
        if (bagPrefabs.Count == 0) return;

        currentIndex = (currentIndex + 1) % bagPrefabs.Count;
        EquipBag(currentIndex);
    }

    private void EquipBag(int index)
    {
        if (currentBag != null)
            Destroy(currentBag);

        GameObject bag = Instantiate(bagPrefabs[index], leftHand);
        bag.transform.localPosition = Vector3.zero;
        bag.transform.localRotation = Quaternion.identity;

        currentBag = bag;

        Debug.Log($"?? Equipped bag: {currentBag.name}");
    }
}