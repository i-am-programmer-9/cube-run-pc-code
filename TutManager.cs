using UnityEngine;
using UnityEngine.SceneManagement;
public class TutManager : MonoBehaviour
{

    // Variables
    #region Variables
    public GameObject dieEffect;
    //Audios
    [Space]
    [Header("AudioClips")]
    public AudioClip RotateSound;
    public AudioClip LosingSound;
    // Position changing values
    [Space]
    [Header("PositionChangers")]
    public Vector3 movePos = new Vector3(0.85f, 0f, 0f);
    public Vector3 newPos = new Vector3(0f, 0f, 0.7f);
    public TutLosingAndWinning forDying;
    public static bool isPlayerDead;
    #endregion
    private void Start()
    {
        isPlayerDead = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Barrier")
        {
            isPlayerDead = true;
            AudioSource.PlayClipAtPoint(LosingSound, transform.position, 1f);
            dieEffect.SetActive(true);
            Invoke("DieTheCube", 1f);
        }
        if (other.tag == "LavaBarrier")
        {
            isPlayerDead = true;
            AudioSource.PlayClipAtPoint(LosingSound, transform.position, 1f);
            dieEffect.SetActive(true);
            Invoke("DieTheCube", 1f);
        }
        if (other.tag == "Finish")
        {
            forDying.win();
            PlayerPrefs.SetInt("tutCompleted", 1);
            PlayerPrefs.Save();
        }
    }
    private void DieTheCube()
    {
        forDying.DieThePlayer();
    }
    void Update()
    {
        if (PauseingTheGame.paused == false && !isPlayerDead)
        {
            transform.position += movePos;
            if (Input.GetButton("Left"))
            {
                transform.position += newPos;
            }
            if (Input.GetButton("Right"))
            {
                transform.position -= newPos;
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                RotateLeft();
                AudioSource.PlayClipAtPoint(RotateSound, transform.position, 1f);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                RotateRight();
                AudioSource.PlayClipAtPoint(RotateSound, transform.position, 1f);
            }
        }
    }
    public void RotateLeft()
    {
        transform.Rotate(0f, -90f, 0f);
        if (movePos.x != 0f)
        {
            movePos.x = 0f;
            movePos.z += 0.85f;
            newPos.z = 0f;
            newPos.x -= 0.7f;
        }
        else
        {
            movePos.z = 0f;
            movePos.x = 0.85f;
            newPos.x = 0f;
            newPos.z = 0.7f;
        }
    }
    public void RotateRight()
    {
        transform.Rotate(0f, 90f, 0f);
        if (movePos.x != 0f)
        {
            movePos.x = 0f;
            movePos.z -= 0.85f;
            newPos.z = 0f;
            newPos.x -= -0.7f;
        }
        else
        {
            movePos.z = 0f;
            movePos.x = 0.85f;
            newPos.x = 0f;
            newPos.z = 0.7f;
        }
    }
    

}
