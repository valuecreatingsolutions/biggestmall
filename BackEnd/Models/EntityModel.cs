using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Runtime.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Models
{
    [Table("bm_company_profile")]
    public class CompanyProfile
    {
        [Key, Column(Order = 0)]
        [Display(Name = "ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string ComAutid { get; set; }

        [Display(Name = "Short Name")]
        [StringLength(10)]
        [Required(ErrorMessage = "{0} is required")]
        public string ComSname { get; set; }

        [Display(Name = "Full Name")]
        [StringLength(200)]
        [Required(ErrorMessage = "{0} is required")]
        public string ComFname { get; set; }

        [Display(Name = "Regn. No.")]
        [StringLength(10)]
        [Required(ErrorMessage = "{0} is required")]
        public string ComRegno { get; set; }

        [Display(Name = "Address 1")]
        [StringLength(200)]
        [Required(ErrorMessage = "{0} is required")]
        public string ComAddr1 { get; set; }

        [Display(Name = "Address 2")]
        [StringLength(200)]
        [Required(ErrorMessage = "{0} is required")]
        public string ComAddr2 { get; set; }

        [Display(Name = "City")]
        [StringLength(200)]
        [Required(ErrorMessage = "{0} is required")]
        public string ComScity { get; set; }

        [Display(Name = "State")]
        [StringLength(100)]
        [Required(ErrorMessage = "{0} is required")]
        public string ComState { get; set; }

        [Display(Name = "Country")]
        [StringLength(100)]
        [Required(ErrorMessage = "{0} is required")]
        public string ComCntry { get; set; }

        [Display(Name = "Telephone")]
        [StringLength(20)]
        [Required(ErrorMessage = "{0} is required")]
        public string ComTelno { get; set; }

        [Display(Name = "Fax")]
        [StringLength(20)]
        [Required(ErrorMessage = "{0} is required")]
        public string ComFaxno { get; set; }

        [Display(Name = "Email")]
        [StringLength(200)]
        [Required(ErrorMessage = "{0} is required")]
        public string ComEmail { get; set; }

        [Display(Name = "Website")]
        [StringLength(200)]
        [Required(ErrorMessage = "{0} is required")]
        public string ComWebst { get; set; }

        [Display(Name = "Facebook")]
        [StringLength(200)]
        [Required(ErrorMessage = "{0} is required")]
        public string ComFbook { get; set; }

        [Display(Name = "Instagram")]
        [StringLength(200)]
        [Required(ErrorMessage = "{0} is required")]
        public string ComInsta { get; set; }

        [Display(Name = "User ID")]
        [StringLength(200)]
        [Required(ErrorMessage = "{0} is required")]
        public string ComUsrid { get; set; }

        public DateTime ComCdate { get; set; }
        public DateTime ComUdate { get; set; }

    }

    [Table("bm_country")]
    public class Country
    {
        [Key, Column(Order = 0)]
        [Display(Name = "ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string CntAutid { get; set; }

        [Display(Name = "Code")]
        [StringLength(3)]
        [Required(ErrorMessage = "{0} is required")]
        public string CntScode { get; set; }

        [Display(Name = "Name")]
        [StringLength(3)]
        [Required(ErrorMessage = "{0} is required")]
        public string CntSname { get; set; }

        [StringLength(150)]
        public string CntUsrid { get; set; }

        public DateTime CntCdate { get; set; }

        public DateTime CntUdate { get; set; }
    }

    [Table("bm_state")]
    public class State
    {
        [Key, Column(Order = 0)]
        [Display(Name = "ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string StaAutid { get; set; }

        [Display(Name = "Country")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string StaCntid { get; set; }

        [ForeignKey("StaCntid")]
        public Country Country { get; set; }

        [Display(Name = "Code")]
        [StringLength(3)]
        [Required(ErrorMessage = "{0} is required")]
        public string StaScode { get; set; }

        [Display(Name = "Name")]
        [StringLength(3)]
        [Required(ErrorMessage = "{0} is required")]
        public string StaSname { get; set; }

        [StringLength(150)]
        public string StaUsrid { get; set; }

        public DateTime StaCdate { get; set; }

        public DateTime StaUdate { get; set; }
    }

    [Table("bm_province")]
    public class Province
    {
        [Key, Column(Order = 0)]
        [Display(Name = "ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string PrnAutid { get; set; }

        [Display(Name = "Country")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string PrnCntid { get; set; }

        [ForeignKey("PrnCntid")]
        public Country Country { get; set; }

        [Display(Name = "Code")]
        [StringLength(3)]
        [Required(ErrorMessage = "{0} is required")]
        public string PrnScode { get; set; }

        [Display(Name = "Name")]
        [StringLength(3)]
        [Required(ErrorMessage = "{0} is required")]
        public string PrnSname { get; set; }

        [StringLength(150)]
        public string PrnUsrid { get; set; }

        public DateTime PrnCdate { get; set; }

        public DateTime PrnUdate { get; set; }
    }

    [Table("bm_district")]
    public class District
    {
        [Key, Column(Order = 0)]
        [Display(Name = "ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string DstAutid { get; set; }

        [Display(Name = "State")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string DstStaid { get; set; }

        [ForeignKey("DstStaid")]
        public State State { get; set; }

        [Display(Name = "Code")]
        [StringLength(3)]
        [Required(ErrorMessage = "{0} is required")]
        public string DstScode { get; set; }

        [Display(Name = "Name")]
        [StringLength(3)]
        [Required(ErrorMessage = "{0} is required")]
        public string DstSname { get; set; }

        [StringLength(150)]
        public string DstUsrid { get; set; }

        public DateTime DstCdate { get; set; }

        public DateTime DstUdate { get; set; }
    }

    [Table("bm_postcode")]
    public class Postcode
    {
        [Key, Column(Order = 0)]
        [Display(Name = "ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string PscAutid { get; set; }

        [Display(Name = "District")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string PscDstid { get; set; }

        [ForeignKey("PscDstid")]
        public District District { get; set; }

        [Display(Name = "Code")]
        [StringLength(10)]
        [Required(ErrorMessage = "{0} is required")]
        public string DstSname { get; set; }

        [StringLength(150)]
        public string DstUsrid { get; set; }

        public DateTime DstCdate { get; set; }

        public DateTime DstUdate { get; set; }
    }

    [Table("bm_region")]
    public class Region
    {
        [Key, Column(Order = 0)]
        [Display(Name = "ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string RegAutid { get; set; }

        [Display(Name = "State")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string RegStaid { get; set; }

        [ForeignKey("RegStaid")]
        public State State { get; set; }

        [Display(Name = "Code")]
        [StringLength(3)]
        [Required(ErrorMessage = "{0} is required")]
        public string RegScode { get; set; }

        [Display(Name = "Name")]
        [StringLength(3)]
        [Required(ErrorMessage = "{0} is required")]
        public string RegSname { get; set; }

        [StringLength(150)]
        public string RegUsrid { get; set; }

        public DateTime RegCdate { get; set; }

        public DateTime RegUdate { get; set; }
    }

    [Table("bm_shipping_provider")]
    public class ShippingProvider
    {
        [Key, Column(Order = 0)]
        [Display(Name = "ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string ShpAutid { get; set; }

        [Display(Name = "Shipper Description")]
        [StringLength(255)]
        [Required(ErrorMessage = "{0} is required")]
        public string ShpDescr { get; set; }

        [Display(Name = "API Link")]
        [StringLength(1000)]
        [Required(ErrorMessage = "{0} is required")]
        public string ShpAplnk { get; set; }

        [StringLength(150)]
        public string ShpUsrid { get; set; }

        public DateTime ShpCdate { get; set; }

        public DateTime ShpUdate { get; set; }

    }

    [Table("bm_free_shipping")]
    public class FreeShipping
    {
        [Key, Column(Order = 0)]
        [Display(Name = "ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string FshAutid { get; set; }

        [Display(Name = "Promotion Name")]
        [StringLength(255)]
        [Required(ErrorMessage = "{0} is required")]
        public string FshPname { get; set; }

        // Long Term, Specific Period
        [Display(Name = "Period")]
        [StringLength(100)]
        [Required(ErrorMessage = "{0} is required")]
        public string FshPerod { get; set; }

        // No Condition, Shop Item Quantity X or Above, Shop Order Amount From 
        [Display(Name = "Condition")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string FshCondn { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "{0} is required")]
        public int FshQntty { get; set; }

        [Display(Name = "Amount")]
        [Required(ErrorMessage = "{0} is required")]
        public int FshAmont { get; set; }

        // Full Shipping Fee Subsidy, Partial Shipping Fee Subsidy Per Order
        [Display(Name = "Promotion Subsidy by Seller")]
        [StringLength(10)]
        [Required(ErrorMessage = "{0} is required")]
        public string FshSbsdy { get; set; }

        // STANDARD, EXPRESS, Delivery by Seller, P2P
        [Display(Name = "Delivery Option")]
        [StringLength(50)]
        [Required(ErrorMessage = "{0} is required")]
        public string FshDoptn { get; set; }

        // All/ Specific
        [Display(Name = "Region")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string FshRegon { get; set; }

        [ForeignKey("FshRegon")]
        public Region Region { get; set; }

        [Display(Name = "Budget")]
        [Required(ErrorMessage = "{0} is required")]
        public decimal FshBdget { get; set; }

        // Entire Shop, Specific Products
        [Display(Name = "Apply To")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string FshApply { get; set; }

    }

    [Table("bm_bundle_promotion")]
    public class BundlePromotion
    {
        [Key, Column(Order = 0)]
        [Display(Name = "ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string BdpAutid { get; set; }

        // Quantity, Buy 1 Get 1 Free, Free Gift, Combo
        [Display(Name = "Promotion Type")]
        [StringLength(20)]
        [Required(ErrorMessage = "{0} is required")]
        public string BdpPromo { get; set; }

        [Display(Name = "Promotion Name")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string BdpPname { get; set; }

        [Display(Name = "Start")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime BdpSdate { get; set; }

        [Display(Name = "End")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime BdpEdate { get; set; }

        // Percentage, Money Value
        [Display(Name = "Promotion Condition")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string BdpPcond { get; set; }

    }

    [Table("bm_pc_percent")]
    public class PromoPercent
    {
        [Key, Column(Order = 0)]
        [Display(Name = "Promotion ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string BdpPrmid { get; set; }

        [ForeignKey("BdpPrmid")]
        public BundlePromotion BundlePromotion { get; set; }

        [Key, Column(Order = 1)]
        [Display(Name = "Buy Quantity")]
        [Required(ErrorMessage = "{0} is required")]
        public int BdpByqty { get; set; }

        [Display(Name = "Discount(%)")]
        [Required(ErrorMessage = "{0} is required")]
        public int BdpDspct { get; set; }

    }

    [Table("bm_pc_money")]
    public class PromoMoney
    {
        [Key, Column(Order = 0)]
        [Display(Name = "Promotion ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string PrmPrmid { get; set; }

        [ForeignKey("BdpPrmid")]
        public BundlePromotion BundlePromotion { get; set; }

        [Key, Column(Order = 1)]
        [Display(Name = "Buy Quantity")]
        [Required(ErrorMessage = "{0} is required")]
        public int PrmByqty { get; set; }

        [Display(Name = "Discount Amount")]
        [Required(ErrorMessage = "{0} is required")]
        public int PrmDsamt { get; set; }

    }

    [Table("bm_pc_product")]
    public class BundlePromoProduct
    {
        [Key, Column(Order = 0)]
        [Display(Name = "Promotion ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string BppPrmid { get; set; }

        [ForeignKey("BppPrmid")]
        public BundlePromotion BundlePromotion { get; set; }

        [Key, Column(Order = 1)]
        [Display(Name = "Product ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string BppPrdid { get; set; }

        [ForeignKey("BppPrdid")]
        public Product Product { get; set; }

    }

    [Table("bm_pc_product_fg")]
    public class BundlePromoProductFreeGift
    {
        [Key, Column(Order = 0)]
        [Display(Name = "Promotion ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string BpfPrmid { get; set; }

        [ForeignKey("BpfPrmid")]
        public BundlePromotion BundlePromotion { get; set; }

        [Key, Column(Order = 1)]
        [Display(Name = "Product ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string BpfPrdid { get; set; }

        [ForeignKey("BpfPrdid")]
        public Product Product { get; set; }

    }

    [Table("bm_pc_product_combo")]
    public class BundlePromoProductCombo
    {
        [Key, Column(Order = 0)]
        [Display(Name = "Promotion ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string BpcPrmid { get; set; }

        [ForeignKey("BpcPrmid")]
        public BundlePromotion BundlePromotion { get; set; }

        [Key, Column(Order = 1)]
        [Display(Name = "Product ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string BpcPrdid { get; set; }

        [ForeignKey("BpcPrdid")]
        public Product Product { get; set; }

    }

    // Instruction
    // Max. Image size - 3MB
    // Dimensions 1X1 - 5000x5000
    // Supported formats - .JPG, .JPEG, .PNG
    
    [Table("bm_media_center")]
    public class MediaCenter
    {

        [Key, Column(Order = 0)]
        [Display(Name = "ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string MdcAutid { get; set; }

        [Display(Name = "File Name")]
        [StringLength(500)]
        [Required(ErrorMessage = "{0} is required")]
        public string MdcFlnam{ get; set; }

    }

    // Wizard
    // Sponsored Products Campaign
    [Table("bm_sp_campaign")]
    public class SponsoredProductCampaign
    {
        [Key, Column(Order = 0)]
        [Display(Name = "ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string SpcAutid { get; set; }

        [Display(Name = "Vendor")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string SpcVndid { get; set; }

        [ForeignKey("SpcVndid")]
        public Vendor Vendor { get; set; }

        [Display(Name = "Campaign Name")]
        [StringLength(200)]
        [Required(ErrorMessage = "{0} is required")]
        public string SpcCmpnm { get; set; }

        [Display(Name = "Daily Budget")]
        [Required(ErrorMessage = "{0} is required")]
        public decimal SpcBdget { get; set; }

        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime SpcSdate { get; set; }

        [Display(Name = "End Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime SpcEdate { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "{0} is required")]
        public bool SpcState { get; set; }
    }

    [Table("bm_spc_products")]
    public class SponsorProductCampaignProducts
    {
        [Key, Column(Order = 0)]
        [Display(Name = "Campaign ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string SppAutid { get; set; }

        [ForeignKey("SppSpcid")]
        public SponsoredProductCampaign SponsoredProductCampaign { get; set; }

        [Key, Column(Order = 1)]
        [Display(Name = "Product ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string SppPrdid { get; set; }

        [ForeignKey("SppPrdid")]
        public Product Product { get; set; }

        [Display(Name = "CPC")]
        [Required(ErrorMessage = "{0} is required")]
        public decimal SppCpcam { get; set; }

    }


    [Table("bm_campaign")]
    public class Campaign
    {
        [Key, Column(Order = 0)]
        [Display(Name = "ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string CmpAutid { get; set; }

        [Display(Name = "Campaign Banner")]
        [StringLength(1000)]
        [Required(ErrorMessage = "{0} is required")]
        public string CmpBfile { get; set; }

        [NotMapped]
        public IFormFile CmpBatch { get; set; }

        [Display(Name = "Campaign Name")]
        [StringLength(1000)]
        [Required(ErrorMessage = "{0} is required")]
        public string CmpDescr { get; set; }

        [Display(Name = "Registration Close In")]
        [Required(ErrorMessage = "{0} is required")]
        public string CmpRclos { get; set; }

        [Display(Name = "Campaign Start")]
        [Required(ErrorMessage = "{0} is required")]
        public string CmpSdate { get; set; }

        [Display(Name = "Campaign End")]
        [Required(ErrorMessage = "{0} is required")]
        public string CmpEdate { get; set; }

        [Display(Name = "Action")]
        [StringLength(20)]
        [Required(ErrorMessage = "{0} is required")]
        public string CmpActon { get; set; }

        // MID YEAR SALE/Flash Sale/ 
        [Display(Name = "Category")]
        [StringLength(100)]
        [Required(ErrorMessage = "{0} is required")]
        public string CmpCateg { get; set; }

    }


    [Table("bm_feed")]
    public class Feed
    {
        [Key, Column(Order = 0)]
        [Display(Name = "ID")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(128)]
        public string FedAutid { get; set; }

        [Display(Name = "Vendor ID")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(128)]
        public string FedVdnid { get; set; }

        [ForeignKey("FedVdnid")]
        public Vendor Vendor { get; set; }

        [Display(Name = "Feed Title")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(200)]
        public string FedTitle { get; set; }

        [Display(Name = "Feed Description")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(1000)]
        public string FedDescr { get; set; }

        [Display(Name = "ID")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(128)]
        public string FedStype { get; set; }

        [Display(Name = "Published Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime FedPdate { get; set; }

        [Display(Name = "Created Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime FedCdate { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(128)]
        public string FedState { get; set; }

        [Display(Name = "Action")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(128)]
        public string FedActon { get; set; }
    }

    [Table("bm_feed_files")]
    public class FeedMedia
    {
        [Key, Column(Order = 0)]
        [Display(Name = "ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string FmdAutid { get; set; }

        [Display(Name = "Feed ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string FmdFedid { get; set; }

        [ForeignKey("FmdFedid")]
        public Feed Feed { get; set; }

        [Display(Name = "Media File")]
        [StringLength(1000)]
        [Required(ErrorMessage = "{0} is required")]
        public string FedMfile { get; set; }

        // Dimension 1200 x 1200 (1:1) 1200:1600 (3:4) 1200:800 (3:2)
        [NotMapped]
        public IFormFile FedMatch { get; set; }

        [StringLength(150)]
        public string FedUsrid { get; set; }

        public DateTime FedCdate { get; set; }

        public DateTime FedUdate { get; set; }
    }

    [Table("bm_feed_product")]
    public class FeedProduct
    {

    }

    [Table("bm_lucky_draw")]
    public class LuckyDraw
    {

    }

    [Table("bm_advertisement")]
    public class Advertisement
    {

    }

    [Table("bm_product_return")]
    public class ProductReturn
    {

    }

    [Table("bm_product_refund")]
    public class ProductRefund
    {

    }

    [Table("bm_saved_pay_card")]
    public class PayCard
    {

    }

    [Table("bm_product_category")]
    public class ProductCategory
    {
        [Key, Column(Order = 0)]
        [Display(Name = "ID")]
        [StringLength(128)]
        public string PctAutid { get; set; }

        [Display(Name = "Category Name")]
        [StringLength(150)]
        [Required(ErrorMessage = "{0} is required")]
        public string PctCatnm { get; set; }

        [Display(Name = "Category Image")]
        [StringLength(150)]
        [Required(ErrorMessage = "{0} is required")]
        public string PctCtimg { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "{0} is required")]
        public IFormFile PctCtfle { get; set; }

        // Main Category if it Sub Category
        [Display(Name = "Cateogory")]
        public string PctCatid { get; set; }

        // Physical or Digital
        [Display(Name = "Type of Category")]
        public string PctCtype { get; set; }
        
        [StringLength(150)]
        public string PctUsrid { get; set; }

        public DateTime PctCdate { get; set; }

        public DateTime PctUdate { get; set; }
    }

    [Table("bm_product")]
    public class Product
    {
        [Key, Column(Order = 0)]
        [Display(Name = "ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string PrdAutid { get; set; }

        [Display(Name = "Product Name")]
        [StringLength(200)]
        [Required(ErrorMessage = "{0} is required")]
        public string PrdPname { get; set; }

        [Display(Name = "Video URL")]
        [StringLength(255)]
        [Required(ErrorMessage = "{0} is required")]
        public string PrdVdurl { get; set; }

        //Product Attributes
        [Display(Name = "Brand")]
        [StringLength(100)]
        [Required(ErrorMessage = "{0} is required")]
        public string PrdBrand { get; set; }

        // Mid-Back, High Back, Adjustable Back Height, Low Back
        [Display(Name = "Chair Back Height")]
        [StringLength(100)]
        [Required(ErrorMessage = "{0} is required")]
        public string PrdHeigh { get; set; }

        [Display(Name = "Style")]
        [StringLength(100)]
        [Required(ErrorMessage = "{0} is required")]
        public string PrdBrand { get; set; }

        [Display(Name = "Select Size")]
        [StringLength(20)]
        [Required(ErrorMessage = "{0} is required")]
        public string PrdPsize { get; set; }

        [Display(Name = "Total Products")]
        [Required(ErrorMessage = "{0} is required")]
        public int PrdTtqty { get; set; }

        [Display(Name = "Add Description")]
        [Required(ErrorMessage = "{0} is required")]
        public string PrdDescr { get; set; }

        [Display(Name = "Image 1")]
        [StringLength(1000)]
        [Required(ErrorMessage = "{0} is required")]
        public string PrdFsimg { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Image 1 File is required")]
        public IFormFile PrdFsfle { get; set; }

        [Display(Name = "Image 2")]
        [StringLength(1000)]
        public string PrdSdimg { get; set; }

        [NotMapped]
        public IFormFile PrdSdfle { get; set; }

        [Display(Name = "Image 3")]
        [StringLength(1000)]
        public string PrdTdimg { get; set; }

        [NotMapped]
        public IFormFile PrdTdfle { get; set; }

        [Display(Name = "Image 4")]
        [StringLength(1000)]
        public string PrdFhimg { get; set; }

        [NotMapped]
        public IFormFile PrdFhfle { get; set; }

        [Display(Name = "Image 5")]
        [StringLength(1000)]
        public string PrdFtimg { get; set; }

        [NotMapped]
        public IFormFile PrdFtfle { get; set; }

        [Display(Name = "Image 6")]
        [StringLength(1000)]
        public string PrdStimg { get; set; }

        [NotMapped]
        public IFormFile PrdStfle { get; set; }

        [Display(Name = "Flash Sales?")]
        public bool PrdFsale { get; set; }

        [Display(Name = "Category")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string PrdCatid { get; set; }

        [ForeignKey("PrdCatid")]
        public ProductCategory ProductCategory { get; set; }

        [StringLength(150)]
        public string PrdUsrid { get; set; }

        public DateTime PrdCdate { get; set; }

        public DateTime PrdUdate { get; set; }

    }

    [Table("bm_size_chart")]
    public class SizeChart
    {
        
    }

    [Table("bm_discount_coupon")]
    public class DiscountCoupon
    {
        [Key, Column(Order = 0)]
        [Display(Name = "ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string DcpAutid { get; set; }

        [Display(Name = "Coupon Title")]
        [StringLength(200)]
        [Required(ErrorMessage = "{0} is required")]
        public string DcpTitle { get; set; }

        [Display(Name = "Coupon Code")]
        [StringLength(20)]
        [Required(ErrorMessage = "{0} is required")]
        public string DcpCpncd { get; set; }

        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime DcpSdate { get; set; }

        [Display(Name = "End Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime DcpEdate { get; set; }

        [Display(Name = "Free Shipping")]
        public bool DcpFsflg { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "{0} is required")]
        public int DcpQntty { get; set; }

        // Percent/Fixed
        [Display(Name = "Discount Type")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(10)]
        public string DcpDstype { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "{0} is required")]
        public bool DcpStats { get; set; }

        [Display(Name = "Category")]
        public string DcpCatid { get; set; }

        [ForeignKey("DcpCatid")]
        public ProductCategory ProductCategory { get; set; }

        [Display(Name = "Minimum Spend")]
        public decimal DcpMnspd { get; set; }

        [Display(Name = "Maximum Spend")]
        public decimal DcpMxspd { get; set; }

        [Display(Name = "Per Limit")]
        [Required(ErrorMessage = "{0} is required")]
        public int DcpLimit { get; set; }

        [Display(Name = "Per Customer")]
        [Required(ErrorMessage = "{0} is required")]
        public int DcpCslmt { get; set; }

        [StringLength(150)]
        public string DcpUsrid { get; set; }

        public DateTime DcpCdate { get; set; }

        public DateTime DcpUdate { get; set; }
    }


    [Table("bm_vendor")]
    public class Vendor
    {
        [Key, Column(Order = 0)]
        [Display(Name = "ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string VenAutid { get; set; }

        [Display(Name = "First Name")]
        [StringLength(255)]
        [Required(ErrorMessage = "{0} is required")]
        public string VenFname { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(255)]
        [Required(ErrorMessage = "{0} is required")]
        public string VenLname { get; set; }

        [Display(Name = "Email")]
        [StringLength(255)]
        [Required(ErrorMessage = "{0} is required")]
        public string VenEmail { get; set; }
    }

    [Table("bm_vendor_account")]
    public class VendorAccount
    {
        [Display(Name = "Diplay Name/ Shop Name")]
        [StringLength(50)]
        public string VacSelid { get; set; }

        [Display(Name = "Diplay Name/ Shop Name")]
        [StringLength(50)]
        public string VacVndid { get; set; }

        [ForeignKey("VacVndid")]
        public Vendor Vendor { get; set; }

        [Display(Name = "Diplay Name/ Shop Name")]
        [StringLength(50)]
        public string VacPinch { get; set; }


        [Display(Name = "Diplay Name/ Shop Name")]
        [StringLength(50)]
        public string VacPhone { get; set; }

        [Display(Name = "Diplay Name/ Shop Name")]
        [StringLength(50)]
        public string VacShnam { get; set; }
    }
    
    [Table("bm_vendor_id_info")]
    public class VendorID
    {
        [Key, Column(Order = 0)]
        [Display(Name = "ID")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(128)]
        public string VidVndid { get; set; }

        [ForeignKey("VidVndid")]
        public Vendor Vendor { get; set; }

        [Display(Name = "ID Type")]
        [StringLength(100)]
        [Required(ErrorMessage = "{0} is required")]
        public string VidIdtyp { get; set; }

        [Display(Name = "IC No")]
        [StringLength(1000)]
        [Required(ErrorMessage = "{0} is required")]
        public string VidIncnm { get; set; }

        [Display(Name = "Address")]
        [StringLength(1000)]
        [Required(ErrorMessage = "{0} is required")]
        public string VidIdnum { get; set; }

        public string VidFfile { get; set; }

        public string VidBfile { get; set; }

        [NotMapped]
        public IFormFile VidFatch { get; set; }

        [NotMapped]
        public IFormFile VidBatch { get; set; }
    }

    [Table("bm_business_info")]
    public class BusinessInfo
    {
        [Display(Name = "Vendor")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string BsiVndid { get; set; }

        [ForeignKey("BsiVndid")]
        public Vendor Vendor { get; set; }

        [Display(Name = "Address")]
        [StringLength(1000)]
        [Required(ErrorMessage = "{0} is required")]
        public string BsiAddrs { get; set; }

        [Display(Name = "Country")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string BsiCntry { get; set; }

        [ForeignKey("BsiCntry")]
        public Country Country { get; set; }

        [Display(Name = "Person In Charge")]
        [StringLength(200)]
        [Required(ErrorMessage = "{0} is required")]
        public string BsiPinch { get; set; }

        [Display(Name = "Registration No")]
        [StringLength(100)]
        [Required(ErrorMessage = "{0} is required")]
        public string BsiRegno { get; set; }

        [Display(Name = "Registration File")]
        [StringLength(1000)]
        [Required(ErrorMessage = "{0} is required")]
        public string BsiRfile { get; set; }

        [NotMapped]
        public IFormFile BsiRatch { get; set; }

        [Display(Name = "ID No")]
        [StringLength(100)]
        [Required(ErrorMessage = "{0} is required")]
        public string Bsidnno { get; set; }

        [Display(Name = "Province")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string BsiPrvnc { get; set; }

        [ForeignKey("BsiPrvnc")]
        public Province Province { get; set; }

        [Display(Name = "District")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string BsiDistr { get; set; }

        [ForeignKey("BsiDistr")]
        public District District { get; set; }

        //Poscode Auto in dropdown
        [Display(Name = "Postal Code")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string BsiPcode { get; set; }

        [ForeignKey("BsiPcode")]
        public Postcode Postcode { get; set; }

        [Display(Name = "Region")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string BsiRegio { get; set; }

        [ForeignKey("BsiRegio")]
        public Region Region { get; set; }

        [Display(Name = "ID ")]
        [StringLength(1000)]
        [Required(ErrorMessage = "{0} is required")]
        public string BsiIfile { get; set; }

        [NotMapped]
        public IFormFile BsiIatch { get; set; }

        // Personal ID
        [Display(Name = "ID Type")]
        [StringLength(50)]
        [Required(ErrorMessage = "{0} is required")]
        public string BsiIdtyp { get; set; }
    }

    [Table("bm_vendor_bank")]
    public class VendorBank
    {
        [Key, Column(Order = 0)]
        [Display(Name = "ID")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(128)]
        public string VbnVndid { get; set; }

        [ForeignKey("VbnVndid")]
        public Vendor Vendor { get; set; }

        [Display(Name = "Account Name")]
        [StringLength(150)]
        [Required(ErrorMessage = "{0} is required")]
        public string VbnAccnm { get; set; }

        [Display(Name = "Account No")]
        [StringLength(100)]
        [Required(ErrorMessage = "{0} is required")]
        public string VbnAccno { get; set; }

        [Display(Name = "Bank Name")]
        [StringLength(150)]
        [Required(ErrorMessage = "{0} is required")]
        public string VbnBnknm { get; set; }

        [Display(Name = "Bank Code")]
        [StringLength(150)]
        [Required(ErrorMessage = "{0} is required")]
        public string VbnBncdd { get; set; }

        [Display(Name = "SWIFT")]
        [StringLength(150)]
        [Required(ErrorMessage = "{0} is required")]
        public string VbnSwift { get; set; }

        [Display(Name = "Bank Information Document")]
        [StringLength(1000)]
        [Required(ErrorMessage = "{0} is required")]
        public string VbnBfile { get; set; }

        [Display(Name = "Tax Registration Document")]
        [StringLength(150)]
        [Required(ErrorMessage = "{0} is required")]
        public string VbnRfile { get; set; }

        [NotMapped]
        public IFormFile VbnBatch { get; set; }

        [NotMapped]
        public IFormFile VbnRatch { get; set; }

        [StringLength(150)]
        public string VbnUsrid { get; set; }

        public DateTime VbnCdate { get; set; }

        public DateTime VbnUdate { get; set; }
    }

    [Table("bm_seller_voucher")]
    public class SellerVoucher
    {
        [Key, Column(Order = 0)]
        [Display(Name = "ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string SvuAutid { get; set; }

        // Collectable
        [Display(Name = "Voucher Type")]
        [StringLength(10)]
        [Required(ErrorMessage = "{0} is required")]
        public string SvuVtype { get; set; }

        [Display(Name = "Voucher Name")]
        [StringLength(100)]
        [Required(ErrorMessage = "{0} is required")]
        public string SvuVounm { get; set; }

        [Display(Name = "Voucher Redeem Start Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime SvuSdate { get; set; }

        [Display(Name = "Voucher Redeem End Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime SvuEdate { get; set; }

        [Display(Name = "Collect Start Date Time")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime SvuSdttm { get; set; }

        [Display(Name = "Total Vouchers to be issued")]
        [Required(ErrorMessage = "{0} is required")]
        public int SvuNoiss { get; set; }

        [Display(Name = "Voucher Limit per Customer")]
        [Required(ErrorMessage = "{0} is required")]
        public int SvuLimit { get; set; }

        // Regular Channel, Store Follower, Offline, Live Stream
        [Display(Name = "Display Area")]
        [Required(ErrorMessage = "{0} is required")]
        public int SvuDarea { get; set; }

        // Money Value Off, Percentage Discount Off
        [Display(Name = "Discount Type")]
        [Required(ErrorMessage = "{0} is required")]
        public int SvuDtype { get; set; }

        // Entire Shop, Specific Products
        [Display(Name = "Discount Apply To")]
        [Required(ErrorMessage = "{0} is required")]
        public int SvuApply { get; set; }

        [StringLength(150)]
        public string SvuUsrid { get; set; }

        public DateTime SvuCdate { get; set; }

        public DateTime SvuUdate { get; set; }

    }

    [Table("bm_voucher_discount_detail")]
    public class VoucherDiscountDetail
    {
        [Key, Column(Order = 0)]
        [Display(Name = "Voucher ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public int VddVouid { get; set; }

        [ForeignKey("VddVouid")]
        public SellerVoucher SellerVoucher { get; set; }

        [Key, Column(Order = 1)]
        [Display(Name = "Order Value")]
        [Required(ErrorMessage = "{0} is required")]
        public decimal VddOrdvl { get; set; }

        [Display(Name = "Discount")]
        [Required(ErrorMessage = "{0} is required")]
        public decimal VddDscnt { get; set; }

    }

    [Table("bm_voucher_products")]
    public class VoucherProducts
    {
        [Key, Column(Order = 0)]
        [Display(Name = "Voucher ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public int VprVouid { get; set; }

        [ForeignKey("VprVouid")]
        public SellerVoucher SellerVoucher { get; set; }

        [Key, Column(Order = 1)]
        [Display(Name = "Product")]
        [Required(ErrorMessage = "{0} is required")]
        public decimal VprPrdid { get; set; }

        [ForeignKey("VprPrdid")]
        public Product Product { get; set; }

    }

    [Table("bm_vendor_invoice_setting")]
    public class VendorInvoiceSetting
    {
        public string VisVndid { get; set; }

        [ForeignKey("VisVndid")]
        public Vendor Vendor { get; set; }

        // Provide Number Manually, Use Autoincrement Number, User Order Number
        public string VisOpton { get; set; }

        public string VisPrfix { get; set; }

        public string VisNxnum { get; set; }
    }

    [Table("bm_vendor_warehouse")]
    public class VendorWarehouse
    {
        public string VwhAutid { get; set; }
        
        public string VwhWname { get; set; }

        public string VwhWcode { get; set; }

        [StringLength(200)]
        public string VwhFlnam { get; set; }

        public string VwhPhone { get; set; }

        public string VwhEmail { get; set; }

        public string VwhCntry { get; set; }

        public string VwhRegon { get; set; }

        public string VwhPrvnc { get; set; }

        public string VwhDistr { get; set; }

        public string VwhPcode { get; set; }

        public string VwhAddre { get; set; }
        
        public string VwhVndid { get; set; }

        [ForeignKey("VwhVndid")]
        public Vendor Vendor { get; set; }



        
       
    }
    
    [Table("bm_holiday_mode")]
    public class VendorHolidayMode
    {

    }

    [Table("bm_vendor_penalty")]
    public class VendorPenalty
    {

    }

    [Table("bm_currency")]
    public class Currency
    {
        [Key, Column(Order = 0)]
        [Display(Name = "ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is requqired")]
        public string CurAutid { get; set; }

        [Display(Name = "Currency Title")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is requqired")]
        public string CurTitle { get; set; }

        [Display(Name = "Currency Code")]
        [StringLength(5)]
        [Required(ErrorMessage = "{0} is requqired")]
        public string CurScode { get; set; }

        [Display(Name = "Exchange Rate")]
        [Required(ErrorMessage = "{0} is requqired")]
        public decimal CurExgrt { get; set; }

        [StringLength(150)]
        public string CurUsrid { get; set; }

        public DateTime CurCdate { get; set; }

        public DateTime CurUdate { get; set; }

    }

    public class UserProfile
    {
        [Key, Column(Order = 0)]
        [Display(Name = "ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string UsrAutid { get; set; }

        [Display(Name = "First Name")]
        [StringLength(200)]
        [Required(ErrorMessage = "{0} is required")]
        public string UsrFname { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(200)]
        [Required(ErrorMessage = "{0} is required")]
        public string UsrLname { get; set; }

        [Display(Name = "Email")]
        [StringLength(200)]
        [Required(ErrorMessage = "{0} is required")]
        public string UsrEmail { get; set; }

        [Display(Name = "Gender")]
        [StringLength(10)]
        [Required(ErrorMessage = "{0} is required")]
        public string UsrGendr { get; set; }

        [Display(Name = "Mobile Number")]
        [StringLength(20)]
        [Required(ErrorMessage = "{0} is required")]
        public string UsrMobil { get; set; }

        [Display(Name = "DOB")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime UsrBdate { get; set; }

        [Display(Name = "Location")]
        [StringLength(200)]
        [Required(ErrorMessage = "{0} is required")]
        public string UsrLoctn { get; set; }

        // Allow Deskop Notifications, Enable Notifications, Get Notifications on my own activity, DND
        [Display(Name = "Notifications")]
        [StringLength(200)]
        [Required(ErrorMessage = "{0} is required")]
        public string UsrNflag { get; set; }

        [Display(Name = "Facebook")]
        [StringLength(1000)]
        [Required(ErrorMessage = "{0} is required")]
        public string UsrFlink { get; set; }

        [Display(Name = "Twitter")]
        [StringLength(1000)]
        [Required(ErrorMessage = "{0} is required")]
        public string UsrTlink { get; set; }

        [Display(Name = "Instagram")]
        [StringLength(1000)]
        [Required(ErrorMessage = "{0} is required")]
        public string UsrIlink { get; set; }

        // Deactivate Account Reason : I have privacy concern, This is temporary, Other
        [Display(Name = "Reason To Deactivate")]
        [StringLength(200)]
        [Required(ErrorMessage = "{0} is required")]
        public string UsrDresn { get; set; }

        [Display(Name = "Deactivation")]
        public bool UsrDflag { get; set; }

        // Delete Account Reason : No longer usable, Want to switch on other account, Other
        [Display(Name = "Reason To Delel")]
        [StringLength(200)]
        [Required(ErrorMessage = "{0} is required")]
        public string UsrRresn { get; set; }

        [StringLength(150)]
        public string UsrUsrid { get; set; }

        public DateTime UsrCdate { get; set; }

        public DateTime UsrUdate { get; set; }

    }


    [Table("bm_payment_method")]
    public class PaymentMethod
    {
        [Key, Column(Order = 0)]
        [Display(Name = "ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string PmhAutid { get; set; }

        [Display(Name = "Description")]
        [StringLength(50)]
        [Required(ErrorMessage = "{0} is required")]
        public string PmhTitle { get; set; }

        [StringLength(150)]
        public string PmhUsrid { get; set; }

        public DateTime PmhCdate { get; set; }

        public DateTime PmhUdate { get; set; }

    }

    [Table("bm_tax")]
    public class Tax
    {
        [Key, Column(Order = 0)]
        [Display(Name = "ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string TaxAutid { get; set; }

        [Display(Name = "Tax Detail")]
        [StringLength(20)]
        [Required(ErrorMessage = "{0} is required")]
        public string TaxDetal { get; set; }

        [Display(Name = "Tax Schedule")]
        [StringLength(100)]
        [Required(ErrorMessage = "{0} is required")]
        public string TaxSched { get; set; }

        [Display(Name = "Tax Rate(%)")]
        [Required(ErrorMessage = "{0} is required")]
        public string TaxTrate { get; set; }

        [StringLength(150)]
        public string TaxUsrid { get; set; }

        public DateTime TaxCdate { get; set; }

        public DateTime TaxUdate { get; set; }
    }

    [Table("bm_order")]
    public class Order
    {
        [Key, Column(Order = 0)]
        [Display(Name = "ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string OrdAutid { get; set; }

        [Display(Name = "Order No")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string OrdStrno { get; set; }

        [Display(Name = "Order Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime OrdTdate { get; set; }

        // Paid, Payment Failed, Awaiting Authentication
        [Display(Name = "Payment Status")]
        [StringLength(50)]
        [Required(ErrorMessage = "{0} is required")]
        public string OrdPstat { get; set; }

        [Display(Name = "Payment Method")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string OrdPmetd { get; set; }

        [ForeignKey("OrdPmetd")]
        public PaymentMethod PaymentMethod { get; set; }

        // Delivered, Shipped, Cancelled, Processing, Placed
        [Display(Name = "Order Status")]
        [StringLength(50)]
        [Required(ErrorMessage = "{0} is required")]
        public string OrdState { get; set; }

        [Display(Name = "Total")]
        [Required(ErrorMessage = "{0} is required")]
        public decimal OrdTotal { get; set; }

        [StringLength(150)]
        public string OrdUsrid { get; set; }

        public DateTime OrdCdate { get; set; }

        public DateTime OrdUdate { get; set; }
    }

    [Table("bm_order_detail")]
    public class OrderDetail
    {
        [Key, Column(Order = 0)]
        [Display(Name = "ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string OddOrdid { get; set; }

        [ForeignKey("OddOrdid")]
        public Order Order { get; set; }

        [Key, Column(Order = 1)]
        [Display(Name = "Product ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string OddPrdid { get; set; }

        [ForeignKey("OrdPrdid")]
        public Product Product { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "{0} is required")]
        public decimal OddPrice { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "{0} is required")]
        public int OddQntty { get; set; }

        [Display(Name = "Amount")]
        [Required(ErrorMessage = "{0} is required")]
        public decimal OddAmont { get; set; }

        [Display(Name = "Tax(%)")]
        [Required(ErrorMessage = "{0} is required")]
        public decimal OddTxprc { get; set; }

        [Display(Name = "Tax Amount")]
        [Required(ErrorMessage = "{0} is required")]
        public decimal OddTxamt { get; set; }

        [Display(Name = "Net Amount")]
        [Required(ErrorMessage = "{0} is required")]
        public decimal OddNtamt { get; set; }

        [StringLength(150)]
        public string OddUsrid { get; set; }

        public DateTime OddCdate { get; set; }

        public DateTime OddUdate { get; set; }
    }

    [Table("bm_invoice")]
    public class Invoice
    {
        [Key, Column(Order = 0)]
        [Display(Name = "ID")]
        [StringLength(128)]
        [Required(ErrorMessage = "{0} is required")]
        public string InvAutid { get; set; }

        [Display(Name = "Invoice No")]
        [StringLength(20)]
        [Required(ErrorMessage = "{0} is required")]
        public string InvStrno { get; set; }

        [Display(Name = "Invoice Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime InvTdate { get; set; }

        [Display(Name = "Shipping Fee")]
        [Required(ErrorMessage = "{0} is required")]
        public decimal InvShfee { get; set; }

        [Display(Name = "Invoice Amount")]
        [Required(ErrorMessage = "{0} is required")]
        public decimal InvAmont { get; set; }

        [Display(Name = "Tax")]
        [Required(ErrorMessage = "{0} is required")]
        public decimal InvTxamt { get; set; }

        [Display(Name = "Total")]
        [Required(ErrorMessage = "{0} is required")]
        public decimal InvTotal { get; set; }

        [StringLength(150)]
        public string InvUsrid { get; set; }

        public DateTime InvCdate { get; set; }

        public DateTime InvUdate { get; set; }
    }
}
