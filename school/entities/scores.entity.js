const mongoose = require("mongoose");
const Schema = mongoose.Schema;

// const Course = mongoose.model('Course');
// const User = mongoose.model('User');

let score = new Schema({
  id_item: { type: Number, require: true },
  status_item: { type: Number, require: true },
  maker: { type: String, required: true },
  create_date: { type: Number, required: true },
  modification_date: { type: Number, required: true },
  score: Number,
  user: {type: Schema.Types.ObjectId, ref: 'users'},
  course:{type: Schema.Types.ObjectId, ref: 'courses'}
});

const Score = mongoose.model('scores',score);
module.exports = Score;
