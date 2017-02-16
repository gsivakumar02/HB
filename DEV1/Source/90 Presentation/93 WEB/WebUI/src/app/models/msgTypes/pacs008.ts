export class Pacs008 {
    XMT1003Schema: string;
    MsgIO: string;
    Sender: string;
    Receiver: string;
    F2_MSGPRIORITY: string;
    F2_OBSPERIOD: string;
    xml_data: any;
    get sender() {
        var str: string = "";
        if (this.xml_data != 'undefined') {
            str = this.xml_data.XMT103Schema.XMT103['@Sender'];
            console.log(str);
        }
        return str;
    }
}
