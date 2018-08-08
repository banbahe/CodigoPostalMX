/**
 * Created by Voltron on 12/06/2017.
 */
const _dataraw = require('../Config/DataRAW');
const nodemailer = require('nodemailer');
const smtpTransport = require('nodemailer-smtp-transport');

module.exports = {
    init: function (objReceiver) {
        // subject
        var vsubject = _dataraw.subject();
        vsubject = vsubject[Math.floor(Math.random() * vsubject.length)];

        // body
        //var vbody = _dataraw.body();
        var vbody = _dataraw.body2(objReceiver);
        // console.log(vbody);
        vbody = vbody[Math.floor(Math.random() * vbody.length)];
        // Email sender
        var vsender = _dataraw.senderconfig();
        vsender = vsender[Math.floor(Math.random() * vsender.length)];

        var transporter = nodemailer.createTransport(
            smtpTransport(vsender)
        );

        transporter.sendMail({
            to: objReceiver,
            from: vsender.auth.user,
            subject: vsubject,
            html: vbody


        }, function (error) {
            if (error) {
                console.log('Se ha creado un ' + error);
                //callback(error);
            } else {
                console.log('Message sent');
                //console.log('Message sent', 'response.response');
            }
        });

        return objReceiver.EmailOrigin;
    }
}