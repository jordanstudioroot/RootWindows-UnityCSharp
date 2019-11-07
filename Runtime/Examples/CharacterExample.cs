using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterExample : 
    MonoBehaviour,
    IPointerEnterHandler, 
    IPointerExitHandler, 
    IPointerDownHandler 
{
    // FIELDS ~~~~~~~~~~ 

    // ~ Static

    // ~~ public

    // ~~ private

    // ~ Non-Static

    // ~~ public
    public float honesty;
    public float speed = 1;
    public float strength;
    public float wisdom;
    public Sprite portrait;
    public string characterName;
    public string description;

    // ~~ private
    private bool _sleeping;
    private AttributeData _data;
    private float _sleepTimer;
    private string _abilityBarID = null;
    private string _detailID = null;
    private string _tooltipID = null;
    private Vector3 _destination;
    private Guid _uniqueID;
    private GameObject _flashlight;

    // CONSTRUCTORS ~~~~~~~~~~

    // ~ Static

    // ~~ public

    // ~~ private

    // ~ Non-Static

    // ~~ public

    // ~~ private

    // DESTRUCTORS ~~~~~~~~~~

    // ~ Static

    // ~~ public

    // ~~ private

    // ~ Non-Static

    // ~~ public

    // ~~ private
    private void OnDestroy()
    {
        RootWindows.Deregister(UniqueSubjectID, AttributeData);
        RootWindows.Deregister(UniqueSubjectID, Flashlight);
        RootWindows.Deregister(UniqueSubjectID, OnMoveStart, Move);
        RootWindows.Deregister(UniqueSubjectID, OnShootStart, Shoot);
    }

    // DELEGATES ~~~~~~~~~~

    // ~ Static

    // ~~ public

    // ~~ private

    // ~ Non-Static

    // ~~ public

    // ~~ private

    // EVENTS ~~~~~~~~~~

    // ~ Static

    // ~~ public

    // ~~ private

    // ~ Non-Static

    // ~~ public

    // ~~ private

    // ENUMS

    // ~ Static

    // ~~ public

    // ~~ private

    // ~ Non-Static

    // ~~ public

    // ~~ private

    // INTERFACES ~~~~~~~~~~

    // ~ Static

    // ~~ public

    // ~~ private

    // ~ Non-Static

    // ~~ public

    // ~~ private

    // PROPERTIES ~~~~~~~~~~

    // ~ Static

    // ~~ public

    // ~~ private

    // ~ Non-Static

    // ~~ public
    public string SubjectName {
        get {
            return name;
        }
    }

    public IAttributeData AttributeData {
        get {
            return _data;
        }
    }

    public string UniqueSubjectID {
        get { 
            if (_uniqueID == Guid.Empty) {
                _uniqueID = Guid.NewGuid();
                return gameObject.name + " " + _uniqueID.ToString();
            }
            else {
                return gameObject.name + " " + _uniqueID.ToString();
            }
        }
    }

    public string Description {
        get {
            return description;
        }
    }

    public Sprite Portrait {
        get {
            return portrait;
        }
    }

    // ~~ private

    // INDEXERS ~~~~~~~~~~

    // ~ Static

    // ~~ public

    // ~~ private

    // ~ Non-Static

    // ~~ public

    // ~~ private

    // METHODS ~~~~~~~~~

    // ~ Static

    // ~~ public

    // ~~ private

    // ~ Non-Static

    // ~~ public
    public void OnPointerEnter(PointerEventData pData) {
        Debug.Log("Pointer enter " + name);
    }

    public void OnPointerExit(PointerEventData pData) {
        Debug.Log("Pointer exit " + name);
    }

    public void OnPointerDown(PointerEventData pData) {
        Debug.Log("Pointer down " + name);
        RootWindows.Subject(UniqueSubjectID).ShowDetail(CardinalDirections.West, ViewSizes.Small);
        RootWindows.Subject(UniqueSubjectID).ShowActionBar(CardinalDirections.South, ViewSizes.Medium);
    }

    // ~~ private
    private void Awake() {
        _data = new AttributeData();
        _data.SetAttribute("Strength", strength);
        _data.SetAttribute("Wisdom", wisdom);
        _data.SetAttribute("Speed", speed);
        _data.SetAttribute("Honestly", honesty);

        _destination = transform.position;

        _flashlight = new GameObject("Flashlight");
        _flashlight.transform.SetParent(this.transform, false);
        Light flashlightMono = _flashlight.AddComponent<Light>();
        flashlightMono.type = LightType.Spot;
        flashlightMono.transform.position = this.transform.position;
        flashlightMono.intensity = 2f;
        flashlightMono.spotAngle = 90f;
    }

    private void Start() {
        RootWindows.Register(UniqueSubjectID, AttributeData);
        RootWindows.Register(UniqueSubjectID, Flashlight);
        RootWindows.Register(UniqueSubjectID, OnMoveStart, Move);
        RootWindows.Register(UniqueSubjectID, OnShootStart, Shoot);

    }

    private void Update() {
        if (_destination != transform.position) {
            Travel(_destination);
        }
    }

    private void Flashlight() {
        if (_flashlight.activeSelf == true) {
            _flashlight.SetActive(false);
        }
        else {
            _flashlight.SetActive(true);
        }
    }

    private void OnMoveStart() {

    }

    private void OnShootStart() {

    }

    private void Move(Vector3 target) {
        Debug.Log("Move @ " + target);
        _destination = new Vector3(target.x, transform.position.y, target.z);
    }

    private void Shoot(GameObject[] targets) {
        transform.LookAt(targets[0].transform);
        Debug.Log("Attack @ " + targets[0].transform.position);
        GameObject projectile = GameObject.CreatePrimitive(PrimitiveType.Cube);
        projectile.transform.localScale = new Vector3(.3f, .3f, .3f);
        projectile.transform.position = Vector3.Lerp(transform.position, targets[0].transform.position, .1f);
        Rigidbody rb = projectile.AddComponent<Rigidbody>();
        rb.AddForce((targets[0].transform.position - transform.position) * 1000f, ForceMode.Force);
        projectile.GetComponent<Renderer>().material.color = Color.yellow;
    }

    private void Travel(Vector3 destination) {
        transform.LookAt(destination);
        transform.position = Vector3.Lerp(
                transform.position, 
                destination, 
                Time.deltaTime * speed
        );
    }

    // STRUCTS ~~~~~~~~~~

    // ~ Static

    // ~~ public

    // ~~ private

    // ~ Non-Static

    // ~~ public

    // ~~ private

    // CLASSES ~~~~~~~~~~

    // ~ Static

    // ~~ public

    // ~~ private

    // ~ Non-Static

    // ~~ public
    
    // ~~ private
}