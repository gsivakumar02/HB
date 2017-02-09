using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APS.Presentation.Web.WebAPI.Models
{
    public class FTSInOrder
    {
        public int Id { get; set; }
        public int BankID { get; set; }
        public DateTime EntryDate { get; set; }
        public string MsgDate { get; set; }
        public string MsgIO { get; set; }
        public string MsgType { get; set; }
        public string Reference { get; set; }
        public string Related_Reference { get; set; }
        public string TUN { get; set; }
        public string PayTUN { get; set; }
        public string ReversalTUN { get; set; }
        public DateTime ValueDate { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public Nullable<decimal> Amount_EUR { get; set; }
        public Nullable<int> ServiceTypesCode { get; set; }
        public string ServiceCodesCode { get; set; }
        public string ServiceCodesCN { get; set; }
        public string AgreementBIC { get; set; }
        public Nullable<int> AgreementId { get; set; }
        public string CounterPartyBIC { get; set; }
        public string Corresp_BIC { get; set; }
        public string Corresp_Account { get; set; }
        public Nullable<byte> Corresp_AccType { get; set; }
        public string Cust_Code { get; set; }
        public string Orderer_Name { get; set; }
        public string Orderer_Account { get; set; }
        public string Benef_Name { get; set; }
        public string Benef_Account { get; set; }
        public Nullable<byte> Benef_AccFormat { get; set; }
        public string Pay_Method { get; set; }
        public string BenefBank_BIC { get; set; }
        public string Charges_Details { get; set; }
        public Nullable<decimal> Charges_Normal { get; set; }
        public Nullable<decimal> Charges_Special { get; set; }
        public Nullable<bool> ChargesSpecial_Flag { get; set; }
        public Nullable<decimal> Charges_Sender { get; set; }
        public Nullable<decimal> Charges_Receiver { get; set; }
        public bool Auto_Flag { get; set; }
        public Nullable<byte> Fwd_Flag { get; set; }
        public bool Stp_Flag { get; set; }
        public bool EU_Flag { get; set; }
        public Nullable<byte> Fraud_Flag { get; set; }
        public bool Cover_Flag { get; set; }
        public bool Auth_Flag { get; set; }
        public bool Paid_Flag { get; set; }
        public Nullable<int> AMLRPT_Flag { get; set; }
        public bool FwdAction_Flag { get; set; }
        public bool Duplicate_Flag { get; set; }
        public Nullable<int> DuplicateID { get; set; }
        public Nullable<int> Auto_ErrorCode { get; set; }
        public string Auto_ErrorDesc { get; set; }
        public Nullable<int> STP_ErrorCode { get; set; }
        public string STP_ErrorDesc { get; set; }
        public string Originator { get; set; }
        public string BranchID { get; set; }
        public string XML_Data { get; set; }
        public byte Status { get; set; }
        public Nullable<byte> PreviousStatus { get; set; }
        public Nullable<int> HBRecvRepId { get; set; }
        public Nullable<int> OLTPSendRecvId { get; set; }
        public Nullable<int> ConfirmRecvRepId { get; set; }
        public Nullable<int> ExtraitRecvRepId { get; set; }
        public Nullable<int> OtherCoverRecvRepId { get; set; }
        public Nullable<int> ExtraitLineNum { get; set; }
        public bool fStatistic { get; set; }
        public Nullable<int> AuthUserID { get; set; }
        public Nullable<int> ModUserID { get; set; }
        public Nullable<int> UserAction { get; set; }
        public int UserID { get; set; }
        public int Traceversion { get; set; }
        public bool Deleted { get; set; }
        public DateTime Utimestamp { get; set; }
        public Nullable<byte> MonPreviousStatus { get; set; }
        public Nullable<int> Category { get; set; }
        public Nullable<bool> Payment_Flag { get; set; }
        public string InvoiceReference { get; set; }
        public Nullable<int> RtnIsoCodeId { get; set; }
        public Nullable<int> ReturnOutId { get; set; }
        public Nullable<short> ProofCd { get; set; }
        public Nullable<int> WLFSendRecvId { get; set; }
        public Nullable<bool> WLFSent { get; set; }
        public Nullable<int> WLFFlag { get; set; }
        public string Pay_Branch { get; set; }
        public string ProductCode { get; set; }
        public Nullable<DateTime> PayDate { get; set; }
        public Nullable<int> RCL_Flag { get; set; }
        public string MsgTypeExtension { get; set; }
        public string FTS_Key { get; set; }
        public string OrganizationCode { get; set; }
        public Nullable<int> OrigOrderId { get; set; }
        public string SettlementSystem { get; set; }
        public bool IsOnline { get; set; }
        public byte RepaymentPriorityFlag { get; set; }
        public Nullable<int> PayTUN_Mode { get; set; }
        public string InstructionId { get; set; }
    }
}
