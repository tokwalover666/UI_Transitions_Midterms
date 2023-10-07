using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class ButtonsManager : MonoBehaviour
{
    public Image imageToScale;
    private bool isZoomOut = false;
    private bool isFaded = false;
    private bool isSlided = false;

    private float fadeDuration = 1f;
    public float slideDownDuration = 1.0f;
    private float slideUpDuration = 1.0f;
    public float slideLeftDuration = 1.0f;
    public float flipDuration = 1.0f;



    private Vector3 originalPosition;

    private void Start()
    {
 
        imageToScale.canvasRenderer.SetAlpha(1.0f);
        originalPosition = imageToScale.rectTransform.localPosition;
    }

    public void Fade()
    {
        if (isFaded)
        {
            imageToScale.DOFade(1.0f, fadeDuration);
        }
        else
        {
     
            imageToScale.DOFade(0.0f, fadeDuration);
        }
        isFaded = !isFaded;
    }

    public void Zoom()
    {
        float zoomVal = 0;
        float targetScale = isZoomOut ? 1.0f : zoomVal;
        imageToScale.transform.DOScale(targetScale, 0.25f);
        isZoomOut = !isZoomOut;
    }


    public void SlideDown()
    {
            Vector3 targetPosition = imageToScale.rectTransform.localPosition - new Vector3(0, 100, 0);

            imageToScale.rectTransform.DOLocalMove(targetPosition, slideDownDuration);
        
    }

    public void SlideUp()
    {

            Vector3 targetPosition = imageToScale.rectTransform.localPosition - new Vector3(0, -100, 0);
   
            imageToScale.rectTransform.DOLocalMove(targetPosition, slideUpDuration);
        
    }

    public void SlideLeft()
    {
        if (isSlided)
        {
            Vector3 targetPosition = originalPosition - new Vector3(100, 0, 0);
            imageToScale.rectTransform.DOLocalMove(targetPosition, slideLeftDuration);
        }
        else
        {

            imageToScale.rectTransform.DOLocalMove(originalPosition, slideLeftDuration);
        }
        isSlided = !isSlided;
    }



    public void Flip()
    {
        imageToScale.rectTransform.DOScaleX(-imageToScale.rectTransform.localScale.x, flipDuration);
    }


}