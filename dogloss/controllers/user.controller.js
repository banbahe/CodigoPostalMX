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
    UserCreate: function(req,res){
        let user = userEntity({
            id_item: 0,
            status_item: 1,
            maker: req.body.email,
            create_date: new Date(),
            modification_date: new Date(),
            email: req.body.email,
            password: req.body.password,
            name: '',
            lastname: '',
            lastname2: '',
            alternatemail: '',
            birthday: new Date(),
            rfc: '',
            curp: '',
            genre: 0,
            zipcode: '',
            home_reference: '',
            apartment_number: '',
            telephone_number: '',
            telephone_number2: ''   
        });

        user.save(function(err){
            if(err){
                return err;
            }else{
                responseutil.Send(res, 200, JSON.stringify(user), 'OK', '', '');
            }
        });
        
    }
}