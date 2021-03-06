﻿using System;

namespace Production.Class
{
    public class KHMau_CTXN_LAB
    {
        public KHMau_CTXN_LAB()
        {
        }

        public int ID { get; set; }
        public int KHMau_ID { get; set; }
        public string KHMau { get; set; }
        public int CTXNID { get; set; }

        //int NCTXNID,
        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }
        public string Note { get; set; }
        public bool Locked { get; set; }
        public float DonGia { get; set; }
        public float DonGiaMuaNgoai { get; set; }
        public float ThanhTien
        {
            get { return DonGiaSauDiscount * float.Parse(SoLuongXN); }
            set { }
        }
        public bool KetQua { get; set; }
        public string SoLuongDat { get; set; }
        public string SoLuongXN { get; set; }
        public float VAT { get; set; }
        public float Discount { get; set; }
        public string LoaiDiscount { get; set; }
        public float DonGiaSauDiscount { get; set; }
        public int PriceList_Details_LAB_Id { get; set; }
        public DateTime NgayCoKetQua { get; set; }
        public bool DaTraKetQua { get; set; }
        public DateTime NgayTraKetQua { get; set; }
        public bool GoiYCXuatHD { get; set; }
        public DateTime NgayGoiYCXuatHD { get; set; }
        public bool Approved { set; get; }
        public string ApprovedBy { set; get; }
        public bool Confirmed { set; get; }
        public string ConfirmedBy { set; get; }
    }
}