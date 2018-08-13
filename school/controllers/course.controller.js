const courseEntity = require('../entities/courses.entity')
const responseutil = require('../util/response.util')
const enums = require('../util/enums.util')

module.exports = {
    Create: function (req, res) {
        // check if exist course
        let query = courseEntity.find({
            name: req.body.name,
            grade: req.body.grade
        });

        query.exec(function (err, docs) {
            if (err) {
                responseutil.Send(res, 400, '', false, ('error' + err), '', '');
            }


            if (docs.length >= 1) {
                responseutil.Send(res, 400, '', false, 'Materia ya existe', '', '');
            } else {

                let datetmp = enums.DateTimeNowToMilliSeconds();
                let course = courseEntity({
                    id_item: 0,
                    status_item: 1,
                    maker: req.body.userlogin,
                    create_date: datetmp,
                    modification_date: datetmp,
                    user: req.body.userid,
                    name: req.body.name,
                    grade: req.body.grade
                });

                course.save(function (err) {
                    if (err) {
                        return err;
                    } else {
                        responseutil.Send(res, 200, JSON.stringify(course), 'OK', '', '');
                    }
                });
            }
        });
    },
    GetAll: function (req, res) {
        userEntity.find({}, function (err, users) {
            res.status(200).send(users);
            //  responseutil.Send(res, 200, JSON.stringify(user), 'OK', '', '');

        });
    },
    Delete: function (req, res) {
        userEntity.findById(req.params.userid, function (err, doc) {
            if (err) {
                console.dir(err);
                responseutil.Send(res, 400, '', false, ('error' + err), '', '');
            }

            doc.status_item = StatusItem.DISABLE;
            doc.save(function (err, userUpdate) {
                if (err) return err;
                res.send(userUpdate);
            });
        });
    },
    Update: function (req, res) {

        var d = new Date();
        var n = d.getTime();

        userEntity.findById(req.params.userid, function (err, doc) {
            if (err) {
                console.dir(err);
                responseutil.Send(res, 400, '', false, ('error' + err), '', '');
            }

            doc.modification_date = n;
            doc.typeUser = req.body.typeUser;
            doc.password = req.body.password;
            doc.username = req.body.username;
            doc.birthday = req.body.birthday;
            doc.rfc = req.body.rfc;
            doc.curp = req.body.curp;
            doc.zipcode = req.body.zipcode;
            doc.home_reference = req.body.home_reference;
            doc.apartment_number = req.body.apartment_number;
            doc.telephone_number = req.body.telephone_number;
            doc.telephone_number2 = req.body.telephone_number2;

            doc.save(function (err, userUpdate) {
                if (err) return err;
                res.send(userUpdate);
            });
        });
    },
    Get: function (req, res) {
        console.dir(req.params.userid);
        userEntity.findById(req.params.userid, function (err, doc) {
            if (err) {
                console.dir(err);
                responseutil.Send(res, 400, '', false, ('error' + err), '', '');
            }
            res.send(doc);
        });
    }
}