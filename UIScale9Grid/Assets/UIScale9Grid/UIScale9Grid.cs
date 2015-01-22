using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIScale9Grid : MonoBehaviour {

    public RectTransform top1;
    public RectTransform top2;
    public RectTransform top3;
    public RectTransform top4;
    public RectTransform top5;
    public RectTransform center1;
    public RectTransform center2;
    public RectTransform center3;
    public RectTransform bottom1;
    public RectTransform bottom2;
    public RectTransform bottom3;

    private RectTransform _bg;

    private Vector2 size;

    public void Awake()
    {
        if (size.x==0&&size.y==0)
        {
            size = new Vector2(bg.rect.width, bg.rect.height);
        }
    }

    public RectTransform bg
    {
        get
        {
            if (_bg == null)
            {
                _bg = this.transform.GetComponent<RectTransform>();
            }
            return _bg;
        }
    }

 

    public void OnDrawGizmos()
    {
        Awake();
        updateSize();
    }

    public void updateSize()
    {
        if (bg.rect.width != size.x || bg.rect.height != size.y)
        {
            size.x = (int)bg.rect.width;
            size.y = (int)bg.rect.height;
            updateUI();
        }
    }

    /// <summary>
    /// 设置窗口大小
    /// </summary>
    /// <param name="w"></param>
    /// <param name="h"></param>
    public void setWinSize(int w,int h)
    {
        if (size == null)
        {
            size = new Vector2(w, h);
        }else
        {
            size.x = w;
            size.y = h;
        }
        updateUI();
    }



    private void updateUI()
    {

        int centerHor = (int)(size.x - center1.rect.width - center3.rect.width);
        int centerVer = (int)(size.y - top1.rect.height - bottom1.rect.height);
        int bottomHor = (int)(size.x - bottom1.rect.width - bottom3.rect.width);

        float topY = -top1.rect.height;


        Debug.Log("size x y:" + size.x + ":" + size.y);

        
        if (top2 != null && top4 != null)
        {
            int topHor = (int)(size.x - top1.rect.width - top3.rect.width - top5.rect.width);

            int topLeftHor = (int)(topHor / 2.0f);
            int topRightHor = (int)(topHor / 2.0f);
            if (topHor % 2 > 0)
            {
                topRightHor += 1;
            }
            top1.anchoredPosition = new Vector2(0, topY);
            top2.anchoredPosition = new Vector2(top1.rect.width, topY);
            top2.sizeDelta = new Vector2(topLeftHor, top2.rect.height);

            top3.anchoredPosition = new Vector2(top2.anchoredPosition.x + top2.sizeDelta.x, topY);

            top4.anchoredPosition = new Vector2(top3.anchoredPosition.x + top3.rect.width, topY);
            top4.sizeDelta = new Vector2(topRightHor, top4.rect.height);

            top5.anchoredPosition = new Vector2(top4.anchoredPosition.x + top4.sizeDelta.x, topY);
        }else
        {
            int topHor = (int)(size.x - top1.rect.width - top5.rect.width);
            top1.anchoredPosition = new Vector2(0, topY);
            top3.sizeDelta = new Vector2(topHor, top3.rect.height);
            top3.anchoredPosition = new Vector2(top1.anchoredPosition.x + top1.sizeDelta.x, topY);

            top5.anchoredPosition = new Vector2(top3.anchoredPosition.x + top3.sizeDelta.x, topY);
        }

        

        int centerY = -(int)(top1.rect.height + centerVer);
        center1.sizeDelta = new Vector2(center1.rect.width, centerVer);
        center1.anchoredPosition = new Vector2(0, centerY);

        center2.sizeDelta = new Vector2(centerHor, centerVer);
        center2.anchoredPosition = new Vector2(center1.rect.width, centerY);
        
        center3.sizeDelta = new Vector2(center3.rect.width, centerVer);
        center3.anchoredPosition = new Vector2(center2.anchoredPosition.x + center2.sizeDelta.x, centerY);

        int bottomY =-(int)(size.y);

        bottom1.anchoredPosition = new Vector2(0, bottomY);

        bottom2.anchoredPosition = new Vector2(bottom1.rect.width, bottomY);
        bottom2.sizeDelta = new Vector2(bottomHor, bottom2.rect.height);

        bottom3.anchoredPosition = new Vector2(size.x - bottom3.rect.width, bottomY);
    }


    
}
