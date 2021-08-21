using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCloth : MonoBehaviour
{

    public SpriteRenderer shirt;

    public SpriteRenderer cap;

    public SpriteRenderer shoe;

    public SpriteRenderer pan;

    private int lastShirt = -1;

    private DataItem tmpCloth;

    private void Update()
    {
        if (lastShirt != GameManager.dataSave.player.currentCloth)
        {
            Refresh();
            lastShirt = GameManager.dataSave.player.currentCloth;
        }
    }

    public void Refresh()
    {
        tmpCloth = GameManager.GetItem(GameManager.dataSave.player.currentCloth);

        if (tmpCloth != null && tmpCloth.tipe == DataEnum.ItemTipe.Cloth)
        {
            if (shirt && tmpCloth.shirt)
                shirt.sprite = tmpCloth.shirt;

            if (cap && tmpCloth.cap)
                cap.sprite = tmpCloth.cap;

            if (shoe && tmpCloth.shoe)
                shoe.sprite = tmpCloth.shoe;

            if (pan && tmpCloth.pan)
                pan.sprite = tmpCloth.pan;
        }
    }
}
