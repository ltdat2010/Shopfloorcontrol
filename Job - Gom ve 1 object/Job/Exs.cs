using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.ClsUser;
using DevExpress.ClsSQL;
using DevExpress.XtraGrid;


namespace DevExpress.ClsLam
{
        //public Lam Search(int Lamrecordno, string Process)
        //{
        //    DataTable dt = new DataTable();
        //    Lam Lam = new Lam();
        //    //dt.Reset();
        //    dt = Sql.ExecuteDataTable("SELECT [RecordNo],[JobOrder],[JobName],[NoLaminate],[UNW1],[UNW2],[UNW3],[UNW],[Date],[MCLeader],[Shift1],[Shift2],[Shift3],[Employee1],[Employee2],[Employee3],[Employee4],[Employee5],[DateInput],[UserName],[MachineNo],[JobStatus],[Note],[Active],[Running]," +
        //    "[SumUNW3Weight],[SumUNW3Lenght],[SumUNW3Width]," +
        //    "[SumUNW3WeightInput],[SumUNW3LenghtInput],[SumUNW3WidthInput]," +
        //    "[SumUNW3WeightRemaind],[SumUNW3LenghtRemaind],[SumUNW3WidthRemaind], " +
        //    "[SumUNW2Weight],[SumUNW2Lenght],[SumUNW2Width]," +
        //    "[SumUNW2WeightInput],[SumUNW2LenghtInput],[SumUNW2WidthInput]," +
        //    "[SumUNW2WeightRemaind],[SumUNW2LenghtRemaind],[SumUNW2WidthRemaind], " +
        //    "[SumUNW1Weight],[SumUNW1Lenght],[SumUNW1Width]," +
        //    "[SumUNW1WeightInput],[SumUNW1LenghtInput],[SumUNW1WidthInput]," +
        //    "[SumUNW1WeightRemaind],[SumUNW1LenghtRemaind],[SumUNW1WidthRemaind], " +
        //    "[SumREWWeight],[SumREWLenght],[SumREWWidth]," +
        //    "[Checked],[Reported],[CheckedBy],[ReportedBy],[CheckedDate],[ReportedDate],[SumWasteLenght],[SumWasteWeight],[SumWasteLenghtInput],[SumWasteWeightInput]" +
        //    "FROM [Pro_JobRecordHeader] where [RecordNo]=" + Lamrecordno + " and [Pro_JobRecordHeader].[Process] ='"+Process+"' ");
        //    //XtraMessageBox.Show("JobName : " + dt.Rows[0]["JobName"].ToString());
        //    Lam._LamRecordNo = int.Parse(dt.Rows[0]["RecordNo"].ToString());
        //    Lam._JobOrder = dt.Rows[0]["JobOrder"].ToString();
        //    Lam._JobName = dt.Rows[0]["JobName"].ToString();
        //    //XtraMessageBox.Show("JobName : " + Lam._JobName);
        //    Lam._NoLaminate = int.Parse(dt.Rows[0]["NoLaminate"].ToString());
        //    Lam._UNW1 = dt.Rows[0]["UNW1"].ToString();
        //    Lam._UNW2 = dt.Rows[0]["UNW2"].ToString();
        //    Lam._UNW3 = dt.Rows[0]["UNW3"].ToString();
        //    Lam._UNW = dt.Rows[0]["UNW"].ToString();
        //    Lam._Date = DateTime?.Parse(dt.Rows[0]["Date"].ToString());
        //    Lam._MCLeader = dt.Rows[0]["MCLeader"].ToString();
        //    Lam._Shift1 = dt.Rows[0]["Shift1"].ToString();
        //    Lam._Shift2 = dt.Rows[0]["Shift2"].ToString();
        //    Lam._Shift3 = dt.Rows[0]["Shift3"].ToString();
        //    Lam._Employee1 = dt.Rows[0]["Employee1"].ToString();
        //    Lam._Employee2 = dt.Rows[0]["Employee2"].ToString();
        //    Lam._Employee3 = dt.Rows[0]["Employee3"].ToString();
        //    Lam._Employee4 = dt.Rows[0]["Employee4"].ToString();
        //    Lam._Employee5 = dt.Rows[0]["Employee5"].ToString();
        //    Lam._DateInput = DateTime?.Parse(dt.Rows[0]["DateInput"].ToString());
        //    Lam._UserName = dt.Rows[0]["UserName"].ToString();
        //    Lam._MachineNo = dt.Rows[0]["MachineNo"].ToString();
        //    Lam._JobStatus = dt.Rows[0]["JobStatus"].ToString();
        //    Lam._Note = dt.Rows[0]["Note"].ToString();
        //    Lam._Active = int.Parse(dt.Rows[0]["Active"].ToString());
        //    Lam._Running = dt.Rows[0]["Running"].ToString();
        //    Lam._SumUNW3Weight = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumUNW3Weight"].ToString())?"0":dt.Rows[0]["SumUNW3Weight"].ToString());
        //    Lam._SumUNW3WeightRemaind = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumUNW3WeightRemaind"].ToString())?"0":dt.Rows[0]["SumUNW3WeightRemaind"].ToString());
        //    Lam._SumUNW3WeightInput = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumUNW3WeightInput"].ToString())?"0":dt.Rows[0]["SumUNW3WeightInput"].ToString());
        //    Lam._SumUNW3Lenght = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumUNW3Lenght"].ToString())?"0":dt.Rows[0]["SumUNW3Lenght"].ToString());
        //    Lam._SumUNW3LenghtRemaind = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumUNW3LenghtRemaind"].ToString())?"0":dt.Rows[0]["SumUNW3LenghtRemaind"].ToString());
        //    Lam._SumUNW3LenghtInput = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumUNW3LenghtInput"].ToString())?"0":dt.Rows[0]["SumUNW3LenghtInput"].ToString());
        //    Lam._SumUNW3Width = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumUNW3Width"].ToString())?"0":dt.Rows[0]["SumUNW3Width"].ToString());
        //    Lam._SumUNW3WidthRemaind = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumUNW3WidthRemaind"].ToString())?"0":dt.Rows[0]["SumUNW3WidthRemaind"].ToString());
        //    Lam._SumUNW3WidthInput = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumUNW3WidthInput"].ToString())?"0":dt.Rows[0]["SumUNW3WidthInput"].ToString());
        //    Lam._SumUNW2Weight = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumUNW2Weight"].ToString())?"0":dt.Rows[0]["SumUNW2Weight"].ToString());
        //    Lam._SumUNW2WeightRemaind = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumUNW2WeightRemaind"].ToString())?"0":dt.Rows[0]["SumUNW2WeightRemaind"].ToString());
        //    Lam._SumUNW2WeightInput = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumUNW2WeightInput"].ToString())?"0":dt.Rows[0]["SumUNW2WeightInput"].ToString());
        //    Lam._SumUNW2Lenght = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumUNW2Lenght"].ToString())?"0":dt.Rows[0]["SumUNW2Lenght"].ToString());
        //    Lam._SumUNW2LenghtRemaind = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumUNW2LenghtRemaind"].ToString())?"0":dt.Rows[0]["SumUNW2LenghtRemaind"].ToString());
        //    Lam._SumUNW2LenghtInput = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumUNW2LenghtInput"].ToString())?"0":dt.Rows[0]["SumUNW2LenghtInput"].ToString());
        //    Lam._SumUNW2Width = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumUNW2Width"].ToString())?"0":dt.Rows[0]["SumUNW2Width"].ToString());
        //    Lam._SumUNW2WidthRemaind = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumUNW2WidthRemaind"].ToString())?"0":dt.Rows[0]["SumUNW2WidthRemaind"].ToString());
        //    Lam._SumUNW2WidthInput = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumUNW2WidthInput"].ToString())?"0":dt.Rows[0]["SumUNW2WidthInput"].ToString());
        //    Lam._SumUNW1Weight = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumUNW1Weight"].ToString())?"0":dt.Rows[0]["SumUNW1Weight"].ToString());
        //    Lam._SumUNW1WeightRemaind = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumUNW1WeightRemaind"].ToString())?"0":dt.Rows[0]["SumUNW1WeightRemaind"].ToString());
        //    Lam._SumUNW1WeightInput = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumUNW1WeightInput"].ToString())?"0":dt.Rows[0]["SumUNW1WeightInput"].ToString());
        //    Lam._SumUNW1Lenght = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumUNW1Lenght"].ToString())?"0":dt.Rows[0]["SumUNW1Lenght"].ToString());
        //    Lam._SumUNW1LenghtRemaind = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumUNW1LenghtRemaind"].ToString())?"0":dt.Rows[0]["SumUNW1LenghtRemaind"].ToString());
        //    Lam._SumUNW1LenghtInput = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumUNW1LenghtInput"].ToString())?"0":dt.Rows[0]["SumUNW1LenghtInput"].ToString());
        //    Lam._SumUNW1Width = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumUNW1Width"].ToString())?"0":dt.Rows[0]["SumUNW1Width"].ToString());
        //    Lam._SumUNW1WidthRemaind = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumUNW1WidthRemaind"].ToString())?"0":dt.Rows[0]["SumUNW1WidthRemaind"].ToString());
        //    Lam._SumUNW1WidthInput = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumUNW1WidthInput"].ToString())?"0":dt.Rows[0]["SumUNW1WidthInput"].ToString());
        //    Lam._SumREWWeight = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumREWWeight"].ToString())?"0":dt.Rows[0]["SumREWWeight"].ToString());
        //    Lam._SumREWLenght = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumREWLenght"].ToString())?"0":dt.Rows[0]["SumREWLenght"].ToString());
        //    Lam._SumREWWidth = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumREWWidth"].ToString()) ? "0" : dt.Rows[0]["SumREWWidth"].ToString());
        //    Lam._Checked = dt.Rows[0]["Checked"].ToString();
        //    Lam._Reported = dt.Rows[0]["Reported"].ToString();
        //    Lam._CheckedBy = dt.Rows[0]["CheckedBy"].ToString();
        //    Lam._ReportedBy = dt.Rows[0]["ReportedBy"].ToString();
        //    Lam._CheckedDate = DateTime?.Parse(dt.Rows[0]["CheckedDate"].ToString());
        //    Lam._ReportedDate = DateTime?.Parse(dt.Rows[0]["ReportedDate"].ToString());
        //    Lam._SumWasteLenght = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumWasteLenght"].ToString()) ? "0" : dt.Rows[0]["SumWasteLenght"].ToString());
        //    Lam._SumWasteWeight = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumWasteWeight"].ToString()) ? "0" : dt.Rows[0]["SumWasteWeight"].ToString());
        //    Lam._SumWasteLenghtInput = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumWasteLenghtInput"].ToString()) ? "0" : dt.Rows[0]["SumWasteLenghtInput"].ToString());
        //    Lam._SumWasteWeightInput = float.Parse(string.IsNullOrEmpty(dt.Rows[0]["SumWasteWeightInput"].ToString()) ? "0" : dt.Rows[0]["SumWasteWeightInput"].ToString());
        //    //chua co SumWaste
        //    //chua co Reported va Checked
        //    return Lam;
        //}       


public class Cyn
 {
#region Header
        private int ID;
        public int ID_
        {
            get { return ID; }
            set { ID = value; }
        }

