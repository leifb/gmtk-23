using UnityEngine;

public class CharacterAi : MonoBehaviour
{

    public Transform enemiesParent;
    private MovementTarget target;


    // Start is called before the first frame update
    void Start()
    {
        this.target = this.GetComponent<MovementTarget>();
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void Sleep(double duration)
    {
        //TODO freeze character movement
    }
}
