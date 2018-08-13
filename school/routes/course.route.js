const ctrlCourse = require('../controllers/course.controller')
module.exports = function(app) {
   
    app.post('/api/courses',ctrlCourse.Create);
    // app.get('/api/courses',ctrlCourse.GetAll);
    // app.get('/api/courses/:id',ctrlCourse.Get);
    // app.delete('/api/courses/:id',ctrlCourse.Delete);
    // app.patch('/api/courses/:id',ctrlCourse.Update);
};
