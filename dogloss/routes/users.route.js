const ctrl = require('../controllers/user.controller')
module.exports = function(app) {
    app.post('/api/users',ctrl.UserCreate);
};
