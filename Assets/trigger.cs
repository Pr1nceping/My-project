using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    [SerializeField] private Transform position;
    [SerializeField] private GameObject player;
    public float transitionDuration = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(moveCharacter());
    }

    IEnumerator moveCharacter()
    {
        yield return new WaitForSeconds(1);
        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            // Interpolate the position using Lerp
            float t = elapsedTime / transitionDuration;
            player.transform.position = Vector3.Lerp(player.transform.position, position.position, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

}
