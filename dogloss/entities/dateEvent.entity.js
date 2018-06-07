const mongoose = require('mongoose');
const Schema = mongoose.Schema;

let dateEvent = new Schema({
  id_item: { type: Number, require: true },
  status_item: { type: Number, require: true },
  maker: { type: String, required: true },
  create_date: { type: Date, required: true },
  modification_date: { type: Date, required: true },
  datebirthday: Number,
  datefound: String,
  history: String,
  idDog: Number
});

const DateEvent = mongoose.model('dateEvent',dateEvent);
module.exports = DateEvent;