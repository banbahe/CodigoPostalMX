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
                        responseutil.Send(res, 400, '', false, ('error' + err), '', '');
                    } else {
                        responseutil.Send(res, 200, JSON.stringify(course), 'OK', '', '');
                    }
                });
            }
        });
    },
    GetAll: function (req, res) {
        courseEntity.find({}, function (err, docs) {
            if (err) {
                responseutil.Send(res, 400, '', false, ('error' + err), '', '');
            } else {
                res.status(200).send(docs);
            }
        });
    },
    Delete: function (req, res) {
        courseEntity.findById(req.params.courseid, function (err, doc) {
            if (err) {
                responseutil.Send(res, 400, '', false, ('error' + err), '', '');
            } else {
                doc.status_item = enums.StatusItem.DISABLE;
                doc.save(function (err, docUpdate) {
                    if (err) return err;
                    res.send(docUpdate);
                });
            }
        });
    },
    Update: function (req, res) {
        courseEntity.findById(req.params.courseid, function (err, doc) {
            if (err) {
                console.dir(err);
                responseutil.Send(res, 400, '', false, ('error' + err), '', '');
            } else {
                doc.modification_date = enums.DateTimeNowToMilliSeconds();
                doc.user = req.body.user;
                doc.name = req.body.name;
                doc.grade = req.body.grade;
                doc.status_item = req.body.status_item;
                doc.save(function (err, docUpdate) {
                    if (err) return err;
                    res.send(docUpdate);
                });
            }
        });
    },
    Get: function (req, res) {

        courseEntity.findById(req.params.courseid, function (err, doc) {
            if (err) {

                responseutil.Send(res, 400, '', false, ('error' + err), '', '');
            } else {
                res.send(doc);
            }
        });
    }
}