const ctrl = require('../controllers/user.controller')
module.exports = function(app) {
    app.post('/api/users',ctrl.UserCreate);
    app.delete('/api/users/:userid',ctrl.Delete);
    app.get('/api/users',ctrl.GetAll);
    app.get('/api/users/:userid',ctrl.Get);

    app.patch('/api/users/:userid',ctrl.Update);
};
