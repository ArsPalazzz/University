using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shotgun : MonoBehaviour
{
    public int maxAmmo = 4;
    private int currentAmmo;
    public float reloadTime = 0.75f;
    private bool isReloading = false;

    public Light areaLight;
    public AudioSource shotSound;
    public AudioSource bulletInsertSound;
    public AudioSource bulletFallSound;

    public ParticleSystem muzzleFlash;

    public GameObject bulletPrefab;
    public GameObject cartridgePrefab;
    public GameObject emptyCartridgePrefab;
    public Transform firePoint;

    private int numPellets;
    private float spreadAngle = 2.0f;
    private float bulletSpeed = 10.0f;

    public float shootForce;
    public float spread;

    public Animator shotgunAnimator;

    public Transform foregrip; // ������ �� ������ �����

    //public Transform player; // ������ �� ������ ������ ��� ��� �������

    private Coroutine reloadCoroutine;
    private GameObject LoadingPort;
    private GameObject EjectionPort;

    public Image crosshairUI;
    public TextMeshProUGUI cartridgesUI;

    void Start()
    {
        currentAmmo = maxAmmo;
        numPellets = GameManager.instance.numPellets;
        LoadingPort = GameObject.Find("Loading Port");
        EjectionPort = GameObject.Find("Ejection Port");

        UpdateAmmoText();
    }

    void Update()
    {
        if (GameManager.instance.isWeaponPicked)
        {
            crosshairUI.gameObject.SetActive(true);
            cartridgesUI.gameObject.SetActive(true);
        }

        if (isReloading || !GameManager.instance.isWeaponPicked)
            return;

        if (Input.GetButtonDown("Fire1") && currentAmmo > 0)
        {
            if (reloadCoroutine != null)
            {
                StopCoroutine(reloadCoroutine);
                isReloading = false;
            }
            StartCoroutine(ShootWithDelay());
        }

        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo)
        {
            reloadCoroutine = StartCoroutine(Reload());
        }
    }

    IEnumerator ShootWithDelay()
    {
        muzzleFlash.Play();
        areaLight.enabled = true;
        shotSound.Play();
        GameManager.instance.isShooted = true;

        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        shotgunAnimator.SetBool("afterShot", true);

        for (int i = 0; i < numPellets; i++)
        {
            // ���������� ��������� ����������� ��� ������ ����� � ������ ��������
            float spreadX = Random.Range(-spread, spread);
            float spreadY = Random.Range(-spread, spread);

            // ������� ���� � ������ �� ��������

            GameObject currentBullet = Instantiate(
                bulletPrefab,
                firePoint.position,
                Quaternion.identity
            );

            // ���������� ������������ ����� ����� � ��������, ������� �� ��������
            Collider shooterCollider = firePoint.root.GetComponent<Collider>();
            if (shooterCollider != null)
            {
                Physics.IgnoreCollision(currentBullet.GetComponent<Collider>(), shooterCollider);
            }

            // ��������� ����������� � ��������� ��������� �� X � Y
            Vector3 dirWithSpread =
                Quaternion.Euler(spreadX, spreadY, 0)
                * (targetPoint - firePoint.position).normalized;

            currentBullet.transform.forward = dirWithSpread.normalized;

            Bullet bulletScript = currentBullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.initialSpeed = shootForce; // ������������� ��������� �������� ����
            }

            yield return new WaitForSeconds(0.02f); // ��������� �������� ����� ��������� ������ ����
        }

        EjectCartridge();

        currentAmmo--;
        UpdateAmmoText();

        yield return new WaitForSeconds(0.24f); // Adjust the delay time as needed
        areaLight.enabled = false;
        shotgunAnimator.SetBool("afterShot", false);
    }

    void EjectCartridge()
    {
        // ������� ������ ������ � ������� ejectionPort � ��������� ��� ��������� ����
        GameObject emptyCartridge = Instantiate(
            emptyCartridgePrefab,
            EjectionPort.transform.position,
            EjectionPort.transform.rotation
        );

        Rigidbody rb = emptyCartridge.GetComponent<Rigidbody>();

        // ��������� ���� � ������� ������� ��� ��� ������
        Vector3 ejectionForce =
            (
                EjectionPort.transform.right
                + EjectionPort.transform.up
                + EjectionPort.transform.forward * 0.05f
            ) * 0.3f;
        rb.AddForce(ejectionForce, ForceMode.Impulse);
        bulletFallSound.Play();

        // ���������� ������ ������ ����� ��������� �����
        Destroy(emptyCartridge, 5.0f);
    }

    void UpdateAmmoText()
    {
        if (cartridgesUI != null)
        {
            cartridgesUI.text = $"���������� �������� � ������: {currentAmmo}";
        }
    }

    IEnumerator Reload()
    {
        areaLight.enabled = false;
        isReloading = true;
        Debug.Log("Reloading...");

        while (currentAmmo < maxAmmo)
        {
            yield return StartCoroutine(InsertCartridge());

            currentAmmo++;
            UpdateAmmoText();
        }

        isReloading = false;
        shotgunAnimator.SetBool("afterShot", true);
        Debug.Log("Full");
        new WaitForSeconds(0.24f);
        shotgunAnimator.SetBool("afterShot", false);
    }

    IEnumerator InsertCartridge()
    {
        // ������� ������ ��� ����������
        GameObject cartridge = Instantiate(
            cartridgePrefab,
            LoadingPort.transform.position + Vector3.down * 0.5f,
            Quaternion.identity
        );

        cartridge.transform.SetParent(LoadingPort.transform); // ������ ������ �������� �������� LoadingPort

        Vector3 startPos = cartridge.transform.localPosition;
        Vector3 endPos = Vector3.zero; // �������� ������� ������������ LoadingPort

        float elapsedTime = 0;
        float rotateStartTime = 0.6f * reloadTime; // 60% �� ������ ������� �����������
        float rotateEndTime = 0.85f * reloadTime; // 85% �� ������ ������� �����������

        while (elapsedTime < reloadTime)
        {
            // ���������� ������� ������� ������������ LoadingPort
            cartridge.transform.localPosition = Vector3.Lerp(
                startPos,
                endPos,
                elapsedTime / reloadTime
            );

            // ������� ������� �������
            if (elapsedTime >= rotateStartTime && elapsedTime <= rotateEndTime)
            {
                float t = (elapsedTime - rotateStartTime) / (rotateEndTime - rotateStartTime);
                float angle = Mathf.Lerp(0, 90, t);
                cartridge.transform.localRotation = Quaternion.Euler(angle, 0, 0);
            }
            else if (elapsedTime > rotateEndTime)
            {
                cartridge.transform.localRotation = Quaternion.Euler(90, 0, 0);
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        bulletInsertSound.Play();

        cartridge.transform.localPosition = endPos;
        Destroy(cartridge);
    }
}
