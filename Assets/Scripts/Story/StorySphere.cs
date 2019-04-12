using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SelectionBase]
public class StorySphere : MonoBehaviour
{
    [Header("StorySphere options")]
    [Space]
	[TextArea]
	public string TextForStorySphere;
    [Space]
	public KeyCode ActionKey = KeyCode.E;
    [Header("Hvis der er GameObjects der skal enables (f.eks. næste storysphere):")]
    public List<GameObject> GameObjectToEnableOnPressedActionKey = new List<GameObject>();
    [Header("Hvis der er GameObjects der skal disables:")]
    public List<GameObject> GameObjectToDisableOnPressedActionKey = new List<GameObject>();
	
    public bool EnabledOnStartup = false;

	private bool _playerIsInRange = false;

	private GameObject _player;
	private bool _hasBeenDisabled = false;

    [Header("Referencer til dette GameObjects Canvas og Text")]
    [SerializeField]
    private Canvas _canvas;
    [SerializeField]
	private Text _textChild;
    [SerializeField]
    private ParticleSystem _particleSystem;

	private void Awake()
	{
		
	}

	// Use this for initialization
	void Start () {
   
		_textChild.text = TextForStorySphere;
        _particleSystem.gameObject.SetActive(true);

		if (EnabledOnStartup == false)
		{
			gameObject.SetActive(false);
		}
		else
		{
			_canvas.gameObject.SetActive(true);
            _particleSystem.gameObject.SetActive(true);

        }
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		if (GameObjectToEnableOnPressedActionKey != null)
		{
			Gizmos.DrawLine(transform.position, GameObjectToEnableOnPressedActionKey[0].transform.position);
		}
	}

	// Update is called once per frame
	void Update () {

		if (_hasBeenDisabled == false)
		{
			if (_playerIsInRange)
			{
				_canvas.gameObject.SetActive(true);
				transform.LookAt(_player.transform);

				if (Input.GetKeyDown(ActionKey))
				{
					_hasBeenDisabled = true;
				}
			}
			else
			{
				_canvas.gameObject.SetActive(false);
			}
		}
		else if (_hasBeenDisabled)
		{
			if (GameObjectToEnableOnPressedActionKey != null)
			{

                    foreach(GameObject g in GameObjectToEnableOnPressedActionKey)
                    {
                    if (g != null)
                    {
                        g.SetActive(true);
                    }
                    }
                   
                

                foreach (GameObject g in GameObjectToDisableOnPressedActionKey)
                {
                    if (g != null)
                    {
                        g.SetActive(false);
                    }
                }


            }
            gameObject.SetActive(false);
		}

	


	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			_playerIsInRange = true;
			_player = other.gameObject;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			_playerIsInRange = false;
		}
	}
}
