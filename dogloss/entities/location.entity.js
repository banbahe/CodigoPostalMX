const mongoose = require('mongoose');
const Schema = mongoose.Schema;

let location = new Schema({
  id_item: { type: Number, require: true },
  status_item: { type: Number, require: true },
  maker: { type: String, required: true },
  create_date: { type: Date, required: true },
  modification_date: { type: Date, required: true },
  x_point: String,
  y_point: String,
  ratio : String,
  idDog: Number
});

const Location = mongoose.model('location',location);
module.exports = Location;