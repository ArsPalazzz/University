using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public GameObject cubePrefab; // Префаб куба
    public GameObject cubePrefabSphere;
    public float spawnHeight = 10f; // Высота, с которой куб появляется над плоскостью

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Создаем новый объект-куб из префаба
            GameObject newCube = Instantiate(cubePrefab, new Vector3(0, spawnHeight, 0), Quaternion.identity);
            
            // Добавляем компонент Rigidbody к новому объекту
            Rigidbody cubeRigidbody = newCube.AddComponent<Rigidbody>();
            
            // Задаем начальную скорость падения куба вниз
            cubeRigidbody.velocity = Vector3.down * Mathf.Sqrt(2f * Mathf.Abs(Physics.gravity.y) * spawnHeight);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Создаем новый объект-куб из префаба
            GameObject newSphere = Instantiate(cubePrefabSphere, new Vector3(0, spawnHeight, 0), Quaternion.identity);
            
            // Добавляем компонент Rigidbody к новому объекту
            Rigidbody sphereRigidbody = newSphere.AddComponent<Rigidbody>();
            
            // Задаем начальную скорость падения куба вниз
            sphereRigidbody.velocity = Vector3.down * Mathf.Sqrt(2f * Mathf.Abs(Physics.gravity.y) * spawnHeight);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            // Поворачиваем плоскость вокруг оси Z
            transform.Rotate(Vector3.forward, 45f);
        }
    }
}