        private string ArtworkCode;
        public string ArtworkCode_
        {
            get { return ArtworkCode; }
            set { ArtworkCode = value; }
        }

        private string FGCode;
        public string FGCode_
        {
            get { return FGCode; }
            set { FGCode = value; }
        }

        private string FGName;
        public string FGName_
        {
            get { return FGName; }
            set { FGName = value; }
        }

        private string CMID;
        public string CMID_
        {
            get { return CMID; }
            set
            {               
                  CMID = value ;                              
            }
        }

        private string Predecessor;

        public string Predecessor_
        {
            get { return Predecessor; }
            set {                
                Predecessor = value ;           
                }
        }
        private string Owner;

        public string Owner_
        {
            get { return Owner; }
            set { Owner = value; }
        }

        private string Duration;

        public string Duration_
        {
            get { return Duration; }
            set { Duration = value ; }
        }
        private string PercentComplete;

        public string PercentComplete_
        {
            get { return PercentComplete; }
            set { PercentComplete = value; }
        }
        private string Mode;

        public string Mode_
        {
            get { return Mode; }
            set { Mode = value ; }
        }

        private int UserID;
        public int UserID_
        {
            get { return UserID; }
            set { UserID = value; }
        }

        private DateTime? UserInputDate;
        public DateTime? UserInputDate_
        {
            get { return UserInputDate; }
            set {               
                    UserInputDate = value;               
                 }

        }

