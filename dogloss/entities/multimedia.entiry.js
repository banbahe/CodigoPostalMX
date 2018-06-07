const mongoose = require('mongoose');
const Schema = mongoose.Schema;

let multimedia = new Schema({
  id_item: { type: Number, require: true },
  status_item: { type: Number, require: true },
  maker: { type: String, required: true },
  create_date: { type: Date, required: true },
  modification_date: { type: Date, required: true },
  url: String,
  idDog: Number
});

const Multimedia = mongoose.model('multimedia',multimedia);
module.exports = Multimedia;