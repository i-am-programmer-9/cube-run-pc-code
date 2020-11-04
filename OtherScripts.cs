using UnityEngine;

public class OtherScripts : MonoBehaviour
{
    public AudioClip DownSound;
    public AudioClip JumpSound;
	bool isOnGround;
    bool isCrouched = false;
	private void OnTriggerStay(Collider other) {
		if(other.CompareTag("Ground"))
		{
			isOnGround = true;
		}
	}
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isOnGround == true)
        {
			OriginalCubeSize();
            transform.position += new Vector3(0f, 5f, 0f);
            AudioSource.PlayClipAtPoint(JumpSound, transform.position);
			isOnGround = false;
        }
        if (Input.GetButtonDown("Crouch"))
        {
            if(!isCrouched)
            {
                transform.localScale = new Vector3(1.5f, 0.57f, 1.5f);
                AudioSource.PlayClipAtPoint(DownSound, transform.position);
                isCrouched = true;
                Invoke("OriginalCubeSize", 1.2f);
            }
        }
    }
    private void OriginalCubeSize(){
        isCrouched = false;
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    } 
}
