using UnityEngine;
using System.Collections;

/// <summary>
/// Class responsible for bullet movement
/// </summary>
public class MoveUpwards : MonoBehaviour
{
    public float distance = 50f; // Distance to move upwards
    public float duration = 5f; // Duration of the movement


    /// <summary>
    /// On space key press, move the object upwards
    /// </summary>
    void Update()
    {
    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(MoveUp(duration));
        }
    }

    /// <summary>
    /// Coroutine to move the bullet upwards
    /// </summary>
    /// <param name="time">duration of the bullet existance</param>
    /// <returns>returns an enumerator for coroutine</returns>
    IEnumerator MoveUp(float time)
    {
        float elapsedTime = 0;
        Vector3 startingPosition = transform.position;
        Vector3 targetPosition = startingPosition + Vector3.up * distance;

        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

   
        transform.position = targetPosition;
    }
}
