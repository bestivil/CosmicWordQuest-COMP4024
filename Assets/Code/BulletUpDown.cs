using UnityEngine;
using System.Collections;

public class MoveUpwards : MonoBehaviour
{
    public float distance = 50f; // Distance to move upwards
    public float duration = 5f; // Duration of the movement


    // On space key press, move the object upwards
    void Update()
    {
    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(MoveUp(duration));
        }
    }

    // Coroutine to move the bullet upwards
    IEnumerator MoveUp(float time)
    {
        float elapsedTime = 0;
        Vector3 startingPosition = transform.position;
        Vector3 targetPosition = startingPosition + Vector3.up * distance;

        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(startingPosition, targetPosition, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

   
        transform.position = targetPosition;
    }
}
