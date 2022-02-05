using UnityEngine;

public class MechanismScript : MonoBehaviour
{
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void ChangeAnimation()
    {
        _animator.SetFloat("NextAnimation", Random.Range(0, 3f));
    }
}