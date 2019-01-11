using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns objects at spawnPoint location
/// </summary>
public class ObjectSpawner : MonoBehaviour {

    public Transform spawnPoint;    // Idealy pressented with something visible

    public InteractionSlider scaleSlider;

    public GameObject cubePrefab;
    public GameObject spherePrefab;
    public GameObject cylinderPrefab;

	public void SpawnObject(string objectName)
    {
        if (objectName.Equals("cube"))
        {
            GameObject o = Instantiate(cubePrefab, spawnPoint.position, spawnPoint.rotation);
            o.transform.localScale *= scaleSlider.HorizontalSliderValue;
        }
        if (objectName.Equals("sphere"))
        {
            GameObject o = Instantiate(spherePrefab, spawnPoint.position, spawnPoint.rotation);
            o.transform.localScale *= scaleSlider.HorizontalSliderValue;
        }
        if (objectName.Equals("cylinder"))
        {
            GameObject o = Instantiate(cylinderPrefab, spawnPoint.position, spawnPoint.rotation);
            o.transform.localScale = new Vector3(o.transform.localScale.x * scaleSlider.HorizontalSliderValue, o.transform.localScale.y, o.transform.localScale.z * scaleSlider.HorizontalSliderValue); 
        }
    }

    // Attach spawnPoint
    public void Attach(bool attach)
    {
        if (attach)
        {
            spawnPoint.SetParent(gameObject.transform);
            spawnPoint.localPosition = Vector3.zero;
        }
        else
        {
            spawnPoint.SetParent(null);
        }
    }
}
