﻿namespace Production.Class
{
    public class ItemBUS
    {
        public static ItemDAO ITA = new ItemDAO();

        public void Item_INSERT(string ItemCode,
            string ItemName,
            string FrgnName,
            string InvntryUom,
            string ItemCode4OA)
        {
            ITA.Item_INSERT(ItemCode,
            ItemName,
            FrgnName,
            InvntryUom,
            ItemCode4OA);
        }

        public void Item_DELETE(string ItemCode)
        {
            ITA.Item_DELETE(ItemCode);
        }
    }
}