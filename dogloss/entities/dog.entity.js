const mongoose = require('mongoose');
const Schema = mongoose.Schema;

let dog = new Schema({
  id_item: { type: Number, require: true },
  status_item: { type: Number, require: true },
  maker: { type: String, required: true },
  create_date: { type: Date, required: true },
  modification_date: { type: Date, required: true },
  name: String,
  alias: String,
  features: String,
  size: String, // meter logica interna para que acepte solamente xs, s , m , L ,XL , XXL
  color: String 
});

const Dog = mongoose.model('dog',dog);
module.exports = Dog;