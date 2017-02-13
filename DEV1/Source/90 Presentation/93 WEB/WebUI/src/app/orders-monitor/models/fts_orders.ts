export class Fts_Orders {
    id: Number;
    bankId: Number;
    entryDate: Date;
    msgIO: string;
    msgType: string;
    tun: string;
    reversalTUN: string;
    valueDate: Date;
    currency: string;
    amount: Number;
    amount_EUR: string;
    serviceTypesCode: Number;
    charges_Details: string
    fwD_Flag: Boolean;
    stp_Flag: Boolean;
    fraud_Flag: Number;
    cover_Flag: Boolean;
    fwdAction_Flag: Boolean;
    auto_ErrorCode: string;
    auto_ErrorDesc: string;
    branchID: string;
    status: Number;
    authUserID: Number;
    modUserId: Number;
    userID: number;
    traceVersion: number;
    utimestamp: Date;
    monPreviousStatus: Number;
    benefBank_BIC: string;
    reference: string;
    counterPartyBIC: string;
    msgTypeExtension: string;
    isOnline: Boolean;
    repaymentPriorityFlag: string;
    productCode: string;
  
}
