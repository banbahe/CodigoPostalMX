function Domicilio(tipo, rfc, nombre,calle,colonia,municipio, estado, pais,codigoPostal,noExterior){
    this.tipo = this.IsNullOrEmpty(tipo);  
    this.rfc = this.IsNullOrEmpty(rfc);
    this.nombre = this.IsNullOrEmpty(rfc);   
    this.calle = this.IsNullOrEmpty(calle);
    this.colonia = this.IsNullOrEmpty(colonia);
    this.municipio = this.IsNullOrEmpty(municipio);
    this.estado = this.IsNullOrEmpty(estado);
    this.pais = this.IsNullOrEmpty(estado);
    this.codigoPostal = this.IsNullOrEmpty(codigoPostal);    
    this.noExterior = this.IsNullOrEmpty(noExterior);
    return this;
}

Domicilio.prototype.IsNullOrEmpty= function(param){
    if (typeof(param) === 'undefined' || param === null ) {
        return '';
    }else {
        return param;
    }
}