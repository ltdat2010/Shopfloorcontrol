namespace Production
{
    public class Mail
    {
        public static void SendMail(string recipients, string body, string subject)
        {
        }

        //private static string [] new_Str(string str1)
        //{
        //    string[] str2 = str1.Split(new char[] {','});
        //        return str2;
        //}

        //public static void SendMail_GA_InsNew(Cyn cyn,User user,string recipients)
        //{
        //    string body = "|" + "--------------------------------------------------------------------------------------------" + System.Environment.NewLine +
        //                    "|" + "   Detail                          " + System.Environment.NewLine +
        //                    "|" + " - Created by                    : " + user.Username + System.Environment.NewLine +
        //                    "|" + " - Artwork Code                  : " + cyn.ArtworkCode_ + System.Environment.NewLine +
        //                    "|" + " - FG Code                       : " + cyn.FGCode_ + System.Environment.NewLine +
        //                    "|" + " - FG Name                       : " + cyn.FGName_ + System.Environment.NewLine +
        //                    "|" + " - Job repeat                    : " + (cyn.JobOld_ == true ? "Repeat" : "New") + System.Environment.NewLine +
        //                    //"|" + " - Artwork received doc. Date    : " + cyn.ArtworkReceivedDate_.ToString() + System.Environment.NewLine +
        //                    "|" + " - Artwork received doc. Date    : " + cyn.ArtworkReceivedDate_.ToString() + System.Environment.NewLine +
        //                    "|" + "--------------------------------------------------------------------------------------------" + System.Environment.NewLine +
        //                    "----------------------------Please do not reply this e-mail. Thanks-------------------------------";
        //    string subject = "GA Dept. has been created new Artwork : " + cyn.ArtworkCode_ + " - FG Code : " + cyn.FGCode_;
        //    SendMail(recipients, body, subject);

        //}

        //public static void SendMail_PL_InsNew(Cyn cyn, User user, string recipients)
        //{
        //    string body = "|" + "--------------------------------------------------------------------------------------------" + System.Environment.NewLine +
        //                    "|" + "   Detail                          " + System.Environment.NewLine +
        //                    "|" + " - Created by                    : " + user.Username + System.Environment.NewLine +
        //                    "|" + " - Artwork Code                  : " + cyn.ArtworkCode_ + System.Environment.NewLine +
        //                    "|" + " - FG Code                       : " + cyn.FGCode_ + System.Environment.NewLine +
        //                    "|" + " - FG Name                       : " + cyn.FGName_ + System.Environment.NewLine +
        //                    "|" + " - Job repeat                    : " + (cyn.JobOld_ == true ? "Repeat" : "New") + System.Environment.NewLine +
        //                    //"|" + " - Artwork received doc. Date    : " + cyn.ArtworkReceivedDate_.ToString() + System.Environment.NewLine +
        //                    "|" + " - Artwork received doc. Date    : " + cyn.ArtworkReceivedDate_.ToString() + System.Environment.NewLine +
        //                    "|" + "--------------------------------------------------------------------------------------------" + System.Environment.NewLine +
        //                    "----------------------------Please do not reply this e-mail. Thanks-------------------------------";
        //    string subject = "GL Dept. has been created Old Artwork : " + cyn.ArtworkCode_ + " - FG Code : " + cyn.FGCode_;
        //    SendMail(recipients, body, subject);

        //}
        //public static void SendMail_CM_Update(Cyn cyn, User user, string recipients)
        //{
        //    string body = "|" + "--------------------------------------------------------------------------------------------" + System.Environment.NewLine +
        //                    "|" + "   Detail                          " + System.Environment.NewLine +
        //                    "|" + " - Created by                        :" + user.Username + System.Environment.NewLine +
        //                    "|" + " - Artwork Code                      :" + cyn.ArtworkCode_ + System.Environment.NewLine +
        //                    "|" + " - FG Code                           :" + cyn.FGCode_ + System.Environment.NewLine +
        //                    "|" + " - FG Name                           :" + cyn.FGName_ + System.Environment.NewLine +
        //                    "|" + " - CMID                              :" + cyn.CMID_ + System.Environment.NewLine +
        //                    "|" + " - Received Doc. from GA             :" + cyn.ReceivedDocfromGA_.ToString() + System.Environment.NewLine +
        //                    "|" + " - Cyn. Ready for Plating            :" + cyn.CynReadyforPlating_.ToString() + System.Environment.NewLine +
        //                    "|" + " - Plating Date                      :" + cyn.PlatingDate_.ToString() + System.Environment.NewLine +
        //                    "|" + " - Cyn. Ready for Engraving          :" + cyn.CynReadyforEngraving_.ToString() + System.Environment.NewLine +
        //                    "|" + " - Engraving Date                    :" + cyn.EngravingDate_.ToString() + System.Environment.NewLine +
        //                    "|" + " - Cyn. Ready for Proofing           :" + cyn.CynReadyforProofing_.ToString() + System.Environment.NewLine +
        //                    "|" + " - Proofing Date                     :" + cyn.ProofingDate_.ToString() + System.Environment.NewLine +
        //                    "|" + " - Cyn. Ready for Printing           :" + cyn.CynReadyforPrinting_.ToString() + System.Environment.NewLine +
        //                    "|" + "--------------------------------------------------------------------------------------------" + System.Environment.NewLine +
        //                    "----------------------------Please do not reply this e-mail. Thanks-------------------------------";
        //    string subject = "CM Dept. has been updated to  Artwork : " + cyn.ArtworkCode_ + " - FG Code : " + cyn.FGCode_;
        //    SendMail(recipients, body, subject);

        //}
        //public static void SendMail_GA_Update(Cyn cyn, User user, string recipients)
        //{
        //    string body = "|" + "--------------------------------------------------------------------------------------------" + System.Environment.NewLine +
        //                    "|" + "   Detail                          " + System.Environment.NewLine +
        //                    "|" + " - Created by                     : " + user.Username + System.Environment.NewLine +
        //                    "|" + " - Artwork Code                   : " + cyn.ArtworkCode_ + System.Environment.NewLine +
        //                    "|" + " - FG Code                        : " + cyn.FGCode_ + System.Environment.NewLine +
        //                    "|" + " - FG Name                        : " + cyn.FGName_ + System.Environment.NewLine +
        //                    //"|" + " - Artwork received doc. Date     : " + cyn.ArtworkReceivedDate_.ToString() + System.Environment.NewLine +
        //                    "|" + " - Artwork received doc. Date     : " + cyn.ArtworkReceivedDate_.ToString() + System.Environment.NewLine +
        //                    "|" + " - Send GMG Date                  : " + cyn.SendGMGDate_.ToString() + System.Environment.NewLine +
        //                    "|" + " - GMG Confirm by Customer Date   : " + cyn.GMGConfirmbyCustomerDate_.ToString() + System.Environment.NewLine +
        //                    "|" + " - Send Doc. To CM Date           : " + cyn.SendDocToCMDate_.ToString() + System.Environment.NewLine +
        //                    "|" + "--------------------------------------------------------------------------------------------" + System.Environment.NewLine +
        //                    "----------------------------Please do not reply this e-mail. Thanks-------------------------------";
        //    string subject = "GA Dept. has been updated Artwork : " + cyn.ArtworkCode_ + " - FG Code : " + cyn.FGCode_;
        //    SendMail(recipients, body, subject);

        //}
        //public static void SendMail_PL_Update(Cyn cyn, User user, string recipients)
        //{
        //    string body = "|" + "--------------------------------------------------------------------------------------------" + System.Environment.NewLine +
        //                    "|" + "   Detail                          " + System.Environment.NewLine +
        //                    "|" + " - Created by                    : " + user.Username + System.Environment.NewLine +
        //                    "|" + " - Artwork Code                  : " + cyn.ArtworkCode_ + System.Environment.NewLine +
        //                    "|" + " - FG Code                       : " + cyn.FGCode_ + System.Environment.NewLine +
        //                    "|" + " - FG Name                       : " + cyn.FGName_ + System.Environment.NewLine +
        //                    "|" + " - JobNumber                     : " + cyn.JobNumber_ + System.Environment.NewLine +
        //                    "|" + " - SOC Status                    : " + (cyn.SOCStatus_ == true ? "OK": "NOT OK") + System.Environment.NewLine +
        //                    "|" + " - Rawmaterial Status            : " + (cyn.RawmaterialStatus_ == true ? "OK" : "NOT OK") + System.Environment.NewLine +
        //                    "|" + " - Received Doc. from Sale       : " + cyn.ReiceivedDocfromCM_.ToString() + System.Environment.NewLine +
        //                    "|" + " - Production Date               : " + cyn.ProductionDate_.ToString() + System.Environment.NewLine +
        //                    "|" + " - Delivery Date                 : " + cyn.DeliveryDate_.ToString() + System.Environment.NewLine +
        //                    "|" + "--------------------------------------------------------------------------------------------" + System.Environment.NewLine +
        //                    "----------------------------Please do not reply this e-mail. Thanks-------------------------------";
        //    string subject = "Planing Dept. has been updated Artwork : " + cyn.ArtworkCode_ + " - FG Code : " + cyn.FGCode_;
        //    SendMail(recipients, body, subject);

        //}
        //public static void SendMail_CM_WH_Update(Cyn cyn, User user, string recipients)
        //{
        //    string body = "|" + "--------------------------------------------------------------------------------------------" + System.Environment.NewLine +
        //                    "|" + "   Detail                          " + System.Environment.NewLine +
        //                    "|" + " - Created by                        : " + user.Username + System.Environment.NewLine +
        //                    "|" + " - Artwork Code                      : " + cyn.ArtworkCode_ + System.Environment.NewLine +
        //                    "|" + " - FG Code                           : " + cyn.FGCode_ + System.Environment.NewLine +
        //                    "|" + " - FG Name                           : " + cyn.FGName_ + System.Environment.NewLine +
        //                    "|" + " - Color                             : " + cyn.Color_ + System.Environment.NewLine +
        //                    "|" + " - CoreStatus                        : " + (cyn.CoreStatus_ == true ? "OK": "NOT OK") + System.Environment.NewLine +
        //                    "|" + " - StockofMonth                      : " + cyn.StockofMonth_ + System.Environment.NewLine +
        //                    "|" + " - DateReceivedfromCM                : " + cyn.DateReceivedfromCM_.ToString() + System.Environment.NewLine +
        //                    "|" + "--------------------------------------------------------------------------------------------" + System.Environment.NewLine +
        //                    "----------------------------Please do not reply this e-mail. Thanks-------------------------------";
        //    string subject = "CM_Warehouse Dept. has been updated new Artwork : " + cyn.ArtworkCode_ + " - FG Code : " + cyn.FGCode_;
        //    SendMail(recipients, body, subject);

        //}
        //public static void SendMail_GA_Delete(Cyn cyn, User user, string recipients)
        //{
        //    string body = "|" + "--------------------------------------------------------------------------------------------" + System.Environment.NewLine +
        //                    "|" + "   Detail                          " + System.Environment.NewLine +
        //                    "|" + " - Created by                    : " + user.Username + System.Environment.NewLine +
        //                    "|" + " - Artwork Code                  : " + cyn.ArtworkCode_ + System.Environment.NewLine +
        //                    "|" + " - FG Code                       : " + cyn.FGCode_ + System.Environment.NewLine +
        //                    "|" + " - FG Name                       : " + cyn.FGName_ + System.Environment.NewLine +
        //                    "|" + " - Job repeate                   : " + (cyn.JobOld_ == true ? "Repeat" : "New") + System.Environment.NewLine +
        //                    //"|" + " - Artwork received doc. Date    : " + cyn.ArtworkReceivedDate_.ToString() + System.Environment.NewLine +
        //                    "|" + " - Artwork received doc. Date    : " + cyn.ArtworkReceivedDate_.ToString() + System.Environment.NewLine +
        //                    "|" + "--------------------------------------------------------------------------------------------" + System.Environment.NewLine +
        //                    "----------------------------Please do not reply this e-mail. Thanks-------------------------------";
        //    string subject = "GA Dept. has been delete Artwork : " + cyn.ArtworkCode_ + " - FG Code : " + cyn.FGCode_;
        //    SendMail(recipients, body, subject);

        //}
    }
}