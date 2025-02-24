using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int applySpeed = 30;
    private Rigidbody myRigid;
    private Animator anima;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
        anima = GetComponent<Animator>();
    }

    void Update()
    {
        Moving();
        Rotating();

    }

    private void Rotating()
    {
        //float _x = Input.GetAxisRaw("Horizontal");
        //float _y = Input.GetAxisRaw("Vertical");s
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            transform.rotation = Quaternion.Euler(0, -90, 0);
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            transform.rotation = Quaternion.Euler(0, 90, 0);
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    private void Moving()
    {
        float _x = Input.GetAxisRaw("Horizontal");
        float _y = Input.GetAxisRaw("Vertical");
         
        anima.SetBool("Fwd", false);
        anima.SetBool("Bwd", false);
        anima.SetBool("Left", false);
        anima.SetBool("Right", false);

        transform.position += new Vector3(_x * applySpeed * Time.deltaTime, 0, 0);
        transform.position += new Vector3(0, 0, _y * applySpeed * Time.deltaTime);

        if (_y > 0)
            anima.SetBool("Fwd", true);
        else if (_y < 0)
            anima.SetBool("Bwd", true);
        else if (_x < 0)
            anima.SetBool("Left", true);
        else if (_x > 0)
            anima.SetBool("Right", true);
        //else if (_x ==0 && _y == 0){
        //    anima.SetBool("Fwd", false);
        //    anima.SetBool("Bwd", false);
        //    anima.SetBool("Left", false);
        //    anima.SetBool("Right", false);
        //}
        

            //Vector3 _moveHorizontal = transform.right * _x;
            //Vector3 _moveVertical = transform.forward * _y;

            //Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * applySpeed;
            //myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);

        }
}
