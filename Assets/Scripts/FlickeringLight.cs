using UnityEngine;


public class FlickeringLight : MonoBehaviour
{

    private Light _light;
    private float _offSeconds = -1;
    [SerializeField] private float flickerChance = 0.0001f;
    [SerializeField] private float maxOffSeconds = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        _light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (_offSeconds > 0)
            _offSeconds -= Time.deltaTime;
        
        else if ((int)Random.Range(0, 1 / flickerChance) == 1)
        {
            _light.enabled = false;
            _offSeconds = Random.Range(0, maxOffSeconds);
        }
        
        if (_offSeconds <= 0 && !_light.enabled)
            _light.enabled = true;

    }
}
