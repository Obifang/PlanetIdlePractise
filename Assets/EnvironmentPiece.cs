using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentPiece : MonoBehaviour
{
    public int GoldIncrease = 0;
    public float WaitTimeForGold = 1f;

    private bool _placed = false;
    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.UpdateState(GameManager.GameStates.PlacingObject);
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_placed && Input.GetKeyDown(KeyCode.Mouse1)) {
            _placed = true;
            GameManager.Instance.UpdateState(GameManager.GameStates.Default);
            InvokeRepeating("TimerForGold", WaitTimeForGold, WaitTimeForGold);
            _audioSource.Play();
        }

        if (!_placed) {
            HandleObjectPlacement();
        }

    }

    public void HandleObjectPlacement()
    {
        var newPos = RaycastFromMouse();

        if (newPos != Vector3.zero) {
            transform.rotation = Quaternion.FromToRotation(transform.up, transform.position - GameManager.Instance.planet.transform.position) * transform.rotation;
            transform.position = newPos;
        }
    }

    public Vector3 RaycastFromMouse()
    {
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);

        return hit.point;
    }

    public void TimerForGold()
    {
        GameManager.Instance.UpdateGold(GoldIncrease);
    }
}
