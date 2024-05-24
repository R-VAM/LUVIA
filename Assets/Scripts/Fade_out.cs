using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fade_out : MonoBehaviour
{
    public GameObject imageObject;
    public float delayTime = 3f; // 이미지가 활성화된 후 비활성화될 때까지의 대기 시간
    public float fadeDuration = 1f; // 이미지가 서서히 사라지는 데 걸리는 시간

    private Image imageComponent;

    void Start()
    {
        // 이미지 오브젝트에 Image 컴포넌트가 있는지 확인
        imageComponent = imageObject.GetComponent<Image>();
        if (imageComponent == null)
        {
            Debug.LogError("Image component not found on the imageObject.");
            return;
        }

        // 이미지가 활성화된 경우에만 지정된 시간 후에 비활성화하는 코루틴 시작
        if (imageObject.activeSelf)
        {
            StartCoroutine(DisableImageAfterDelay(delayTime));
        }
    }

    // 일정 시간이 지난 후에 이미지를 서서히 비활성화하는 코루틴
    IEnumerator DisableImageAfterDelay(float delay)
    {
        // delay 시간만큼 대기
        yield return new WaitForSeconds(delay);

        // 이미지 서서히 사라지게 하기
        yield return StartCoroutine(FadeOut(imageComponent, fadeDuration));

        // 이미지 비활성화
        imageObject.SetActive(false);
    }

    // 알파 값을 서서히 줄여서 이미지가 서서히 사라지게 하는 코루틴
    IEnumerator FadeOut(Image image, float duration)
    {
        Color startColor = image.color;
        float rate = 1.0f / duration;
        float progress = 0.0f;

        while (progress < 1.0f)
        {
            image.color = new Color(startColor.r, startColor.g, startColor.b, Mathf.Lerp(startColor.a, 0, progress));
            progress += rate * Time.deltaTime;
            yield return null;
        }

        image.color = new Color(startColor.r, startColor.g, startColor.b, 0);
    }
}