        private bool JobOld;

        public bool JobOld_
        {
            get { return JobOld; }
            set { JobOld = value; }
        }

#endregion

#region CM
        private int IDCM;
        public int IDCM_
        {
            get { return IDCM; }
            set { IDCM = value; }
        }

        
        private DateTime? CynReadyforPlating;
        public DateTime? CynReadyforPlating_
        {
            get { return CynReadyforPlating; }
            set {
                //if (value.ToString().Length != 0)
                    CynReadyforPlating = value;
                //else
                //    CynReadyforPlating = DateTime?.Parse("1900-01-01") ;
                 }
        }

        private DateTime? PlatingDate;
        public DateTime? PlatingDate_
        {
            get { return PlatingDate; }
            set {
                //if (value.ToString().Length != 0)
                    PlatingDate = value;
                //else
                //    PlatingDate = DateTime?.Parse("1900-01-01") ;
                }
        }

        private DateTime? CynReadyforEngraving;
        public DateTime? CynReadyforEngraving_
        {
            get { return CynReadyforEngraving; }
            set {
                //if (value.ToString().Length != 0)
                    CynReadyforEngraving = value;
                //else
                //    CynReadyforEngraving = DateTime?.Parse("1900-01-01") ;
                }
        }

        private DateTime? EngravingDate;
        public DateTime? EngravingDate_
        {
            get { return EngravingDate; }
            set {
                //if (value.ToString().Length != 0)
                    EngravingDate = value;
                //else
                //    EngravingDate = DateTime?.Parse("1900-01-01") ;
                 }
        }

        private DateTime? CynReadyforProofing;
        public DateTime? CynReadyforProofing_
        {
            get { return CynReadyforProofing; }
            set {
                //if (value.ToString().Length != 0)
                    CynReadyforProofing = value;
                //else
                //    CynReadyforProofing = DateTime?.Parse("1900-01-01") ;
                }
        }

        private DateTime? ProofingDate;
        public DateTime? ProofingDate_
        {
            get { return ProofingDate; }
            set {
                //if (value.ToString().Length != 0)
                    ProofingDate = value;
                //else
                //    ProofingDate = DateTime?.Parse("1900-01-01") ;
                 }
        }

        private DateTime? CynReadyforPrinting;
        public DateTime? CynReadyforPrinting_
        {
            get { return CynReadyforPrinting; }
            set {
                //if (value.ToString().Length != 0)
                    CynReadyforPrinting = value;
                //else
                //    CynReadyforPrinting = DateTime?.Parse("1900-01-01") ;
                }
        }

        private string NoteCM;
        public string NoteCM_
        {
            get { return NoteCM; }
            set { NoteCM = value; }
        }

        private int UserIDCM;
        public int UserIDCM_
        {
            get { return UserIDCM; }
            set { UserIDCM = value; }
        }

        private DateTime? UserInputDateCM;
        public DateTime? UserInputDateCM_
        {
            get { return UserInputDateCM; }
            set
            {

                UserInputDateCM = value;
            }
                
        }

        private DateTime? ReceivedDocfromGA;

        public DateTime? ReceivedDocfromGA_
        {
            get { return ReceivedDocfromGA; }
            set { ReceivedDocfromGA = value; }
        }
        private bool OverQuantity;

        public bool OverQuantity_
        {
            get { return OverQuantity; }
            set { OverQuantity = value; }
        }
#endregion

#region CM_WH
        private int IDCMWH;
        public int IDCMWH_
        {
            get { return IDCMWH; }
            set { IDCMWH = value; }
        }

        //IDJob
        private string Color;
        public string Color_
        {
            get { return Color; }
            set { Color = value; }
        }

        private bool CoreStatus;
        public bool CoreStatus_
        {
            get { return CoreStatus; }
            set { CoreStatus = value; }
        }

        private string StockofMonth;
        public string StockofMonth_
        {
            get { return StockofMonth; }
            set { StockofMonth = value; }
        }

        private DateTime? DateReceivedfromCM;
        public DateTime? DateReceivedfromCM_
        {
            get { return DateReceivedfromCM; }
            set {
                //if (value.ToString().Length != 0)
                    DateReceivedfromCM = value;
                //else
                //    DateReceivedfromCM = DateTime?.Parse("1900-01-01") ;
                 }
        }

        private string NoteCMWH;
        public string NoteCMWH_
        {
            get { return NoteCMWH; }
            set { NoteCMWH = value; }
        }

        private int UserIDCMWH;
        public int UserIDCMWH_
        {
            get { return UserIDCMWH; }
            set { UserIDCMWH = value; }
        }

        private DateTime? UserInputDateCMWH;
        public DateTime? UserInputDateCMWH_
        {
            get { return UserInputDateCMWH; }
            set
            {                
                    UserInputDateCMWH = value;
                
            }
        }
#endregion

#region GA
        //GA
        private int IDGA;
        public int IDGA_
        {
            get { return IDGA; }
            set { IDGA = value; }
        }
        
