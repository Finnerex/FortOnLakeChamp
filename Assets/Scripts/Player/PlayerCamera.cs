using UnityEngine;

namespace Player
{
    public class PlayerCamera : MonoBehaviour
    {
        private const string xAxis = "Mouse X";
        private const string yAxis = "Mouse Y";

        private PlayerController _player;
        private Camera _camera;
    
        [SerializeField] private float sensitivity = 2;
        [SerializeField] private float zoomFOV = 30;
        [SerializeField] private float zoomTimeSeconds = 1;

        private float _defaultFOV;
        private float _currentZoomTimeSeconds;

        private float _lookTimeSeconds;
        private float _currentLookTimeSeconds;
        private Quaternion _lookRotation;
        private bool _looking;
    
        // Start is called before the first frame update
        void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            _player = GetComponentInParent<PlayerController>();
            _camera = GetComponent<Camera>();
        
            _defaultFOV = _camera.fieldOfView;
        }

        // Update is called once per frame
        void Update()
        {
        
            Transform cameraTransform = transform;
            Transform playerTransform = _player.transform;
        
            // grab the current rotation
            Vector3 cameraRotation = cameraTransform.rotation.eulerAngles;
            Vector3 playerRotation = playerTransform.rotation.eulerAngles;

            // Zooming in
            if (Input.GetMouseButton(1) && _currentZoomTimeSeconds < zoomTimeSeconds)
            {
                _currentZoomTimeSeconds += Time.deltaTime;
                _camera.fieldOfView = Mathf.Lerp(_defaultFOV, zoomFOV, _currentZoomTimeSeconds / zoomTimeSeconds);
            }
            else if (!Input.GetMouseButton(1) && _currentZoomTimeSeconds > 0)
            {
                _currentZoomTimeSeconds -= Time.deltaTime;
                // me when i repeat myself
                _camera.fieldOfView = Mathf.Lerp(_defaultFOV, zoomFOV, _currentZoomTimeSeconds / zoomTimeSeconds);
            }
        
        
            // Looking at something
            if (_looking && _currentLookTimeSeconds < _lookTimeSeconds)
            {
                _currentLookTimeSeconds += Time.deltaTime;
                cameraTransform.rotation = Quaternion.Slerp(cameraTransform.rotation, _lookRotation, _currentLookTimeSeconds / _lookTimeSeconds);
                return;
            }
        
            if (_looking && _currentLookTimeSeconds >= _lookTimeSeconds)
            {
                _currentLookTimeSeconds = 0;
                _looking = false;

                // this is dumb but im doing it anyway
                Vector3 cameraLocalRotation = cameraTransform.localRotation.eulerAngles;
                playerRotation.y = cameraRotation.y;
                cameraLocalRotation.y = 0;
            
                cameraTransform.localRotation = Quaternion.Euler(cameraLocalRotation);
                playerTransform.rotation = Quaternion.Euler(playerRotation);

                _player.MovementLocked = false;
                return;
            }
        
            // change it by mouse input
            cameraRotation.x -= Input.GetAxis(yAxis) * sensitivity;
            playerRotation.y += Input.GetAxis(xAxis) * sensitivity;
        
            cameraRotation.x = cameraRotation.x switch
            {
                < 80 => Mathf.Clamp(cameraRotation.x, -80, 80),
                > 180 => Mathf.Clamp(cameraRotation.x, 360 - 80, 360 + 80),
                _ => 80
            };

            // Save it back
            cameraTransform.rotation = Quaternion.Euler(cameraRotation);
            playerTransform.rotation = Quaternion.Euler(playerRotation);

        }

        public void LookAt(Vector3 position, float lookTimeSeconds)
        {
            _looking = true;
            _lookTimeSeconds = lookTimeSeconds;
            _currentLookTimeSeconds = 0;
            _player.MovementLocked = true;

            _lookRotation = Quaternion.LookRotation(position - transform.position);
        }
    }
}
