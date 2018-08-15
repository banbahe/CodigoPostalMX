const scoreEntity = require('../entities/scores.entity')
const responseutil = require('../util/response.util')
const enums = require('../util/enums.util')

module.exports = {
    Create: function (req, res) {
        // check if exist course
        let query = scoreEntity.find({
            course: req.body.course,
        });

        query.exec(function (err, docs) {
            if (err) {
                responseutil.Send(res, 400, '', false, ('error' + err), '', '');
            }


            if (docs.length >= 1) {
                responseutil.Send(res, 400, '', false, 'Materia ya existe', '', '');
            } else {

                let datetmp = enums.DateTimeNowToMilliSeconds();
                let score = scoreEntity({
                    id_item: 0,
                    status_item: 1,
                    maker: req.body.maker,
                    create_date: datetmp,
                    modification_date: datetmp,
                    score: req.body.score,
                    user: req.body.user,
                    course: req.body.course,
                });

                score.save(function (err) {
                    if (err) {
                        responseutil.Send(res, 400, '', false, ('error' + err), '', '');
                    } else {
                        responseutil.Send(res, 200, JSON.stringify(score), 'OK', '', '');
                    }
                });
            }
        });
    },
    GetAll: function (req, res) {
        scoreEntity.find({}, function (err, docs) {
            if (err) {
                responseutil.Send(res, 400, '', false, ('error' + err), '', '');
            } else {
                res.status(200).send(docs);
            }
        });
    },
    Delete: function (req, res) {
        scoreEntity.findById(req.params.scoreid, function (err, doc) {
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
        scoreEntity.findById(req.params.scoreid, function (err, doc) {
            if (err) {
                console.dir(err);
                responseutil.Send(res, 400, '', false, ('error' + err), '', '');
            } else {
                doc.modification_date = enums.DateTimeNowToMilliSeconds();
                doc.status_item = req.body.status_item;
                doc.score = req.body.score,
                // doc.user = req.body.user,
               // doc.course =  req.body.course,
                doc.save(function (err, docUpdate) {
                    if (err) return err;
                    res.send(docUpdate);
                });
            }
        });
    },
    Get: function (req, res) {

        scoreEntity.findById(req.params.scoreid, function (err, doc) {
            if (err) {

                responseutil.Send(res, 400, '', false, ('error' + err), '', '');
            } else {
                res.send(doc);
            }
        });
    }
}