        private DateTime? ArtworkReceivedDate;
        public DateTime? ArtworkReceivedDate_
        {
            
            get { return ArtworkReceivedDate; }
            set
            {
                //if (value.ToString().Length != 0)
                    ArtworkReceivedDate = value;
                //else
                //    ArtworkReceivedDate = DateTime?.Parse("1900-01-01") ;
            }
        }

        private DateTime? ProofOrderDate;
        public DateTime? ProofOrderDate_
        {
            get { return ProofOrderDate; }
            set 
            {
                //if (value.ToString().Length != 0)
                    ProofOrderDate = value; 
                //else
                //    ProofOrderDate = DateTime?.Parse("1900-01-01") ;                
            }
        }

        private DateTime? SendGMGDate;
        public DateTime? SendGMGDate_
        {
            get { return SendGMGDate; }
            set 
            {
                //if (value.ToString().Length != 0)
                    SendGMGDate = value;
                //else
                //    SendGMGDate = DateTime?.Parse("1900-01-01") ;
            }
        }

        private DateTime? GMGConfirmbyCustomerDate;
        public DateTime? GMGConfirmbyCustomerDate_
        {
            get { return GMGConfirmbyCustomerDate; }
            set
            {
                //if (value.ToString().Length != 0)
                    GMGConfirmbyCustomerDate = value;
                //else
                //    GMGConfirmbyCustomerDate = DateTime?.Parse("1900-01-01") ;
            }
        }

        private DateTime? SendDocToCMDate;
        public DateTime? SendDocToCMDate_
        {
            get { return SendDocToCMDate; }
            set {
                //if (value.ToString().Length != 0)
                    SendDocToCMDate = value;
                //else
                //    SendDocToCMDate = DateTime?.Parse("1900-01-01") ;
                 }
        }

        private string NoteGA;
        public string NoteGA_
        {
            get { return NoteGA; }
            set { NoteGA = value; }
        }

        private int UserIDGA;
        public int UserIDGA_
        {
            get { return UserIDGA; }
            set { UserIDGA = value; }
        }

        private DateTime? UserInputDateGA;
        public DateTime? UserInputDateGA_
        {
            get { return UserInputDateGA; }
            set {
                
                    UserInputDateGA = value;
                
                }
        }
#endregion

#region PL
        //PL
        private int IDPL;
        public int IDPL_
        {
            get { return IDPL; }
            set { IDPL = value; }
        }

        //IDJob
        private bool SOCStatus;
        public bool SOCStatus_
        {
            get { return SOCStatus; }
            set { SOCStatus = value; }
        }

        private bool RawmaterialStatus;
        public bool RawmaterialStatus_
        {
            get { return RawmaterialStatus; }
            set { RawmaterialStatus = value; }
        }

        private DateTime? ProductionDate;
        public DateTime? ProductionDate_
        {
            get { return ProductionDate; }
            set {
                //if (value.ToString().Length != 0)
                    ProductionDate = value;
                //else
                //    ProductionDate = DateTime?.Parse("1900-01-01") ;
                }
        }
        private DateTime? DeliveryDate;

        public DateTime? DeliveryDate_
        {
            get { return DeliveryDate; }
            set { DeliveryDate = value; }
        }


        private DateTime? ReiceivedDocfromCM;

        public DateTime? ReiceivedDocfromCM_
        {
            get { return ReiceivedDocfromCM; }
            set { ReiceivedDocfromCM = value; }
        }

        private string NotePL;
        public string NotePL_
        {
            get { return NotePL; }
            set { NotePL = value; }
        }

        private int UserIDPL;
        public int UserIDPL_
        {
            get { return UserIDPL; }
            set { UserIDPL = value; }
        }

        private DateTime? UserInputDatePL;
        public DateTime? UserInputDatePL_
        {
            get { return UserInputDatePL; }
            set {                
                    UserInputDatePL = value;                
                }
        }
        private string JobNumber;

        public string JobNumber_
        {
            get { return JobNumber; }
            set { JobNumber = value; }
        }

        public Cyn()
        {
            this.Predecessor_ = null;
        }

#endregion

    }

