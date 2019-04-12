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
	public GameObject GameObjectToEnableOnPressedActionKey;
	
    public bool EnabledOnStartup = false;

	private bool _playerIsInRange = false;
	private Canvas _canvas;
	private GameObject _player;
	private bool _hasBeenDisabled = false;
	private Text _textChild;

	private void Awake()
	{
		
	}

	// Use this for initialization
	void Start () {

		_canvas = GetComponentInChildren<Canvas>();
		_canvas.GetComponentInChildren<Image>().gameObject.SetActive(true);
		_canvas.GetComponentInChildren<Text>().gameObject.SetActive(true);
		_textChild = _canvas.GetComponentInChildren<Text>();
		_textChild.text = TextForStorySphere;

		if (EnabledOnStartup == false)
		{
			gameObject.SetActive(false);
		}
		else
		{
			_canvas.gameObject.SetActive(true);
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		if (GameObjectToEnableOnPressedActionKey != null)
		{
			Gizmos.DrawLine(transform.position, GameObjectToEnableOnPressedActionKey.transform.position);
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
				GameObjectToEnableOnPressedActionKey.SetActive(true);
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
