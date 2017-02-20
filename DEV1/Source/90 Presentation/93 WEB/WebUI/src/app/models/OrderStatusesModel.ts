export const enum InOrderStatus {

}

export const enum FTSOutgoingOrderStatus {
    INITIAL = 0,
    AUTO_READY = 1,
    REPAIR = 2,
    REPAIR_LOCK = 3,
    AUTH_REQUIRED = 4,
    AUTH_LOCK = 5,
    READY_TO_SEND = 6,
    SETTLED_OK = 7,
    SETTLED_NOT_OK = 8,
    WAIT_CANCEL_REQ = 9,
    ACK_OK = 10,
    WAIT_SWIFT_RESPONSE = 11,
    MANUAL_CANCEL_REQUIRED = 12,
    CANCEL_ACCEPTED = 13,
    CANCEL_DENIED = 14,
    REVERSED = 15,
    REJECTED = 16,
    RETURNED = 17,
    NACK = 18,
    RQST_FOR_RECALL = 19,
    RECALL_REJECT = 20,
    RECALL_ACCEPT = 21,
    AML_WAIT_RESPONSE = 22,
    AML_FREE = 23,
    AML_BLOCK = 24,
    AML_ERROR = 25
}

export enum FTSIncomingOrderStatus{
    INITIAL = 0,
    AUTO_READY = 1,
    REPAIR = 2,
    REPAIR_LOCK = 3,
    AUTH_REQUIRED = 4,
    AUTH_LOCK = 5,
    WAIT_COVER = 6,
    READY_WAIT_VALEUR = 7,
    READY_TO_SEND = 8,
    SETTLED_OK = 9,
    SETTLED_NOT_OK = 10,
    PAID_OK = 11,
    MANUAL_CANCEL_REQUIRED = 12,
    CANCEL_ACCEPTED = 13,
    REVERSED = 14,
    DISCARDED = 15,
    CANCEL_DENIED = 16,
    RETURNED = 17,
    RQST_FOR_RECALL = 18,
    RECALL_REJECT = 19,
    RECALL_ACCEPT = 20,
    AML_WAIT_RESPONSE = 21,
    AML_FREE = 22,
    AML_BLOCK = 23,
    AML_ERROR = 24,
    PAID_OK_WAIT_CONFIRM = 25,
    SETTLED_OK_WAIT = 26,
    PAID_OK_NOT_COMPLETED = 27,
    RETURNED_NOT_COMPLETED = 28,
    SETTLED_OK_PENDING = 29
}

export class OrderStatusesModel {
    Status: Number;
    Description: string;
    MsgIO: string;
    Count: Number;
    Category : string;
}