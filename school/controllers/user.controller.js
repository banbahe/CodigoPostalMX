const userEntity = require('../entities/user.entity')
const responseutil = require('../util/response.util')
/**
 * // DOG
 * id
 * notas dog
 * name 
 * alias
 * features
 * size ( xs, s, m, l xl xll) 
 * color
 * 
 * 
 * // FECHA 
 * data birthday
 * data loss
 * date encontrado
 * historial
 * idDog
 * 
 * 
 * // Multimedia
 * idDog
 * url
 * 
 * // Location
 * x_perdidad
 * y_perdidad
 * ratio 100km
 * 
 * 
 */

module.exports = {
    UserCreate: function (req, res) {
        var d = new Date();
        var n = d.getTime();

        // check if exist email
        let query = userEntity.find({
            email: req.body.email
        });
        query.exec(function (err, docs) {
            if (err) {
                console.log('error' + err);
                responseutil.Send(res, 400, '', false, ('error' + err), '', '');
            }

            if (docs.length >= 1) {
                responseutil.Send(res, 400, '', false, 'Usuario ya existe', '', '');
            } else {
                let user = userEntity({
                    id_item: 0,
                    status_item: 1,
                    maker: req.body.email,
                    create_date: n,
                    modification_date: n,
                    email: req.body.email,
                    password: req.body.password,
                    typeUser: req.body.typeUser,
                    username: '',
                    name: '',
                    lastname: '',
                    lastname2: '',
                    alternatemail: '',
                    birthday: n,
                    rfc: '',
                    curp: '',
                    genre: 0,
                    zipcode: '',
                    home_reference: '',
                    apartment_number: '',
                    telephone_number: '',
                    telephone_number2: ''
                });

                user.save(function (err) {
                    if (err) {
                        return err;
                    } else {
                        responseutil.Send(res, 200, JSON.stringify(user), 'OK', '', '');
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
    }
}