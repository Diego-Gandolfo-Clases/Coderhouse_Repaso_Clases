using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject effectPrefab; // TODO: usar Object Pooling

    private void OnCollisionEnter(Collision collision)
    {
        Explote();
    }

    private void Explote()
    {
        GameObject clone = Instantiate(effectPrefab);
        clone.transform.position = transform.position;
        clone.transform.rotation = transform.rotation;
        Effect effect = clone.GetComponent<Effect>();
        effect.Initialize();
        gameObject.SetActive(false);
    }
}
