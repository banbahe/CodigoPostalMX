const mongoose = require("mongoose");
const Schema = mongoose.Schema;

let user = new Schema({
  id_item: { type: Number, require: true },
  status_item: { type: Number, require: true },
  maker: { type: String, required: true },
  create_date: { type: Number, required: true },
  modification_date: { type: Number, required: true },
  email: { type: String, required: true, unique: true },
  password: { type: String, required: true },
  typeUser: { type: Number, required: true },
  username: String,
  name: String,
  lastname: String,
  lastname2: String,
  alternatemail: String,
  birthday: Number,
  rfc: String,
  curp: String,
  genre: Number,
  zipcode: String,
  home_reference: String,
  apartment_number: String,
  telephone_number: String,
  telephone_number2: String
});

const User = mongoose.model('user',user);
module.exports = User;