    public class Cyn_
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        //---------------------------GA----------------------------------------------------------------
        //
        //////////////////////////////////////////////////////////////////////////////////////////////// 
        public void Header_Search(string keyword, GridControl gc1, DataNavigator dn)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable(
                                                "Header_Search", CommandType.StoredProcedure,
                                                "@ArtworkCode", keyword,
                                                "@FGCode", keyword
                                     );
            dn.DataSource= gc1.DataSource = dt;
        }

        public DataTable Schedule_Search(string keywords, string StartDate, string EndDate)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable(
                                                "Schedule_Search", CommandType.StoredProcedure,
                                                "@StartDate", StartDate,
                                                "@EndDate", EndDate,
                                                "@Keywords", keywords
                                     );
            return dt;
            
        }

        public void Mail(string re, string bo, string su)
        {
           Sql.ExecuteNonQuery(                "Mail", CommandType.StoredProcedure,
                                                "@pr" ,"CM Application",
					                            "@re" , re,
					                            "@bo" , bo,
					                            "@su" , su                                                
                                     );      
        }

        public DataTable Schedule_TOP10_Search()
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable(
                                                "Schedule_TOP10_Search", CommandType.StoredProcedure                                               
                                     );
            return dt;

        }

        public void Header_Update(Cyn cyn, Cyn cyn_Prev,User user)
        {
           Sql.ExecuteNonQuery(
                                               "Header_Update"              , CommandType.StoredProcedure,
                                               "@ID"                        , cyn.ID_,		   
		                                       "@ArtworkCode"               , cyn.ArtworkCode_,
                                               "@FGCode"                    , cyn.FGCode_,
                                               "@FGName"                    , cyn.FGName_,           
                                               "@UserID"                    , user.ID,
                                               "@UserInputDate"             , "2013-01-01",           
                                               //-------------------------------------           	   
		                                       "@ArtworkCode_Prev"          ,cyn_Prev.ArtworkCode_,
                                               "@FGCode_Prev"               ,cyn_Prev.FGCode_,
                                               "@FGName_Prev"               ,cyn_Prev.FGName_,
                                               "@UserIDHeader_Prev"         ,cyn_Prev.ID_,
                                               "@UserInputDateHeader_Prev"  ,cyn_Prev.UserInputDate_
                                                
                                     );
            
        }

        public void Predecessor_Update(Cyn cyn)
        {
            Sql.ExecuteNonQuery(
                                                "Predecessor_Update", CommandType.StoredProcedure,
                                                "@Owner", cyn.Owner_,
                                                "@Predecessor", cyn.Predecessor_
                                     );
            
        }

        public DataTable Predecessor_Search(Cyn cyn)
        {
            DataTable dt = Sql.ExecuteDataTable(
                                                "Predecessor_Search", CommandType.StoredProcedure,
                                                "@Owner",cyn.Owner_
                                     );
            return dt;

        }

        public DataTable Report_DEPT_CM(string keywords, string StartDate, string EndDate)
        {
            DataTable dt = Sql.ExecuteDataTable(
                                                "Report_DEPT_CM", CommandType.StoredProcedure,
                                                "@StartDate", StartDate,
                                                "@EndDate", EndDate,
                                                "@Keywords", keywords
                                     );
            return dt;

        }

        public DataTable Report_DEPT_CM_WH(string keywords, string StartDate, string EndDate)
        {
            DataTable dt = Sql.ExecuteDataTable(
                                                "Report_DEPT_CM_WH", CommandType.StoredProcedure,
                                                "@StartDate", StartDate,
                                                "@EndDate", EndDate,
                                                "@Keywords", keywords
                                     );
            return dt;

        }
        public DataTable Report_DEPT_PL(string keywords, string StartDate, string EndDate)
        {
            DataTable dt = Sql.ExecuteDataTable(
                                                "Report_DEPT_PL", CommandType.StoredProcedure,
                                                "@StartDate", StartDate,
                                                "@EndDate", EndDate,
                                                "@Keywords", keywords
                                     );
            return dt;

        }
        public DataTable Report_DEPT_GA(string keywords, string StartDate, string EndDate)
        {
            DataTable dt = Sql.ExecuteDataTable(
                                                "Report_DEPT_GA", CommandType.StoredProcedure,
                                                "@StartDate", StartDate,
                                                "@EndDate", EndDate,
                                                "@Keywords", keywords
                                     );
            return dt;

        }

        public DataTable Report_AllCondition(string keywords,string StartDate, string EndDate)
        {
            DataTable dt = Sql.ExecuteDataTable(
                                                "Report_AllCondition", CommandType.StoredProcedure,
                                                "@StartDate", StartDate,
                                                "@EndDate", EndDate,
                                                "@Keywords", keywords
                                     );
            return dt;

        }


        public DataTable Report_AllCondition_Data(string keywords, string StartDate, string EndDate)
        {
            DataTable dt = Sql.ExecuteDataTable(
                                                "Report_AllCondition_Data", CommandType.StoredProcedure,
                                                "@StartDate", StartDate,
                                                "@EndDate", EndDate,
                                                "@Keywords", keywords
                                     );
            return dt;

        }

        public DataTable Report_AllCondition_Data_CM(string keywords, string StartDate, string EndDate)
        {
            DataTable dt = Sql.ExecuteDataTable(
                                                "Report_AllCondition_Data_CM", CommandType.StoredProcedure,
                                                "@StartDate", StartDate,
                                                "@EndDate", EndDate,
                                                "@Keywords", keywords
                                     );
            return dt;

        }

        public DataTable Report_AllCondition_Data_PL(string keywords, string StartDate, string EndDate)
        {
            DataTable dt = Sql.ExecuteDataTable(
                                                "Report_AllCondition_Data_PL", CommandType.StoredProcedure,
                                                "@StartDate", StartDate,
                                                "@EndDate", EndDate,
                                                "@Keywords", keywords
                                     );
            return dt;

        }

        public DataTable Report_AllCondition_Header(string keywords, string StartDate, string EndDate)
        {
            DataTable dt = Sql.ExecuteDataTable(
                                                "Report_AllCondition_Header", CommandType.StoredProcedure,
                                                "@StartDate", StartDate,
                                                "@EndDate", EndDate,
                                                "@Keywords", keywords
                                     );
            return dt;

        }

        public DataTable Report_AllCondition_Data_CM_WH(string keywords, string StartDate, string EndDate)
        {
            DataTable dt = Sql.ExecuteDataTable(
                                                "Report_AllCondition_Data_CM_WH", CommandType.StoredProcedure,
                                                "@StartDate", StartDate,
                                                "@EndDate", EndDate,
                                                "@Keywords", keywords
                                     );
            return dt;

        }
        public DataTable Report_AllCondition_Data_GA(string keywords, string StartDate, string EndDate)
        {
            DataTable dt = Sql.ExecuteDataTable(
                                                "Report_AllCondition_Data_GA", CommandType.StoredProcedure,
                                                "@StartDate", StartDate,
                                                "@EndDate", EndDate,
                                                "@Keywords", keywords
                                     );
            return dt;

        }

        public DataTable Report_GetFromCMtmp(int ID)
        {
            DataTable dt = Sql.ExecuteDataTable(
                                                "Report_GetFromCMtmp", CommandType.StoredProcedure,
                                                "@ID", ID                                             
                                     );
            return dt;

        }
        public DataTable Report_GetFromPLtmp(int ID)
        {
            DataTable dt = Sql.ExecuteDataTable(
                                                "Report_GetFromPLtmp", CommandType.StoredProcedure,
                                                "@ID", ID
                                     );
            return dt;

        }

        public void GA_tmp_Select_4Schedule(Cyn cyn, GridControl gc1, DataNavigator dn)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable(
                                                "GA_tmp_Select4Schedule", CommandType.StoredProcedure,
                                                "@ID", cyn.ID_
                                    );
            dn.DataSource = gc1.DataSource = dt;
        }
        public void CM_tmp_Select_4Schedule(Cyn cyn, GridControl gc1, DataNavigator dn)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable(
                                                "CM_tmp_Select4Schedule", CommandType.StoredProcedure,
                                                "@ID", cyn.ID_
                                    );
            dn.DataSource = gc1.DataSource = dt;
        }
        public void PL_tmp_Select_4Schedule(Cyn cyn, GridControl gc1, DataNavigator dn)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable(
                                                "PL_tmp_Select4Schedule", CommandType.StoredProcedure,
                                                "@ID", cyn.ID_
                                    );
            dn.DataSource = gc1.DataSource = dt;
        }
        public void CM_WH_tmp_Select_4Schedule(Cyn cyn, GridControl gc1, DataNavigator dn)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable(
                                                "CM_WH_tmp_Select4Schedule", CommandType.StoredProcedure,
                                                "@ID", cyn.ID_
                                    );
            dn.DataSource = gc1.DataSource = dt;
        }

        public void GA_tmp_Select(Cyn cyn, GridControl gc1, DataNavigator dn)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable(
                                                "GA_tmp_Select", CommandType.StoredProcedure,
                                                "@ID", cyn.ID_
                                    );
            dn.DataSource = gc1.DataSource = dt;
        }
        public void CM_tmp_Select(Cyn cyn, GridControl gc1, DataNavigator dn)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable(
                                                "CM_tmp_Select", CommandType.StoredProcedure,
                                                "@ID", cyn.ID_
                                    );
            dn.DataSource = gc1.DataSource = dt;
        }
        public void PL_tmp_Select(Cyn cyn, GridControl gc1, DataNavigator dn)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable(
                                                "PL_tmp_Select", CommandType.StoredProcedure,
                                                "@ID", cyn.ID_
                                    );
            dn.DataSource = gc1.DataSource = dt;
        }
        public void CM_WH_tmp_Select(Cyn cyn, GridControl gc1, DataNavigator dn)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable(
                                                "CM_WH_tmp_Select", CommandType.StoredProcedure,
                                                "@ID", cyn.ID_
                                    );
            dn.DataSource = gc1.DataSource = dt;
        }

        public void GA_Select(Cyn cyn, GridControl gc1, DataNavigator dn)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable(
                                                "GA_Select",CommandType.StoredProcedure, 
                                                "@ID",cyn.ID_
                                    );
            dn.DataSource=gc1.DataSource = dt;
        }

        public void GA_Select_All(GridControl gc1, DataNavigator dn)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable(
                                                "GA_Select_All",CommandType.StoredProcedure
                                    );
            dn.DataSource=gc1.DataSource = dt;
        }

        public void GA_Insert(Cyn cyn, User user)
        {
            Sql.ExecuteNonQuery(
                                                "InsNew", CommandType.StoredProcedure,
                                                "@ArtworkCode", cyn.ArtworkCode_,
                                                "@FGCode", cyn.FGCode_,
                                                "@FGName", cyn.FGName_,
                
                                                "@UserID", user.ID,
                                                "@UserInputDate", DateTime.Now.ToShortDateString(),
                                                "@JobOld",cyn.JobOld_,
                //--GA----------------------------
                                                //"@ArtworkReceivedDate", cyn.ArtworkReceivedDate_,
                                                "@ArtworkReceivedDate", (DateTime?)null,
                                                "@ProofOrderDate", cyn.ProofOrderDate_,
                                                "@SendGMGDate", cyn.SendGMGDate_,
                                                "@GMGConfirmbyCustomerDate", cyn.GMGConfirmbyCustomerDate_,
                                                "@SendDocToCMDate", cyn.SendDocToCMDate_,
                                                "@NoteGA", cyn.NoteGA_,
                                                "@UserIDGA", user.ID,
                                                "@UserInputDateGA", DateTime.Now.ToShortDateString()
                //--PL--------------------------

                //--CM_WH-----------------------

                //--CM--------------------------

                               );
            
            
        }

        public int GA_Delete(Cyn cyn,User user)
        {
            return Sql.ReturnParameterFromStore(
                                               "GA_Delete", CommandType.StoredProcedure, 
                                               "@ID"                , cyn.ID_,
                                               "@UserID"            , user._ID,
                                               "@UserInputdate"     , DateTime.Now.ToString(),
                                               "@UserID_Prev"       , cyn.UserIDGA_
                                );            
        }

        public void GA_Update(Cyn cyn, Cyn cyn_Prev, User user)
        {
            Sql.ExecuteNonQuery(
                                               "GA_Update", CommandType.StoredProcedure,
                                               "@ID", cyn.ID_,                                                              
                                               "@UserID", user._ID,
                                               "@UserInputDate", DateTime.Now.ToShortDateString(),
                                               "@JobOld", cyn.JobOld_,
                                               "@ArtworkCode" , cyn.ArtworkCode_,
                                               "@FGCode" , cyn.FGCode_,
                                               "@FGName" , cyn.FGName_,
                //-------------------------------------     
                                               "@IDGA", cyn_Prev.IDGA_,
                                               "@ArtworkReceivedDate", cyn.ArtworkReceivedDate_,
                                               "@ProofOrderDate", cyn.ProofOrderDate_,
                                               "@SendGMGDate", cyn.SendGMGDate_,
                                               "@GMGConfirmbyCustomerDate", cyn.GMGConfirmbyCustomerDate_,
                                               "@SendDocToCMDate", cyn.SendDocToCMDate_,
                                               "@NoteGA", cyn.NoteGA_,                                               
                //---------------------------------------
                                               "@ArtworkReceivedDate_Prev", cyn_Prev.ArtworkReceivedDate_,
                                               "@ProofOrderDate_Prev", cyn_Prev.ProofOrderDate_,
                                               "@SendGMGDate_Prev", cyn_Prev.SendGMGDate_,
                                               "@GMGConfirmbyCustomerDate_Prev", cyn_Prev.GMGConfirmbyCustomerDate_,
                                               "@SendDocToCMDate_Prev", cyn_Prev.SendDocToCMDate_,
                                               "@NoteGA_Prev", cyn_Prev.NoteGA_,
                                               "@UserID_Prev", cyn_Prev.UserIDGA_,
                                               "@UserInputDate_Prev", cyn_Prev.UserInputDateGA_,
                                               "@ArtworkCode_Prev", cyn_Prev.ArtworkCode_,
                                               "@FGCode_Prev", cyn_Prev.FGCode_,
                                               "@FGName_Prev", cyn_Prev.FGName_,
                //---------------------------------------                           
                                               "@JobOld_Prev" ,cyn_Prev.JobOld_
                                              
                               );
        }

        public void GA_Search(Cyn cyn, GridControl gc1, DataNavigator dn)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable(
                                               "GA_Search",CommandType.StoredProcedure,
                                               "@ArtworkCode", cyn.ArtworkCode_,
			                                   "@FGCode", cyn.FGCode_
                                     );
            dn.DataSource= gc1.DataSource = dt;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        //  
        //-----------------------------------CM---------------------------------------------------------
        //
        ////////////////////////////////////////////////////////////////////////////////////////////////

        public void CM_Select(Cyn cyn,GridControl gc1, DataNavigator dn)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable(
                                               "CM_Select",CommandType.StoredProcedure,
                                               "@ID",cyn.ID_
                                     );
            dn.DataSource = gc1.DataSource = dt;
        }

        public void CM_Select_All(GridControl gc1, DataNavigator dn)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable(
                                               "CM_Select_All",CommandType.StoredProcedure
                                    );
            dn.DataSource = gc1.DataSource = dt;
        }

        public DataTable CM_Select_Top10()//(GridControl gc1, DataNavigator dn)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable(
                                               "CM_Select_Top10", CommandType.StoredProcedure
                                    );
            //dn.DataSource = gc1.DataSource = dt;
            return dt;
        }        

        public void CM_Update(Cyn cyn,Cyn cyn_Prev,User user)
        {
            Sql.ExecuteNonQuery(
                                               "CM_Update", CommandType.StoredProcedure,
                                               "@ID_Prev" , cyn_Prev.ID_,		                                       
                                               "@CMID" ,cyn.CMID_,                                               
                                               //------------------------------------- 
                                               "@IDCM_Prev" ,cyn_Prev.IDCM_,
                                               "@CynReadyforPlating" ,cyn.CynReadyforPlating_,
                                               "@PlatingDate" ,cyn.PlatingDate_,
                                               "@CynReadyforEngraving" ,cyn.CynReadyforEngraving_,
                                               "@EngravingDate" ,cyn.EngravingDate_,
                                               "@CynReadyforProofing" ,cyn.CynReadyforProofing_,
                                               "@ProofingDate" ,cyn.ProofingDate_,
                                               "@CynReadyforPrinting" ,cyn.CynReadyforPrinting_,
                                               "@NoteCM" ,cyn.NoteCM_,
                                               "@UserID" ,user.ID,
                                               "@UserInputDateCM", DateTime.Now.ToShortDateString(),
                                               "@ReceivedDocfromGA", cyn.ReceivedDocfromGA_,
                                               "@OverQuantity",cyn.OverQuantity_,
                                               //-------------------------------------
                                               "@CynReadyforPlating_Prev" ,cyn_Prev.CynReadyforPlating_,
                                               "@PlatingDate_Prev" ,cyn_Prev.PlatingDate_,
                                               "@CynReadyforEngraving_Prev" ,cyn_Prev.CynReadyforEngraving_,
                                               "@EngravingDate_Prev" ,cyn_Prev.EngravingDate_,
                                               "@CynReadyforProofing_Prev" ,cyn_Prev.CynReadyforProofing_,
                                               "@ProofingDate_Prev" ,cyn_Prev.ProofingDate_,
                                               "@CynReadyforPrinting_Prev" ,cyn_Prev.CynReadyforPrinting_,
                                               "@NoteCM_Prev" ,cyn_Prev.NoteCM_,
                                               "@UserIDCM_Prev" ,cyn_Prev.UserIDCM_,
                                               "@UserInputDateCM_Prev", DateTime.Now.ToShortDateString(),
                                               "@ReceivedDocfromGA_Prev", cyn_Prev.ReceivedDocfromGA_,
                                               "@OverQuantity_Prev",cyn_Prev.OverQuantity_,
                                               //---------------------------------------------------------------
                                               "@CMID_Prev" , cyn_Prev.CMID_                                               
                                );
        }

        //public void CM_Delete(Cyn cyn)
        //{
        //    Sql.ExecuteNonQuery(
        //                                        "CM_Delete", CommandType.StoredProcedure,
        //                        );

        //}

        public void CM_Search(Cyn cyn,GridControl gc1, DataNavigator dn)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable(
                                                "CM_Search", CommandType.StoredProcedure,
                                                "@ArtworkCode",cyn.ArtworkCode_,
			                                    "@FGCode" ,cyn.FGCode_,
			                                    "@CMID" ,cyn.CMID_
                                    );
            dn.DataSource = gc1.DataSource = dt;
        }

        public int CM_Count(int i, DateTime date)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable(
                                                "CM_Count", CommandType.StoredProcedure,
                                                "@ID", i,
                                                "@date", date                                                
                                    );
            return dt.Rows.Count;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////
        //
        //---------------------------------CM_WH----------------------------------------------------------
        //
        ////////////////////////////////////////////////////////////////////////////////////////////////

        public void CM_WH_Select(Cyn cyn, GridControl gc1, DataNavigator dn)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable(
                                                "CM_WH_Select",CommandType.StoredProcedure,
                                                "@ID",cyn.ID_
                                     );
            dn.DataSource = gc1.DataSource = dt;
        }

        public void CM_WH_Select_All(GridControl gc1, DataNavigator dn)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable(
                                                "CM_WH_Select_All",CommandType.StoredProcedure
                                    );
            dn.DataSource = gc1.DataSource = dt;
        }

        public void CM_WH_Update(Cyn cyn, Cyn cyn_Prev, User user)
        {
            Sql.ExecuteNonQuery(
                                               "CM_WH_Update", CommandType.StoredProcedure,
                                               "@ID_Prev" ,cyn_Prev.ID_,        
                                               "@IDCMWH_Prev" ,cyn_Prev.IDCMWH_,
                                               "@Color" ,cyn.Color_,
                                               "@CoreStatus" ,cyn.CoreStatus_,
                                               "@StockofMonth" ,cyn.StockofMonth_,
                                               "@DateReceivedfromCM" ,cyn.DateReceivedfromCM_,
                                               "@NoteCMWH" ,cyn.NoteCMWH_,
                                               "@UserID" ,user.ID,
                                               "@UserInputDateCMWH", DateTime.Now.ToShortDateString(),
                                               //-------------------------------------
                                               "@Color_Prev" ,cyn_Prev.Color_,
                                               "@CoreStatus_Prev" ,cyn_Prev.CoreStatus_,
                                               "@StockofMonth_Prev" ,cyn_Prev.StockofMonth_,
                                               "@DateReceivedfromCM_Prev" ,cyn_Prev.DateReceivedfromCM_,
                                               "@NoteCMWH_Prev" ,cyn_Prev.NoteCMWH_,
                                               "@UserIDCMWH_Prev" ,cyn_Prev.UserIDCMWH_,
                                               "@UserInputDateCMWH_Prev", cyn_Prev.UserInputDateCMWH_
                                );
        }

        //public void CM_WH_Delete(Cyn cyn)
        //{
        //    Sql.ExecuteNonQuery(
        //                                        "CM_WH_Delete", CommandType.StoredProcedure,
        //                        );

        //}

        public void CM_WH_Search(Cyn cyn, GridControl gc1, DataNavigator dn)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable(
                                                "CM_WH_Search", CommandType.StoredProcedure,
                                                "@ArtworkCode", cyn.ArtworkCode_,
			                                    "@FGCode", cyn.FGCode_,
                                                "@CMID",cyn.CMID_
                                     );
            dn.DataSource = gc1.DataSource = dt;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////
        //
        //-----------------------------------PL--------------------------------------------------------
        //
        ////////////////////////////////////////////////////////////////////////////////////////////////

        public void PL_Select(Cyn cyn, GridControl gc1, DataNavigator dn)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable(
                                                "PL_Select",CommandType.StoredProcedure,
                                                "@ID",cyn.ID_
                                     );
            dn.DataSource = gc1.DataSource = dt;
        }

        public void PL_Select_All(GridControl gc1, DataNavigator dn)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable(
                                                "PL_Select_All",CommandType.StoredProcedure
                                    );
            dn.DataSource = gc1.DataSource = dt;
        }

        public DataTable PL_Select_Top10(GridControl gc1, DataNavigator dn)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable(
                                                "PL_Select_Top10", CommandType.StoredProcedure
                                    );
            dn.DataSource = gc1.DataSource = dt;
            return dt;
        }

        public void PL_Update(Cyn cyn, Cyn cyn_Prev, User user)
        {
            Sql.ExecuteNonQuery(
                                               "PL_Update", CommandType.StoredProcedure,
                                               "@ID_Prev" 	                ,cyn_Prev.ID_,                                       
                                               "@UserID"                    ,user.ID,
                                               "@UserInputDate"             ,DateTime.Now.ToShortDateString(),
                                               //------------------------------------- 
                                               "@IDPL_Prev"                 ,cyn_Prev.IDPL_,
                                               "@SOCStatus"                 ,cyn.SOCStatus_,
                                               "@RawmaterialStatus"         ,cyn.RawmaterialStatus_,
                                               "@ProductionDate"            ,cyn.ProductionDate_,
                                               "@ReceivedDocfromCM"         ,cyn.ReiceivedDocfromCM_,
		                                       "@DeliveryDate"              ,cyn.DeliveryDate_,
                                               "@NotePL"                    ,cyn.NotePL_, 
                                               "@JobNumber"                 ,cyn.JobNumber_,
                                               //-------------------------------------
                                               "@SOCStatus_Prev"            ,cyn_Prev.SOCStatus_,
                                               "@RawmaterialStatus_Prev"    ,cyn_Prev.RawmaterialStatus_,
                                               "@ProductionDate_Prev"       ,cyn_Prev.ProductionDate_,
                                               "@ReceivedDocfromCM_Prev"    ,cyn_Prev.ReiceivedDocfromCM_ ,
                                               "@DeliveryDate_Prev"         ,cyn_Prev.DeliveryDate_ ,                                               
                                               "@NotePL_Prev"               ,cyn_Prev.NotePL_,
                                               "@UserIDPL_Prev"             ,cyn_Prev.UserIDPL_,
                                               "@UserInputDatePL_Prev"      ,cyn_Prev.UserInputDatePL_,
                                               "@JobNumber_Prev"            ,cyn_Prev.JobNumber_
                                               //--------------------------------------------------------------------
                                               
                                               
                                );
        }

        //public void PL_Delete(Cyn cyn)
        //{
        //    Sql.ExecuteNonQuery(
        //                                        "PL_Delete", CommandType.StoredProcedure,
        //                        );

        //}

        public void PL_Search(Cyn cyn, GridControl gc1, DataNavigator dn)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable(
                                                "PL_Search", CommandType.StoredProcedure,
                                                "@ArtworkCode" ,cyn.ArtworkCode_,
				                                "@FGCode" , cyn.FGCode_
                                    );
            dn.DataSource = gc1.DataSource = dt;
        }

        public bool Task_Select(string Owner, string Predecessor)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable(
                                                "Task_Select", CommandType.StoredProcedure,
                                                "@Owner", Owner,
                                                "@Predecessor",Predecessor 
                                    );
            return (dt.Rows.Count > 0 ? true: false); 
        }


    }
    
}
