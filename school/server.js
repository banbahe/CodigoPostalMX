const express = require("express");
const cors = require("cors");
const bodyParser = require("body-parser");
const mongoose = require("mongoose");
const configDB = require("./config/mongoose");
const app = express();

// start app
app.set("port", process.env.PORT || 5000);
app.use(cors());
app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());

routes = require("./routes/users.route")(app);
// routes = require("./routes/cfdi.route")(app);


mongoose.disconnect();
mongoose
  .connect(configDB.url, {
    useMongoClient: true,
    reconnectTries: Number.MAX_VALUE
  })
  .then(x => {
    console.log("connection success");
  });

  app.listen(
      app.get('port'),function () {
        console.log('rest service is runnin on port', app.get('port'))  
      }
  )