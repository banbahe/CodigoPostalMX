const userEntity = require('../entities/user.entity')
const responseutil = require('../util/response.util')
const path = require('path'),
    fs = require('fs');
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
    ReadAll: function (req, res) {
        let startPath = __dirname;
        let filter = 'xml';

        if (!fs.existsSync(startPath)) {
            console.log("no dir ", startPath);
            return;
        }

        var files = fs.readdirSync(startPath);
        var filesxml = [];
        for (var i = 0; i < files.length; i++) {
            var filename = path.join(startPath, files[i]);
            var stat = fs.lstatSync(filename);
            if (stat.isDirectory()) {
                fromDir(filename, filter); //recurse
            } else if (filename.indexOf(filter) >= 0) {
                console.log('-- found: ', filename);
                filesxml.push(filename);
            };
        };

        // files found
        if (filesxml.length > 0) {
            // read files
            filesxml.forEach(function (value, index) {
                var parser = require('xml2json');
                fs.readFile( './data.xml', function(err, data) {
                    var json = parser.toJson(data);
                    console.log("to json ->", json);
                 });
              
            })
        }
        console.dir(filesxml);
    }
}