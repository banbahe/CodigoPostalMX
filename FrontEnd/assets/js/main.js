
// GeoClass.test('test');

var ListEmisor = [];
var ListReceptor = [];
var map;
var markers = [];
var geocoder;

var btnEmisor = document.getElementById('btnEmisor');
btnEmisor.addEventListener('click',function(event){
    console.dir(event);
    alert('emisor');
});

$(document).ready(function () {
});


function CFDIGet() {
    $.ajax({
        url: 'http://localhost:8888/cfdi.json',
        method: 'GET',
        async: true,
        cache: false,
        dataType: 'json',
        success: function (data, textStatus, jqXHR) {
            // console.log('data');
            // console.dir(data);

            data.map(item => {
                // function Domicilio(tipo, rfc, nombre,calle,colonia,municipio, estado, pais,codigoPostalnoExterior){
                // debugger;
                let CFDIobj = new Domicilio(1,
                    item.receptor.rfc,
                    item.receptor.nombre,
                    item.receptor.domicilio.calle,
                    item.receptor.domicilio.colonia,
                    item.receptor.domicilio.municipio,
                    item.receptor.domicilio.estado,
                    item.receptor.domicilio.codigoPostal);

                ListReceptor.push(CFDIobj);
                
                 CFDIobj = new Domicilio(1,
                              item.emisor.rfc,
                              item.emisor.nombre,
                              item.emisor.domicilio.calle,
                              item.emisor.domicilio.colonia,
                              item.emisor.domicilio.municipio,
                              item.emisor.domicilio.estado,
                              item.emisor.domicilio.codigoPostal);

                ListReceptor.push(CFDIobj);
            });


        },
        complete: function (jqXHR, textStatus) {
            // console.log(ListReceptor.length);
            // var unique = ListReceptor.filter( onlyUnique ); 
            // console.dir(unique);
            // console.log(unique.length);
            let arrayTmp  = [];
            ListReceptor.map(item => {
                // debugger;
                if (item.calle.length > 0) {
                    arrayTmp.push(item.calle + ' ' + item.municipio);
                    // setTimeout(`CFDIAddressGet('${item.calle}')`, 12000); 
                }
            });

            var unique = arrayTmp.filter(onlyUnique);
           //  console.dir(unique);
           unique.map(item => {
               setTimeout(`CFDIAddressGet('${item}')`, 18000); 
           });

        }
    });
}

function initMap() {

    var myLatlng = { lat: 23.2635847, lng: -101.2814849 };
    map = new google.maps.Map(document.getElementById('map'), {
        center: myLatlng,
        zoom: 6
    });
    map.addListener('click', function (event) {
        addMarker(event.latLng);
    });
    // search direction

    geocoder = new google.maps.Geocoder();
    // console.dir(tmp.length);


}

function addMarker(location) {
  //  var marker = new google.maps.Marker({
  //   position: location,
  //      map: map
  // });
    alert('start');
    CFDIGet();

}

function CFDIAddressGet(element) {
    //debugger;
    // console.log(element);
    geocoder.geocode({ 'address': element }, function (results, status) {
        if (status == 'OK') {
          //  debugger;
            //console.dir(results);
           // console.dir(results[0].geometry.location.lat());
            // console.dir(results[0].geometry.location.lng());
           // map.setCenter(results[0].geometry.location);
            
            var marker = new google.maps.Marker({
                map: map,
                position: results[0].geometry.location
            });
        } else if(status == 'OVER_QUERY_LIMIT') {
            // CFDIAddressGet(element);
            //console.log('Geocode was not successful for the following reason: ' + status);
           // console.log('OVER_QUERY_LIMIT');
            setTimeout(`CFDIAddressGet('${element}')`, 20000); 
        }else{
            console.log(element);
            console.log('Geocode was not successful for the following reason: ' + status);
        }
    });
}

addMarker.prototype.IsNullorEmpty = function (param) {
    if (typeof (param) === 'undefined' || param === null) {
        return '';
    } else {
        return param;
    }
}


//  librerias
function sleep(ms) {
    return new Promise(resolve => { setTimeout(resolve, ms) });

}

function onlyUnique(value, index, self) { 
   return self.indexOf(value) === index;
 }